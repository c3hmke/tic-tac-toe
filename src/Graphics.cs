using System.Diagnostics;
using System.Drawing;
using Pastel;

namespace Tic_Tac_Toe;

public class Graphics(ref Board board)
{
    private readonly Board _board = board;
    
    private static readonly Color BgColor = Color.DimGray;
    private static readonly Color XColor  = Color.Aqua;
    private static readonly Color OColor  = Color.Coral;
    
    
    /// <summary>
    /// Draw the game board to the console, using the colors defines above for visual pizzazz.
    /// </summary>
    public void DrawBoard()
    {
        DrawSpace(6); DrawBg("|"); DrawSpace(7); DrawBg("|"); DrawSpace(8); Console.WriteLine();
        DrawBg("---+---+---");                                                Console.WriteLine();
        DrawSpace(3); DrawBg("|"); DrawSpace(4); DrawBg("|"); DrawSpace(5); Console.WriteLine();
        DrawBg("---+---+---");                                                Console.WriteLine();
        DrawSpace(0); DrawBg("|"); DrawSpace(1); DrawBg("|"); DrawSpace(2); Console.WriteLine();
    }

    /// <summary>
    /// Print the given result to the console.
    /// </summary>
    /// <param name="result">The GameResult to print, or null if no result is present</param>
    public void PrintResultMessage(GameResult? result)
    {
        switch (result)
        {
            case GameResult.XWins: Console.WriteLine("Player X has won!"); break;
            case GameResult.OWins: Console.WriteLine("Player O has won!"); break;
            case GameResult.Draw:  Console.WriteLine("The game has ended in a draw..."); break;
            
            default: Console.WriteLine("No result has been determined."); break;
        }
    }

    /// <summary>
    /// Draws a space on the board and places the appropriate <see cref="Mark"/> in that space
    /// if one is present, otherwise will draw the index as a background element as a 'user hint'
    /// for which key to use to occupy that space.
    /// </summary>
    /// <param name="index">which space of the board to draw</param>
    private void DrawSpace(int index)
    {
        // Print the correct token to the space and jazz it up.
        switch (_board.Square[index])
        {
            case Mark.X:
                Console.Write($" {_board.Square[index].ToString()} ".Pastel(XColor));
                break;
            
            case Mark.O:
                Console.Write($" {_board.Square[index].ToString()} ".Pastel(OColor));
                break;
            
            // for the fallthrough, print the number in the space to indicate the required
            // input to occupy that spaces
            default:
                Console.Write($" {index + 1} ".Pastel(BgColor));
                break;
        }
    }

    /// <summary>
    /// Draw background elements to the game board using <see cref="BgColor"/>
    /// to make the elements pop less.
    /// </summary>
    /// <param name="output">Will be output to the console.</param>
    private static void DrawBg(string output)
    {
        Console.Write(output.Pastel(BgColor));
    }
}