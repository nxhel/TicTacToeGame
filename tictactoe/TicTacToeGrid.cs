/// <author>Nihel Madani-Fouatih /author>
/// <created> 2024-02-06/created>
using static TicTacToe.TicTacToePosition;
namespace TicTacToe
{
    /// <summary>
    /// Class TicTacToeGrid Represents a TicTacToe grid and provides multiple Methods 
    /// to check weither there is a winner or not, data validation and print the grid.
    /// </summary>
    public class TicTacToeGrid
    {
        private TicTacToePosition[,] _grid ;
        public string Winner => GameWininer();
        public string GameWininer()
        {
            char result = CheckGrid();
             if (result == 'X')
                {
                    return "X";
                }
                else if (result == 'O')
                {
                    return "O";
                }
                else if (result == 'T')
                {
                    return "Tie";
                }
                else
                {
                    return "Ongoing" ;    
                }   
        }
        

        /// <summary>
        /// Initializes a new grid with the user wanted size and fills it with TicTacToePosition .
        /// Finally, it calls a method that prints the grid.
        /// </summary>
        public TicTacToeGrid(char gridSize)
        {
            _grid= new TicTacToePosition[gridSize,gridSize];
            for (int i =0 ; i<_grid.GetLength(0) ; i++)
            {
                for (int j=0; j<_grid.GetLength(1) ; j++)
                {
                       _grid[i,j]= new TicTacToePosition();
                }
            }
            PrintGrid();
        }

        /// <summary>
        /// Places the specified character (X or O) at the specified row and column in the grid.
        /// </summary>
        /// <param name="charToPlace">The character to place (X or O).</param>
        /// <param name="rowNumber">The row number where the character should be placed.</param>
        /// <param name="colNumber">The column number where the character should be placed.</param>
        public void PlaceCharacter (char charToPlace, int rowNumber, int colNumber)
        {
            while (true)
            {
                bool validChar = false;
                bool emptySpace =false;
                try{
                validChar = ValidateChar(charToPlace);
                emptySpace = CheckIfEmpty(rowNumber, colNumber);
                }catch(Exception e){
                
                    if (!validChar)
                    {
                        Console.WriteLine("Invalid Character. It has to be X or O (case insensitive)");
                    }
                    else if(!emptySpace){
                        Console.WriteLine("Numerical values incorrect");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Position number");
                    }
                }
                if (validChar && emptySpace)    
                    {
                        _grid[rowNumber, colNumber].Mark = (charToPlace == 'X') ? TicTacToeMarks.X : TicTacToeMarks.O;
                        break;
                    }

                Console.Write("Re-enter a valid numerical value for the row: ");
                rowNumber =int.Parse(Console.ReadLine());
                Console.Write("Re-Enter a valid numerical value for the col: ");
                colNumber = int.Parse(Console.ReadLine());
            }
        }

        /// <summary>
        /// Validates the specified character to ensure it is either 'X' or 'O' (case insensitive).
        /// </summary>
        /// <param name="checkChar">The character to validate.</param>
        /// <returns>True if the character is 'X' or 'O', false otherwise.</returns>
        public bool ValidateChar (char checkChar )
        {
            char upperCaseLetter= char.ToUpper(checkChar);
            if((upperCaseLetter=='X') || (upperCaseLetter=='O'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the specified position in the grid is empty and within the grid's bounds.
        /// </summary>
        /// <param name="row">The row index of the position to check.</param>
        /// <param name="col">The column index of the position to check.</param>
        /// <returns>True if the position is empty and within the grid's bounds, false otherwise.</returns>
        public bool CheckIfEmpty(int row , int col){
        
            if (_grid[row,col].Mark == TicTacToeMarks.EMPTY)
            {
                return true;
            }
            else if((row >=_grid.GetLength(0)) || (row < 0))
            {
                 return false;
            }
            else if((col >=_grid.GetLength(1))|| (col< 0))
            {
                 return false;
            }
            else{
                return false;
            }
        }

        /// <summary>
        /// This method prints the Grid
        /// </summary>
        public void PrintGrid(){
            for (int i = 0; i < _grid.GetLength(0); i++)
            {
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    Console.Write("| " + _grid[i, j] + " ");
                }
                Console.WriteLine("|");
                Console.WriteLine("-------------");
            }
        }


        /// <summary>
        /// Checks if any row in the grid contains the same mark (X or O) and is not empty.
        /// </summary>
        /// <returns>The winning mark (X or O) if a row contains the same mark, ' ' otherwise.</returns>
       public char CheckRows(){
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            TicTacToeMarks firstToken = _grid[i, 0].Mark; 
            bool rowMatch = true; 
            for (int j = 1; j < _grid.GetLength(1); j++) 
            {
                if ( (_grid[i, j].Mark != firstToken) || (_grid[i, j].Mark == TicTacToeMarks.EMPTY))
                {
                    rowMatch = false; 
                    break;
                }
            }
            if (rowMatch) 
            {
                return (firstToken == TicTacToeMarks.X) ? 'X' : 'O';
            }
        }
        return ' '; 
    }

        /// <summary>
        /// Checks if any column in the grid contains the same mark (X or O) and is not empty.
        /// </summary>
        /// <returns>The winning mark (X or O) if a column contains the same mark, ' ' otherwise.</returns>

        public char CheckColumns()
        {
            for (int i = 0; i < _grid.GetLength(1); i++)
            {
                TicTacToeMarks firstToken = _grid[0, i].Mark;
                bool colMatch = true; 
                for (int j = 1; j < _grid.GetLength(0); j++) 
                {
                    if ((_grid[j, i].Mark != firstToken) || (_grid[j, i].Mark == TicTacToeMarks.EMPTY))
                    {
                        colMatch = false; 
                        break;
                    }
                }
                if (colMatch)
                {
                    return (firstToken == TicTacToeMarks.X) ? 'X' : 'O'; 
                }
            }
            return ' '; 
        }

        /// <summary>
        /// Checks both diagonals of the grid for a winning mark (X or O).
        /// </summary>
        /// <returns>The winning mark (X or O) if a diagonal contains the same mark, ' ' otherwise.</returns>
         public char CheckDiagonals()
         {
           char rightDiagonal= CheckRightDiagonal();
           char leftDiagonal = CheckLeftDiagonal();
           
           if(rightDiagonal!= ' '){
            return rightDiagonal;
           }
           else if (leftDiagonal!= ' '){
            return leftDiagonal;
           }
           else {
            return ' ';
           }
        }

        /// <summary>
        /// Checks the right diagonal of the grid for a winning mark (X or O).
        /// </summary>
        /// <returns>The winning mark (X or O) if the right diagonal contains the same mark, ' ' otherwise.</returns>
      public char CheckRightDiagonal()
    {
        TicTacToeMarks firstToken = _grid[0, 0].Mark; 
        if (firstToken == TicTacToeMarks.EMPTY) 
        {
            return ' '; 
        }
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if ((i == j ) && (_grid[i, j].Mark != firstToken)) 
                {
                    return ' ';
                }
            }
        }
        return (firstToken == TicTacToeMarks.X) ? 'X' : 'O'; 
    }
        
