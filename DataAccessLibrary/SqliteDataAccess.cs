using ChessClassLibrary;
using Microsoft.Data.Sqlite;
using System;
using System.Configuration;
using System.Data;
using Dapper;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataAccessLibrary
{
    public class SqliteDataAccess
    {
        //public static Game LoadGame() {

        //    Game game = new Game();
        //    using (IDbConnection cnn = LoadConnectionString()) {

        //    }
        //    return game;
        //}

        public static void SaveGame(Game game)
        {
            string player1_name = game.Player1.Name;
            string player2_name = game.Player2.Name;
            Table gameState = game.Table;

            using (IDbConnection cnn = LoadConnectionString())
            {
                cnn.Execute("INSERT into Game (Player1, Player2, GameState) values @player1_name, @player2_name, @gameState");                
            }
        }

        public static SqliteConnection LoadConnectionString() {            
            return new SqliteConnection("Data Source=.\\demoDB.db;Version=3;"); ;
        }

    }
}
