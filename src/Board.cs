using Tic_Tac_Toe.Exceptions;

namespace Tic_Tac_Toe;


/// <summary>
/// The tokens players may place on the board, either 'O' (naughts) or 'X' (crosses).
/// </summary>
public enum Mark { X, O }

/// <summary>
/// Represents the board of a game of Tic-Tac-Toe (or Naughts & Crosses).
/// Here the board remains agnostic of play patterns or victory conditions and concerns itself
/// only with the state of the board and that said state remains valid. This is done so that the
/// play patterns or victory conditions may be altered independent of the board itself.
/// </summary>
public class Board
{
    /// <summary>
    ///  7 | 8 | 9      The play area consists of 9 spaces which may contain a token of 'X' or 'O'. 
    /// ---+---+---     It should be initialised to contain no tokens so that players may place their
    ///  4 | 5 | 6      tokens on the board.
    /// ---+---+---     The diagram to the left show the correlating indexes for the containing array,
    ///  1 | 2 | 3      which are based on the numpad of a keyboard for simplified input.
    /// </summary>
    public Mark?[] Square { get; } = new Mark?[9];

    public void PlaceMark(uint index, Mark mark)
    {
        // check if the space is valid before allowing a player to place their token there
        if (Square[index] != null) throw new InvalidTokenPlacementException();
        
        // if so, allow them to place their token
        Square[index] = mark;
    }
}