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
    }
}
