using System;
using System.Collections.Generic;
using System.Text;
using ChessClassLibrary;
using ChessGameRepository.Interface;


namespace ChessGameRepo.Services
{
    public class EFRepository : IChessGameRepository
    {
        //private readonly ChessContext _ctx;

        public void AddGame(Game newGame)
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(Player newPlayer)
        {
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
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public Player GetPlayerByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetPlayers()
        {
            throw new NotImplementedException();
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
