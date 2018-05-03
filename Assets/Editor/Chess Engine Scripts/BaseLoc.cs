using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLoc {
    private enum Columns
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7
    }

    public static Location assignBaseLoc(string name)
    {
        switch (name)
        {
            case "white_a_pawn":
                return new Location(1, (int)Columns.A);
            case "white_b_pawn":
                return new Location(1, (int)Columns.B);
            case "white_c_pawn":
                return new Location(1, (int)Columns.C);
            case "white_d_pawn":
                return new Location(1, (int)Columns.D);
            case "white_e_pawn":
                return new Location(1, (int)Columns.E);
            case "white_f_pawn":
                return new Location(1, (int)Columns.F);
            case "white_g_pawn":
                return new Location(1, (int)Columns.G);
            case "white_h_pawn":
                return new Location(1, (int)Columns.H);
            case "white_rook0":
                return new Location(0, (int)Columns.A);
            case "white_knight0":
                return new Location(0, (int)Columns.B);
            case "white_bishop0":
                return new Location(0, (int)Columns.C);
            case "white_queen":
                return new Location(0, (int)Columns.D);
            case "white_king":
                return new Location(0, (int)Columns.E);
            case "white_bishop1":
                return new Location(0, (int)Columns.F);
            case "white_knight1":
                return new Location(0, (int)Columns.G);
            case "white_rook1":
                return new Location(0, (int)Columns.H);
            case "black_a_pawn":
                return new Location(6, (int)Columns.A);
            case "black_b_pawn":
                return new Location(6, (int)Columns.B);
            case "black_c_pawn":
                return new Location(6, (int)Columns.C);
            case "black_d_pawn":
                return new Location(6, (int)Columns.D);
            case "black_e_pawn":
                return new Location(6, (int)Columns.E);
            case "black_f_pawn":
                return new Location(6, (int)Columns.F);
            case "black_g_pawn":
                return new Location(6, (int)Columns.G);
            case "black_h_pawn":
                return new Location(6, (int)Columns.H);
            case "black_rook0":
                return new Location(7, (int)Columns.A);
            case "black_knight0":
                return new Location(7, (int)Columns.B);
            case "black_bishop0":
                return new Location(7, (int)Columns.C);
            case "black_queen":
                return new Location(7, (int)Columns.D);
            case "black_king":
                return new Location(7, (int)Columns.E);
            case "black_bishop1":
                return new Location(7, (int)Columns.F);
            case "black_knight1":
                return new Location(7, (int)Columns.G);
            case "black_rook1":
                return new Location(7, (int)Columns.H);
            default:
                return null;
        }
    }
}
