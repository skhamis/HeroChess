using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SentinelUnit : MoveableUnit
{
    public override bool[,] PossibleMove()
    {
        
        //Left
        for (int i = CurrentX; Math.Abs(i - CurrentX) <= 3; i--)
        {
            //If there is an object check if there is an enemy there


            //Check left bound
            if (i < 0) break;

            PossibleMoves[i, CurrentZ] = true;
        }

        //Right
        for (int i = CurrentX; Math.Abs(i - CurrentX) <= 3; i++)
        {
            //If there is an object check if there is an enemy there

            //Check right bound
            if (i > 8) break;

            PossibleMoves[i, CurrentZ] = true;
        }
        //Up
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) <= 3; j++)
        {
            //If there is an object check if there is an enemy there

            //Check up bound
            if (j > 4) break;

            PossibleMoves[CurrentX, j] = true;
        }
        //Down
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) <= 3; j--)
        {
            //If there is an object check if there is an enemy there

            //Check down bounds
            if (j < 0) break;

            PossibleMoves[CurrentX, j] = true;
        }

        return PossibleMoves;
    }
}
