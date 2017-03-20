using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;
using ChessDesktopApplication.View;

namespace ChessDesktopApplication.Controller
{
    /// <summary>
    /// This class controls the turn sequence along with overall play of a game 
    /// </summary>
    public class CMDGame
    {
        private Board board;
        private Player white;
        private Player black;
        private Record record;
       
        private bool whitesTurn; 

        public CMDGame()
        {
            board = new Board();
            white = new Model.Player(true);
            black = new Model.Player(false);
            record = new Record();
           
            whitesTurn = true;         }
        /// <summary>
        /// Counts as one turn for a a game. Its moves a piece then changes sets the next players turn if the move was succesful
        /// </summary>
        /// <param name="initX"></param>
        /// <param name="initY"></param>
        /// <param name="destX"></param>
        /// <param name="destY"></param>
        /// <param name="isWhite"></param>
        /// <returns></returns>
        public bool move(Turn t)  ///TODO: make sure turns can be recorded with speical moves  
        {
            Turn moved;
            char piece = board.getPiece(t.initX, t.initY);
            char destPiece = board.getPiece(t.destX, t.destY);
            
            moved =  Movement.movePiece(t.initX, t.initY, t.destX, t.destY,board); // move piece
            bool enpassant = false; /// need to add way to get these flags here
            bool castling = false;
            //Pawnpromotion pp = new blah blah
            if (moved !=null)
            {
                whitesTurn = !Board.isWhite(piece); //change the current player
                record.recordTurn(moved); //record the move 
            }
            return moved != null; 
        }
        public void game()
        {
            CMDDisplay display = new CMDDisplay();
            bool gameEnded = false;
            bool check = false;
            while (!gameEnded)
            {
               display.newTurn(board, whitesTurn);
               Turn currentTurn = null;
                bool moveable = false;
                bool correctColor = false;
                while (currentTurn == null || !moveable || !correctColor || check) // while the current turn is false or the move is not allowed
                                                                                   // or the move is not of the piece of the current player
                                                                                   // or the current players king is in check 
                {
                    if(check)
                    {
                        Console.Write("You must move your king out of check \n");
                    }
                    currentTurn = CMDInput.cmdInputXY(); // Get input
                    if (currentTurn != null) // if the input was valid
                    {
                        moveable = Movement.moveable(currentTurn.initX, currentTurn.initY, currentTurn.destX, currentTurn.destY, board); //see if the players move is valid
                        if (whitesTurn)
                        {
                            correctColor = Board.isWhite(board.getPiece(currentTurn.initX, currentTurn.initY)); // see if the player moved his piece 
                        }
                        else
                        {
                            correctColor = Board.isBlack(board.getPiece(currentTurn.initX, currentTurn.initY)); /// SHOULD: Clean up 
                        }
                        if (!moveable)
                        {
                            display.moveError("Illegal Move \n ");
                        }
                        if (!correctColor)
                        {
                            display.moveError("Do not move your opponets piece \n");
                        }
                        if (!Checking.isChecked(board,whitesTurn)) // if the king is not in check
                        {
                            check = false; 
                        }
                    }
                }
                move(currentTurn); // actually move the piece and change player 
                check = Checking.isChecked(board, whitesTurn); // see if this move put the opponet in check

            }
        }

      
    }
}
