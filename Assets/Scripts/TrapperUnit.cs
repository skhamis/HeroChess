using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TrapperUnit : MoveableUnit
{
    public override bool[,] PossibleMove()
    {
        
        //Left
        for (int i = CurrentX; Math.Abs(i - CurrentX) < 3;)
        {
            i--;

            if (i < 0) break;
            if (UnitManager.Instance.MoveableUnits[i, CurrentZ] != null) break;

            PossibleMoves[i, CurrentZ] = true;
        }

        //Right
        for (int i = CurrentX; Math.Abs(i - CurrentX) < 3;)
        {
            i++;

            if (i > 8) break;
            if (UnitManager.Instance.MoveableUnits[i, CurrentZ] != null) break;

            PossibleMoves[i, CurrentZ] = true;
        }

        //Up
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) < 3;)
        {
            j++;

            if (j > 4) break;
            if (UnitManager.Instance.MoveableUnits[CurrentX, j] != null) break;

            PossibleMoves[CurrentX, j] = true;
        }
        //Down
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) < 3;)
        {
            j--;

            if (j < 0) break;
            if (UnitManager.Instance.MoveableUnits[CurrentX, j] != null) break;

            PossibleMoves[CurrentX, j] = true;
        }

        return PossibleMoves;
    }

    public override bool EnemyInAttackRange(int x, int z)
    {

        if (Math.Abs(CurrentX - x) <= 1 && Math.Abs(CurrentZ - z) <= 1)
        {
            return true;
        }

        return false;
    }

    public override void Attack()
    {
        Debug.Log("Trapper Attacked");
    }
}
