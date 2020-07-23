using ChessClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGameRepository.Interface
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetGames();

        Game GetGame(int id);

        void AddGame(Game newGame);

        void UpdateGame(int id, Game updatedGame);

        void DeteleGame(int id);

    }
}
