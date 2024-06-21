namespace Tic_Tac_Toe.Exceptions;

/// <summary>
/// Exception for when a player attempts to place a token in an invalid position.
/// </summary>
public class InvalidTokenPlacementException : Exception
{
    public InvalidTokenPlacementException()
    { }
    
    public InvalidTokenPlacementException(string? message)
        : base(message)
    { }
    
    public InvalidTokenPlacementException(string? message, Exception inner)
        : base(message, inner)
    { }
}