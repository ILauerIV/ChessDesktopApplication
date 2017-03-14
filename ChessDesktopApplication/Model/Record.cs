using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    /// <summary>
    /// This class is a record of movements in a game 
    /// </summary>
    /// 
    public class Record
    {
        List<Turn> turns;
        public Record()
        {
            turns = new List<Turn>(); 
        }

        public Turn getTurn(int index) {
            return  turns.ElementAt<Turn>(index);
  }
        public void recordTurn(int initX, int initY, int destX, int destY,char initPiece, char destPiece)
        {
            turns.Add(new Turn(initX,initY,destX,destY,initPiece,destPiece));
        }
        public void recordTurn(int initX, int initY, int destX, int destY, char initPiece, char destPiece, bool en, bool cast, bool pawnp)
        {
            turns.Add(new Turn(initX, initY, destX, destY, initPiece, destPiece,en,cast,pawnp));
        }

        
        public Turn getLastTurn()
        {
            return turns.ElementAt<Turn>(turns.Count - 1);
        }
        override public String ToString()
        {
            return ""; 
        }
    }
}
