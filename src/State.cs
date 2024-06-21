namespace Tic_Tac_Toe;

public enum GameResult { XWins, OWins, Draw }

public class State(ref Board board)
{
    private readonly Board _board = board;

    /// <summary>
    /// Determines the result of a game.
    /// </summary>
    /// <returns>The result if one is found, null if no result is available</returns>
    public GameResult? CheckResult()
    {
        // check the winning combinations and return the winning player if one was found.
        // if a winning row is found, because all 3 have to be the same for a win to occur,
        // we can check the Token in the first index to determine the winner.
        
        if (IsWinningRow(6, 7, 8)) // top row
            return (_board.Square[6] is Mark.X) ? GameResult.XWins : GameResult.OWins;
        
        if (IsWinningRow(3, 4, 5)) // middle row
            return (_board.Square[3] is Mark.X) ? GameResult.XWins : GameResult.OWins;
        
        if (IsWinningRow(0, 1, 2)) // bottom row
            return (_board.Square[0] is Mark.X) ? GameResult.XWins : GameResult.OWins;

        if (IsWinningRow(6, 3, 0)) // left column
            return (_board.Square[6] is Mark.X) ? GameResult.XWins : GameResult.OWins;

        if (IsWinningRow(7, 4, 1)) // center column
            return (_board.Square[7] is Mark.X) ? GameResult.XWins : GameResult.OWins;

        if (IsWinningRow(8, 5, 2)) // right column
            return (_board.Square[8] is Mark.X) ? GameResult.XWins : GameResult.OWins;

        if (IsWinningRow(6, 4, 2)) // top-left to bottom-right diagonal
            return (_board.Square[6] is Mark.X) ? GameResult.XWins : GameResult.OWins;

        if (IsWinningRow(8, 4, 0)) // top-right to bottom-left diagonal
            return (_board.Square[8] is Mark.X) ? GameResult.XWins : GameResult.OWins;
        
        // if no winner was determined, we need to check if a draw has occurred,
        // if any of the slots on the board are still empty then no result can be determined.
        if (_board.Square.Any(t => t == null)) return null;

        // at this point we know there is no winner and no open slots, the game must be a draw.
        return GameResult.Draw;
    }
    
    /// <summary>
    /// Determine if the given indexes form a winning row, which is true if they are all
    /// equal to one another and not null.
    /// </summary>
    /// <returns>true if winning row is found and false otherwise</returns>
    private bool IsWinningRow(int i, int j, int k)
    {
        // Only a single slot needs to be checked for null since the next will check if they are all equal.
        if (_board.Square[i] == null) return false;
        
        // return whether a winning row has been found.
        return _board.Square[i] == _board.Square[j] && _board.Square[j] == _board.Square[k];
    }
}
