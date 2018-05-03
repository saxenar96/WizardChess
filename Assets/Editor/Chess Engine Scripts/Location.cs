using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {
    private int row;
    private int column;
    private Piece pieceOnSpot;

    public Location(int row, int column)
    {
        this.row = row;
        this.column = column;
        pieceOnSpot = null;
    }

    public int getRow()
    {
        return row;
    }

    public int getColumn()
    {
        return column;
    }

    public void setPieceOnSpot(Piece piece)
    {
        this.pieceOnSpot = piece;
    }

    public Piece getPieceOnSpot()
    {
        return pieceOnSpot;
    }
}
