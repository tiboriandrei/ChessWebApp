using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChessClassLibrary;

namespace ChessData
{
    public interface IChessData
    {
        IEnumerable<Game> GetGame();
    }

    public class InMemoryGame : IChessData
    {
        readonly List<Game> Game;

        public InMemoryGame()
        {
            Game = new List<Game>()
            {
                new Game()
            };
        }

        public IEnumerable<Game> GetGame()
        {
            return from g in Game
                   select g;
        }
    }
}
