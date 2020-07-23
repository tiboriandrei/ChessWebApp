using System;
using System.Collections.Generic;
using System.Text;
using ChessClassLibrary;
using ChessGameRepository.Interface;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ChessGameRepo.Services
{
    public class localSQLRepository 
    {
        public static string GetConnectionString()
        {
            string con = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ChessDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            return con;
        }


        public void AddGame(Game newGame)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                //return cnn.Execute(sql, data);
            }

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
