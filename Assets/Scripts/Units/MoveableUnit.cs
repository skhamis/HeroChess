using System;
using UnityEngine;

public abstract class MoveableUnit : MonoBehaviour {

    public int CurrentX { get; set; }
    public int CurrentZ { get; set; }

    public int AttackRange { get; set; }
    public int MoveRange { get; set; }

    public bool[,] PossibleAction = new bool[(int)Constants.GridSize.x, (int)Constants.GridSize.y];

    public void SetPosition(int x, int z)
    {
        CurrentX = x;
        CurrentZ = z;

        //Reset previous possible actions
        PossibleAction = new bool[(int)Constants.GridSize.x, (int)Constants.GridSize.y];
    }

    public virtual bool[,] PossibleActions()
    {
        //Left
        for (int i = CurrentX; Math.Abs(i - CurrentX) < MoveRange;)
        {
            i--;

            if (i < 0) break;
            if (UnitManager.Instance.MoveableUnits[i, CurrentZ] != null)
            {
                if (UnitManager.Instance.MoveableUnits[i, CurrentZ].tag == Constants.EnemyUnitTag)
                {
                    PossibleAction[i, CurrentZ] = EnemyInAttackRange(i, CurrentZ);
                }

            }
            else
            {
                PossibleAction[i, CurrentZ] = true;
            }

        }

        //Right
        for (int i = CurrentX; Math.Abs(i - CurrentX) < MoveRange;)
        {
            i++;

            if (i >= Constants.GridSize.x) break;
            if (UnitManager.Instance.MoveableUnits[i, CurrentZ] != null)
            {
                if (UnitManager.Instance.MoveableUnits[i, CurrentZ].tag == Constants.EnemyUnitTag)
                {
                    PossibleAction[i, CurrentZ] = EnemyInAttackRange(i, CurrentZ);
                }

            }
            else
            {
                PossibleAction[i, CurrentZ] = true;
            }
        }

        //Up
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) < MoveRange;)
        {
            j++;

            if (j >= Constants.GridSize.y) break;
            if (UnitManager.Instance.MoveableUnits[CurrentX, j] != null)
            {
                if (UnitManager.Instance.MoveableUnits[CurrentX, j].tag == Constants.EnemyUnitTag)
                {
                    PossibleAction[CurrentX, j] = EnemyInAttackRange(CurrentX, j);
                }
            }
            else
            {
                PossibleAction[CurrentX, j] = true;
            }

        }
        //Down
        for (int j = CurrentZ; Math.Abs(j - CurrentZ) < MoveRange;)
        {
            j--;

            if (j < 0) break;

            if (UnitManager.Instance.MoveableUnits[CurrentX, j] != null)
            {
                if (UnitManager.Instance.MoveableUnits[CurrentX, j].tag == Constants.EnemyUnitTag)
                {
                    PossibleAction[CurrentX, j] = EnemyInAttackRange(CurrentX, j);
                }
            }
            else
            {
                PossibleAction[CurrentX, j] = true;
            }
        }

        return PossibleAction;
    }

    public virtual bool EnemyInAttackRange(int x, int z)
    {
        if (Math.Abs(CurrentX - x) <= AttackRange && Math.Abs(CurrentZ - z) <= AttackRange)
        {
            return true;
        }

        return false;
    }

    public virtual void Attack()
    {
        Debug.Log("MoveableUnit: Attacked Enemy");
    }
}
