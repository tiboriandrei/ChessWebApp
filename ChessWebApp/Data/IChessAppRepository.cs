using ChessClassLibrary;
using ChessWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebApp.Data
{
    public interface IChessAppRepository
    {
        IEnumerable<Game> GetGames();

        Game GetGameByID(int id);

        GameStateForJS[] LoadGameState(int id);

        void AddGame(Game newGame);

        void UpdateGame(int id, int originColumn, int originRow, int destColumn, int destRow, string player, string piece);

        void DeteleGameByID(int id);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerByID(int id);

        void AddPlayer(Player newPlayer);

        void UpdatePlayerByID(int id, Player updatedPlayerData);

        void DetelePlayerByID(int id);

        bool SaveAll();
    }
}
