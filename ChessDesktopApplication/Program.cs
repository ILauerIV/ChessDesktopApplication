
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication
{
  

    
        class Program
        {
            static void Main(string[] args)
            {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\test.txt"))
            {
              
                file.Close(); 
            }
            }
        }
    }
/// OVER ALL TD's
/// TODO: Understand what all the player needs to input
/// TODO: Decide how pawn promotion will work
/// TODO:Refactor?
