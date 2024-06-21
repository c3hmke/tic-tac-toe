using Tic_Tac_Toe;
using Tic_Tac_Toe.Exceptions;

// Initialize the game objects
var board    = new Board();
var state    = new State(ref board);
var graphics = new Graphics(ref board);

GameResult? result  = null;     // the game starts with no result determined.
Mark currentPlayer = Mark.X;    // the player using X will start the game.

// initialize the game loop
while (result is null)
{
    // clear the console and draw the game board
    Console.Clear();
    graphics.DrawBoard();
    
    // "subroutine" to get the player input
    Console.Write($"Player {currentPlayer}, where do you want to place your mark? ");
    while (true)
    {
        try
        {
            uint.TryParse(Console.ReadLine()!, out uint targetSquare);

            if (targetSquare is < 1 or > 9)
            {
                Console.Write("Please enter the numeric value of the square you want to place your mark in: ");
                continue; // keep asking till we receive valid input
            }

            board.PlaceMark((targetSquare - 1), currentPlayer);
            break; // once the mark has been placed we can break from this loop
        }
        catch (InvalidTokenPlacementException e) { Console.Write("Please select a square which contains no marks: "); }
        catch (Exception e) { /* do nothing so we keep querying input */ }
    }
    
    // update the result if an outcome has occurred, if not then switch to the next player.
    result = state.CheckResult();
    currentPlayer = (currentPlayer is Mark.X) ? Mark.O : Mark.X;
}
// the game has ended

// clear the console, show the final board state and display which player won.
Console.Clear();
graphics.DrawBoard();
graphics.PrintResultMessage(result);
