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
        MoveCalculator.getPossibleMoves(this);
    }

    public string getName()
    {
        return this.name;
    }

    public Location getCurrentLocation()
    {
        return currLoc;
    }

    public string getColor()
    {
        return color;
    }
}
