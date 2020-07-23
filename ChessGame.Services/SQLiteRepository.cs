using ChessClassLibrary;
using ChessGameRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame.Services
{
    public class SQLiteRepository : IGameRepository
    {
       // sqlite_conn = new SQLiteConnection();

        public void AddGame(Game newGame)
        {
            throw new NotImplementedException();
        }

        public void DeteleGame(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGame(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetGames()
        {
            throw new NotImplementedException();
        }

        public void UpdateGame(int id, Game updatedGame)
        {
            throw new NotImplementedException();
        }
    }
}
