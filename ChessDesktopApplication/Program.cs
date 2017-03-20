
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;
using ChessDesktopApplication.Controller;
using ChessDesktopApplication.View;
namespace ChessDesktopApplication
{
  

    
        class Program
        {
            static void Main(string[] args)
            {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CMDGame game = new CMDGame();
            game.game();  
            }
  
        }
    }
/// OVER ALL TD's
/// TODO: Understand what all the player needs to input
/// TODO: Decide how pawn promotion will work
/// TODO:Refactor?
