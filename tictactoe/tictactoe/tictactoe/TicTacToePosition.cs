using System;

namespace TicTacToe
{

    public class TicTacToePosition{

        // Define an enumeration for Tic Tac Toe marks (X, O, EMPTY)
        public enum TicTacToeMarks
        {
            X,
            O,
            EMPTY
        }

        private TicTacToeMarks _mark;

        public TicTacToePosition(){
            _mark=TicTacToeMarks.EMPTY;
        }

        ///this property has a getter and a setter
        public TicTacToeMarks Mark{
            get { return _mark ; } 

            set { 
                if ((value != TicTacToeMarks.X) && (value != TicTacToeMarks.O) && (value != TicTacToeMarks.EMPTY))
                {
                    throw new ArgumentException("Invalid mark value.");
                }
                if (_mark != TicTacToeMarks.EMPTY)
                {
                    throw new ArgumentException("Position is already marked.");
                }
                _mark=value;
            }
        }


        /// <summary>
        /// Override ToString method to represent the position as a string.
        /// </summary>
        /// <returns> O if the mark is O,X if the mark is X OR empty string </return>
        public override string ToString()
        {
           if (_mark == TicTacToeMarks.O){
                return "O";
            } else if (_mark == TicTacToeMarks.X){
                return "X";
            } else {
                return " "; 
            }
        }
    }
}
    