        /// <summary>
        /// Checks the left diagonal of the grid for a winning mark (X or O).
        /// </summary>
        /// <returns>The winning mark (X or O) if the left diagonal contains the same mark, ' ' otherwise.</returns>
       public char CheckLeftDiagonal()
        {
            TicTacToeMarks firstToken = _grid[_grid.GetLength(0) - 1, 0].Mark; 
            if (firstToken == TicTacToeMarks.EMPTY) 
            {
                return ' ';
            }
            for (int i = 1; i < _grid.GetLength(0); i++)
            {
                if (_grid[_grid.GetLength(0) - 1 - i, i].Mark != firstToken) 
                {
                    return ' '; 
                }
            }
            return (firstToken == TicTacToeMarks.X) ? 'X' : 'O'; 
        }

        
        /// <summary>
        /// Checks the entire grid for a winning condition or a tie.
        /// </summary>
        /// <returns>
        /// This method calls other methods that will return 'X' Or 'O' OR 'T'Or ' '
        /// Dpending on who's winning, Tie or Ongoing and return that result.
        /// </returns>
       public char CheckGrid()
       {
            char winnerInRows = CheckRows();
            char winnerInColumns = CheckColumns();
            char winnerInDiagonals = CheckDiagonals();


            if (winnerInRows != ' ')
            {
                return winnerInRows;
            }
            if (winnerInColumns != ' ')
            {
                return winnerInColumns;
            }
            if (winnerInDiagonals != ' ')
            {
                return winnerInDiagonals;
            }

            bool isTie = true;
            for (int i = 0; i < _grid.GetLength(0); i++){
                for (int j = 0; j < _grid.GetLength(1); j++)
                {
                    if (_grid[i, j].Mark == TicTacToeMarks.EMPTY)
                    {
                        isTie = false;
                        break;
                    }
                }
                if (!isTie)
                {
                    Console.WriteLine("!Tie");
                    break;
                }
            }
            if (isTie)
            {
                return 'T';
            }
            return ' ';
        }
    }

    

    /// <summary>
    /// Represents the TicTacToe game
    /// </summary>
    class TicTacToeGame{
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Nihel's TicTacToe Platform Game\n");
            
            TicTacToeGrid gameGrid = new TicTacToeGrid(Convert.ToChar(3));
        
            char currentPlayer = 'X';
            bool gameOver =false;

            while (!gameOver)
            {
                Console.WriteLine($"\nPlayer {currentPlayer}'s turn:");
               
                int row=0;
                int col=0;
                
                bool isNumber =false;
                while(!isNumber)
                try {
                    Console.Write("Enter a numerical value for the row: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter a numerical value for the col: ");
                    col= Convert.ToInt32(Console.ReadLine());
                    isNumber=true;
                } catch (FormatException ex){
                    Console.WriteLine("Numerical values only");
                }

              
                gameGrid.PlaceCharacter(currentPlayer, row, col);
                Console.WriteLine("\n");
                gameGrid.PrintGrid();
              
                string result = gameGrid.Winner;
                Console.WriteLine(result);
            
            if (result != "Ongoing")
            {
                if (result == "Tie")
                {
                    Console.WriteLine("TIE BETWEEN BOTH TEAMS");
                }
                else
                {
                    Console.WriteLine($"Player {result} wins!");
                }
                gameOver = true;
            }

            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }
    }
}
