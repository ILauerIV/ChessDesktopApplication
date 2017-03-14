using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication.Controller
{
   public interface Game
    {
        bool move(Player player, int initX, int initY, int destX, int destY);
        void game();

    }
}
