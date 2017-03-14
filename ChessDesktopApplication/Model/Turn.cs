using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessDesktopApplication.Model
{
    /// <summary>
    /// Represents one turn of the game. To be used in Record
    /// </summary>
    public class Turn
    {
        public char initPiece;
        public char destPiece; 
        public int initX;
        public int initY;
        public int destX;
        public int destY;
      public  String move;
       public bool enpassant;
      public  bool castling;
        public bool pawnpromote; 
       
        public Turn (int initX, int initY,int destX, int destY, char initPiece,char destPiece, bool en, bool cast, bool pawnp)
        {
            this.destX = destX;
            this.destY = destY;
            this.initX = initX;
            this.initY = initY;
            this.initPiece = initPiece;
            this.destPiece = destPiece;
            enpassant = en;
            castling = cast;
            pawnpromote = pawnp; 
            move = notation(); 
            
        }
        public Turn(int initX, int initY, int destX, int destY, char initPiece, char destPiece)
        {
            this.destX = destX;
            this.destY = destY;
            this.initX = initX;
            this.initY = initY;
            this.initPiece = initPiece;
            this.destPiece = destPiece;
            enpassant = false;
            castling = false;
            pawnpromote = false;
            move = notation();

        }

        /// <summary>
        /// Returns the algebraic notation of the last move 
        /// </summary>
        /// <returns></returns>
        private String notation()
        {
            String moveNot = "";
            moveNot = moveNot + initPiece;
            if (destPiece != ' ')
            {
                moveNot = moveNot + "x";
            }
            if (pawnpromote) ///TODO: ADD Pawn Promotion to Notaion
            {}
           moveNot = moveNot + Notation.IndexToChessNotation(destX, destY);
            if (castling)
            {
                if (destY == 6)
                {
                    return "0-0";
                }
                else
                {
                    return "0-0-0";
                }
            }
            if (enpassant) { } ///TODO: ADD ENPASSNANT TO NOTATION
            return moveNot;
        }
    }
}
