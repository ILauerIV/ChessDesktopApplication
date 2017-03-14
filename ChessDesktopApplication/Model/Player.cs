using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    /// <summary>
    /// The class represents a player 
    /// </summary>
  public  class Player
    {
        private bool isWhite;
        private String name; 
        public Player (bool initIsWhite)
        {
            isWhite = initIsWhite; 
            if (isWhite)
            {
                name = "white";
            }
            else
            {
                name = "black"; 
            }
        }
        public bool getIsWhite()
        {
            return isWhite;
        }
    }
    
}
