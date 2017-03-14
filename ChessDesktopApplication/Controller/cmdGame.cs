﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessDesktopApplication.Model;

namespace ChessDesktopApplication.Controller
{
    /// <summary>
    /// This class controls the turn sequence along with overall play of a game 
    /// </summary>
    class CMDGame :Game
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
        public bool move(Player player, int initX, int initY, int destX, int destY)  ///TODO: make sure turns can be recorded with speical moves  
        {
            bool moved;
            char piece = board.getPiece(initX, initY);
            char destPiece = board.getPiece(destX, destY);
            bool pieceIsWhite =Board.isWhite( board.getPiece(initX, initY));
            if (pieceIsWhite != whitesTurn)
            {
                return false;
            }
            moved =  Movement.movePiece(initX, initY, destX, destY,board);
            if (moved)
            {
                whitesTurn = !pieceIsWhite;
                record.recordTurn(initX, initY, destX, destY,piece,destPiece);
            }
            return moved; 
        }
        public void game()
        {

        }   
   
      
    }
}