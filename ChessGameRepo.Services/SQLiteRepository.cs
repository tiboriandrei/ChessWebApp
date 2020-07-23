using ChessClassLibrary;
using ChessGameRepository.Interface;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using Dapper;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace ChessGameRepo.Services
{
    public class SQLiteRepository 
    {
        public SqliteConnection Conn { get; set; }

        public SQLiteRepository()
        {
            Conn.ConnectionString = "Data Source=.\\demoDB.db;Version=3;";
        }

        public void AddGame(Game game)
        {
            using (IDbConnection cnn = Conn)
            {
                cnn.Execute("INSERT into Game (Player1, Player2, GameState) values @player1_name, @player2_name, @gameState");
            }
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
