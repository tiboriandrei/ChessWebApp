using ChessClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGameRepository.Interface
{
    public interface IChessGameRepository
    {
        IEnumerable<Game> GetGames();

        Game GetGameByID(int id);

        void AddGame(Game newGame);

        void UpdateGameByID(int id, Game updatedGame);

        void DeteleGameByID(int id);

        IEnumerable<Player> GetPlayers();

        Player GetPlayerByID(int id);

        void AddPlayer(Player newPlayer);

        void UpdatePlayerByID(int id, Player updatedPlayerData);

        void DetelePlayerByID(int id);

    }
}
