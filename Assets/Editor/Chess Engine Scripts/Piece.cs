using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    private List<Location> possibleMoves;
    private string name;
    private bool isDead;
    private Location currLoc;
    private string color;

    public Piece(string name)
    {
        this.name = name;
        possibleMoves = new List<Location>();
        isDead = false;
        currLoc = BaseLoc.assignBaseLoc(name);

        if (name.Contains("white"))
            color = "white";
        else
            color = "black";
    }

    public List<Location> getPossibleMoves()
    {
        return possibleMoves;
    }

    //Possibly add boardState argument as well
    public void updatePossibleMoves(Location myLoc, string myName, Location[][] board)
    {
        this.possibleMoves.Clear();
        //TODO: Add checks for other pieces
        if (myName.Contains("knight"))
        {
            getKnightMoves(myLoc, board);
        }
    }

    public void getKnightMoves(Location myLoc, Location[][] board)
    {
        int row = myLoc.getRow();
        int col = myLoc.getColumn();
        Piece pieceOnSpot;

        if (col - 2 >= 0)
        {
            if (row - 1 >= 0)
            {
                pieceOnSpot = board[row - 1][col - 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row - 1, col - 2));
                }
            }
            if (row + 1 <= 7)
            {
                pieceOnSpot = board[row + 1][col - 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row + 1, col - 2));
                }
            }
        }
        if (col - 1 >= 0)
        {
            if (row - 2 >= 0)
            {
                pieceOnSpot = board[row - 2][col - 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row - 2, col - 1));
                }
            }
            if (row + 2 <= 7)
            {
                pieceOnSpot = board[row + 2][col - 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row + 2, col - 1));
                }
            }
        }
        if (col + 1 <= 7)
        {
            if (row - 2 >= 0)
            {
                pieceOnSpot = board[row - 2][col + 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row - 2, col + 1));
                }
            }
            if (row + 2 <= 7)
            {
                pieceOnSpot = board[row + 2][col + 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row + 2, col + 1));
                }
            }
        }
        if (col + 2 <= 7)
        {
            if (row - 1 >= 0)
            {
                pieceOnSpot = board[row - 1][col + 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row - 1, col + 2));
                }
            }
            if (row + 1 <= 7)
            {
                pieceOnSpot = board[row + 1][col + 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.color.Equals(this.color))
                {
                    possibleMoves.Add(new Location(row + 1, col + 2));
                }
            }
        }
    }
}
