using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCalculator {
    private static bool isNull;

    public static List<Location> getPossibleMoves(Piece piece)
    {
        //Dummy board
        Location[][] myBoard = new Location[8][];

        string name = piece.getName();

        if (name.Contains("knight"))
        {
            return getKnightMoves(piece, myBoard);
        }
        else if (name.Contains("king"))
        {
            return getKingMoves(piece, myBoard);
        }
        else if (name.Contains("queen"))
        {
            return getQueenMoves(piece, myBoard);
        }
        else if (name.Contains("rook"))
        {
            return getRookMoves(piece, myBoard);
        }
        else if (name.Contains("bishop"))
        {
            return getBishopMoves(piece, myBoard);
        }
        else if (name.Contains("pawn"))
        {
            return getPawnMoves(piece, myBoard);
        }
        else
        {
            return null;
        }
    }

    //========================== Calculate moves for Pieces =========================

    public static List<Location> getKnightMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = new List<Location>();
        int row = piece.getCurrentLocation().getRow();
        int col = piece.getCurrentLocation().getColumn();
        Piece pieceOnSpot;
        string color = piece.getColor();

        if (col - 2 >= 0)
        {
            if (row - 1 >= 0)
            {
                pieceOnSpot = board[row - 1][col - 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
                {
                    possibleMoves.Add(new Location(row - 1, col - 2));
                }
            }
            if (row + 1 <= 7)
            {
                pieceOnSpot = board[row + 1][col - 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
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
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
                {
                    possibleMoves.Add(new Location(row - 2, col - 1));
                }
            }
            if (row + 2 <= 7)
            {
                pieceOnSpot = board[row + 2][col - 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
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
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
                {
                    possibleMoves.Add(new Location(row - 2, col + 1));
                }
            }
            if (row + 2 <= 7)
            {
                pieceOnSpot = board[row + 2][col + 1].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
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
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
                {
                    possibleMoves.Add(new Location(row - 1, col + 2));
                }
            }
            if (row + 1 <= 7)
            {
                pieceOnSpot = board[row + 1][col + 2].getPieceOnSpot();
                if (pieceOnSpot == null || !pieceOnSpot.getColor().Equals(color))
                {
                    possibleMoves.Add(new Location(row + 1, col + 2));
                }
            }
        }
        return possibleMoves;
    }

    public static List<Location> getPawnMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = new List<Location>();
        int row = piece.getCurrentLocation().getRow();
        int col = piece.getCurrentLocation().getColumn();

        Piece pieceOnSpot = board[row + 1][col - 1].getPieceOnSpot();
        if (pieceOnSpot != null && !pieceOnSpot.getColor().Equals(piece.getColor()))
        {
            possibleMoves.Add(board[row + 1][col - 1]);
        }

        pieceOnSpot = board[row + 1][col].getPieceOnSpot();
        if (pieceOnSpot == null)
        {
            possibleMoves.Add(board[row + 1][col]);
        }

        pieceOnSpot = board[row + 1][col + 1].getPieceOnSpot();
        if (pieceOnSpot != null && !pieceOnSpot.getColor().Equals(piece.getColor()))
        {
            possibleMoves.Add(board[row + 1][col + 1]);
        }

        return possibleMoves;
    }

    public static List<Location> getRookMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = new List<Location>();
        int row = piece.getCurrentLocation().getRow();
        int col = piece.getCurrentLocation().getColumn();

        int currCol = col;
        int currRow = row;
        while (currCol >= 0)
        {
            if (checkWest(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol--;
        }

        currCol = col;
        currRow = row;
        while (currCol <= 7)
        {
            if (checkEast(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol++;
        }

        currCol = col;
        currRow = row;
        while (currRow >= 0)
        {
            if (checkSouth(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currRow--;
        }

        currCol = col;
        currRow = row;
        while (currRow <= 7)
        {
            if (checkNorth(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currRow++;
        }

        return possibleMoves;
    }

    public static List<Location> getBishopMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = new List<Location>();
        int row = piece.getCurrentLocation().getRow();
        int col = piece.getCurrentLocation().getColumn();

        int currCol = col;
        int currRow = row;
        while (currCol >= 0 && currRow <= 7)
        {
            if (checkNW(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol--;
            currRow++;
        }

        currCol = col;
        currRow = row;
        while (currCol >= 0 && currRow >= 0)
        {
            if (checkSW(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol--;
            currRow--;
        }

        currCol = col;
        currRow = row;
        while (currCol <= 7 && currRow >= 0)
        {
            if (checkSE(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol++;
            currRow--;
        }

        currCol = col;
        currRow = row;
        while (currCol <= 7 && currRow <= 7)
        {
            if (checkNE(currRow, currCol, piece, board))
            {
                possibleMoves.Add(board[currRow][currCol]);
                if (!isNull)
                    break;
            }
            else
            {
                break;
            }
            currCol++;
            currRow++;
        }

        return possibleMoves;
    }

    public static List<Location> getQueenMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = getRookMoves(piece, board);
        possibleMoves.AddRange(getBishopMoves(piece, board));
        return possibleMoves;
    }

    public static List<Location> getKingMoves(Piece piece, Location[][] board)
    {
        List<Location> possibleMoves = new List<Location>();
        int row = piece.getCurrentLocation().getRow();
        int col = piece.getCurrentLocation().getColumn();

        if (checkNorth(row, col, piece, board))
        {
            possibleMoves.Add(board[row+1][col]);
        }
        if (checkNE(row, col, piece, board))
        {
            possibleMoves.Add(board[row+1][col+1]);
        }
        if (checkEast(row, col, piece, board))
        {
            possibleMoves.Add(board[row][col+1]);
        }
        if (checkSE(row, col, piece, board))
        {
            possibleMoves.Add(board[row-1][col+1]);
        }
        if (checkSouth(row, col, piece, board))
        {
            possibleMoves.Add(board[row-1][col]);
        }
        if (checkSW(row, col, piece, board))
        {
            possibleMoves.Add(board[row-1][col-1]);
        }
        if (checkWest(row, col, piece, board))
        {
            possibleMoves.Add(board[row][col-1]);
        }
        if (checkNW(row, col, piece, board))
        {
            possibleMoves.Add(board[row+1][col-1]);
        }

        return possibleMoves;
    }

    //========================= Direction Checks ====================================

    public static bool checkNorth(int row, int col, Piece myPiece, Location[][] board)
    {
        Piece pieceOnSpot;
        if (row + 1 <= 7)
        {
            pieceOnSpot = board[row + 1][col].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkEast(int row, int col, Piece myPiece, Location[][] board) {
        Piece pieceOnSpot;
        if (col + 1 <= 7)
        {
            pieceOnSpot = board[row][col + 1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkSouth(int row, int col, Piece myPiece, Location[][] board) {
        Piece pieceOnSpot;
        if (row - 1 >= 0)
        {
            pieceOnSpot = board[row - 1][col].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkWest(int row, int col, Piece myPiece, Location[][] board) {
        Piece pieceOnSpot;
        if (col - 1 >= 0)
        {
            pieceOnSpot = board[row][col-1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkNW(int row, int col, Piece myPiece, Location[][] board) {
        Piece pieceOnSpot;
        if (col - 1 >= 0 && row + 1 <= 7)
        {
            pieceOnSpot = board[row + 1][col - 1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkNE(int row, int col, Piece myPiece, Location[][] board)
    {
        Piece pieceOnSpot;
        if (col + 1 <= 7 && row + 1 <= 7)
        {
            pieceOnSpot = board[row + 1][col + 1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkSE(int row, int col, Piece myPiece, Location[][] board)
    {
        Piece pieceOnSpot;
        if (col + 1 <= 7 && row - 1 >= 0)
        {
            pieceOnSpot = board[row - 1][col + 1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }

    public static bool checkSW(int row, int col, Piece myPiece, Location[][] board)
    {
        Piece pieceOnSpot;
        if (col - 1 >= 0 && row - 1 >= 0)
        {
            pieceOnSpot = board[row - 1][col - 1].getPieceOnSpot();
            if (pieceOnSpot == null)
            {
                isNull = true;
                return true;
            }
            else if (!pieceOnSpot.getColor().Equals(myPiece.getColor()))
            {
                isNull = false;
                return true;
            }
        }
        return false;
    }
}
