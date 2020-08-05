using ChessClassLibrary;
using ChessClassLibrary.Pieces;
using ChessClassLibrary.Players;
using ChessWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data
{
    public class ChessAppRepository : IChessGameRepository, IChessPlayersRepository
    {
        private readonly ChessContext _ctx;

        public ChessAppRepository(ChessContext ctx)
        {
            _ctx = ctx;
        }

        public void AddGame(Game newGame)
        {
            ChessGame game = new ChessGame();

            ChessPlayer p1 = _ctx.Players.Find(10);         //id player1 (temporarily hardcoded)
            ChessPlayer p2 = _ctx.Players.Find(11);         //id player2 (temporarily hardcoded)

            _ctx.Players.Attach(p1);
            _ctx.Players.Attach(p2);

            game.Player1 = p1;
            game.Player2 = p2;

            string piece = "";    
            
            ChessTable table = new ChessTable();
            table.Spots = new List<ChessSpot>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (newGame.Table.Spots[i, j].Occupied)
                    {
                        piece = newGame.Table.Spots[i, j].Piece.ToString();                        
                    }
                    
                    ChessSpot spot = new ChessSpot(piece, newGame.Table.Spots[i, j].Occupied, newGame.Table.Spots[i, j].CoordX, newGame.Table.Spots[i, j].CoordY);
                    piece = "";
                    table.Spots.Add(spot);
                }
            }
            game.GameState = table;
            game.Winner = "TBD";
            game.Date = DateTime.Now;
            
            _ctx.Games.Add(game);            

            _ctx.SaveChanges();
        }

        public void AddPlayer(Player newPlayer)
        {
            //_ctx.Add(newPlayer);
            throw new NotImplementedException();
        }

        public void DeteleGameByID(int id)
        {            
            throw new NotImplementedException();
        }

        public void DetelePlayerByID(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameByID(int id)
        {            
            Game g = null;

            foreach (var game in _ctx.Games.Include(d => d.GameState).Include(d => d.GameState.Spots).Include(d => d.Player1).Include(d => d.Player2))
            {
                if (game.Id == id)
                {
                    Player p1 = new White(game.Player1.Name, game.Player1.NrOfWins, game.Player1.NrOfLosses, game.Player1.NrOfDraws);
                    Player p2 = new Black(game.Player2.Name, game.Player2.NrOfWins, game.Player2.NrOfLosses, game.Player2.NrOfDraws);
                    
                    List<Spot> spotList = new List<Spot>();
                    foreach (var spot in game.GameState.Spots)
                    {
                        ChessPiece restoredPiece = null;

                        if (spot.Occupied)
                        {
                            string color = "";
                            string type = "";
                            char[] chArr = spot.Piece.ToCharArray();
                            for (int i = 0; i < 5; i++)
                            {
                                color += chArr[i];
                            }
                            bool pieceColor = false;
                            if (color == "White")
                            {
                                pieceColor = true;
                            }

                            for (int i = 5; i < spot.Piece.Length; i++)
                            {
                                type += chArr[i];
                            }

                            switch (type)
                            {
                                case "King": restoredPiece = new King(pieceColor); break;
                                case "Queen": restoredPiece = new Queen(pieceColor); break;
                                case "Pawn": restoredPiece = new Pawn(pieceColor); break;
                                case "Madman": restoredPiece = new Madman(pieceColor); break;
                                case "Horseman": restoredPiece = new Horseman(pieceColor); break;
                                case "Rook": restoredPiece = new Rook(pieceColor); break;
                                case "": restoredPiece = null; break;
                            }
                        }

                        Spot restoredSpot = new Spot(spot.CoordX, spot.CoordY, restoredPiece, spot.Occupied);
                        spotList.Add(restoredSpot);
                    }

                    Table restoredTable = new Table(spotList);

                    g = new Game(restoredTable);
                }
            }

            return g;
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerByID(int id)
        {
            throw new NotImplementedException();
            //List<Player> playerList = new List<Player>();
            //foreach (var player in _ctx.Players)
            //{
            //    if (player.Id == id)
            //    {
            //        Player p = new Player(player.Name, player.NrOfWins, player.NrOfLosses, player.NrOfDraws);
            //        playerList.Add(p);
            //    }
            //}
            //return playerList.First();
        }

        public IEnumerable<Player> GetPlayers()
        {
            throw new NotImplementedException();
            //List<Player> playerList = new List<Player>();
            //foreach (var player in _ctx.Players)
            //{
            //    Player p = new Player(player.Name, player.NrOfWins, player.NrOfLosses, player.NrOfDraws);
            //    playerList.Add(p);
            //}
            //return playerList;            
        }

        public GameStateForJS[] LoadGameState(int id)
        {
            var result = _ctx.Games.Include(d => d.GameState.Spots).Where(d => d.Id == id).FirstOrDefault();

            string color = "";
            string type = "";

            GameStateForJS[,] array = new GameStateForJS[8,8];
            GameStateForJS[] array1D = new GameStateForJS[64];

            foreach (var item in result.GameState.Spots)
            {
                if (item.Piece != "" && item.Piece != null)
                {
                    char[] chArr = item.Piece.ToCharArray();
                    for (int i = 0; i < 5; i++)
                    {
                        color += chArr[i];
                    }

                    for (int i = 5; i < item.Piece.Length; i++)
                    {
                        type += chArr[i];
                    }
                }

                if (item.Piece == "" || item.Piece == null) {
                    color = type = "n";
                }
                
                GameStateForJS obj = new GameStateForJS(type, color, item.CoordX, item.CoordY);

                array[7 - obj.CoordY, obj.CoordX] = obj;

                int index = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        array1D[index] = array[i, j];
                        index++;
                    }
                }
                type = color = "";
                
            }

            return array1D;
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void UpdateGame(int id, int originColumn, int originRow, int destColumn, int destRow, string player, string piece)
        {
            var result = _ctx.Games.Include(d => d.GameState.Spots).Where(d => d.Id == id).FirstOrDefault();
                        
                foreach (var item in result.GameState.Spots)                        //to-do: change List<ChessSpots> with a Dictionary<key, ChessSpot> 
                {                                                                       //where string key = originColumn + originRow, to avoid all this iterating
                    if (item.CoordX == originColumn && item.CoordY == originRow)                            //(if entity framework supports dictionary) 
                    {
                        item.Piece = "";
                        item.Occupied = false;
                        _ctx.Entry(item).State = EntityState.Modified;
                    }

                    if (item.CoordX == destColumn && item.CoordY == destRow)                           
                    {
                        item.Piece = player + piece;
                        item.Occupied = true;
                        _ctx.Entry(item).State = EntityState.Modified;
                         //to-do: add removed piece to history 
                    }
                }

            _ctx.Entry(result).State = EntityState.Modified;

            _ctx.SaveChanges();
        }

        public void UpdatePlayerByID(int id, Player updatedPlayerData)
        {
            throw new NotImplementedException();
        }

    }
}
