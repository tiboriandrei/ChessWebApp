using ChessClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameRepository.Interface
{
    public interface IChessPlayersRepository
    {
        IEnumerable<Player> GetPlayers();

        Player GetPlayerByID(int id);

        void AddPlayer(Player newPlayer);

        void UpdatePlayerByID(int id, Player updatedPlayerData);

        void DetelePlayerByID(int id);
    }
}
