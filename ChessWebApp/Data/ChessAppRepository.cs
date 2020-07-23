using ChessClassLibrary;
using ChessClassLibrary.Pieces;
using ChessWebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ChessWebApp.Data
{
    public class ChessAppRepository : IChessAppRepository
    {
        private readonly ChessContext _ctx;

        public ChessAppRepository(ChessContext ctx)
        {
            _ctx = ctx;
        }

        public void AddGame(Game newGame)
        {
            //converting ChessClassLibrary.Game to ChessWebApp.Data.Entities.ChessGame

            ChessGame game = new ChessGame();
            //game.Player1 = new ChessPlayer(newGame.Player1.Name, newGame.Player1.NrOfWins, newGame.Player1.NrOfLosses, newGame.Player1.NrOfDraws, newGame.Player1.Stats);
           // game.Player2 = new ChessPlayer(newGame.Player2.Name, newGame.Player2.NrOfWins, newGame.Player2.NrOfLosses, newGame.Player2.NrOfDraws, newGame.Player2.Stats);

            ChessPlayer p1 = _ctx.Players.Find(10);         //id player1
            ChessPlayer p2 = _ctx.Players.Find(11);         //id player2 

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
            //converting ChessWebApp.Data.Entities.ChessGame back to ChessClassLibrary.Game
            
            Game g = null;

            foreach (var game in _ctx.Games.Include(d => d.GameState).Include(d => d.GameState.Spots).Include(d => d.Player1).Include(d => d.Player2))
            {
                if (game.Id == id)
                {
                    Player p1 = new Player(game.Player1.Name, game.Player1.NrOfWins, game.Player1.NrOfLosses, game.Player1.NrOfDraws);
                    Player p2 = new Player(game.Player2.Name, game.Player2.NrOfWins, game.Player2.NrOfLosses, game.Player2.NrOfDraws);
                    
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

                    g = new Game(p1, p2, restoredTable);
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
            List<Player> playerList = new List<Player>();
            foreach (var player in _ctx.Players) 
            {
                if (player.Id == id)
                {
                    Player p = new Player(player.Name, player.NrOfWins, player.NrOfLosses, player.NrOfDraws);
                    playerList.Add(p);
                }
                          
            }
            return playerList.First();
        }

        public IEnumerable<Player> GetPlayers()
        {
            List<Player> playerList = new List<Player>();
            foreach (var player in _ctx.Players)
            {
                Player p = new Player(player.Name, player.NrOfWins, player.NrOfLosses, player.NrOfDraws);
                playerList.Add(p);
            }
            return playerList;            
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void UpdateGameByID(int id, Game updatedGame)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayerByID(int id, Player updatedPlayerData)
        {
            throw new NotImplementedException();
        }
    }
}
