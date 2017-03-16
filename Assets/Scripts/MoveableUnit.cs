using UnityEngine;
using System.Collections;

public abstract class MoveableUnit : MonoBehaviour {

    public int CurrentX { get; set; }
    public int CurrentZ { get; set; }

    public bool[,] PossibleMoves = new bool[9, 5];

    public void SetPosition(int x, int z)
    {
        CurrentX = x;
        CurrentZ = z;

        PossibleMoves = new bool[9,5];
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[9,5];
    }

    public virtual bool EnemyInAttackRange(int x, int z)
    {
        return false;
    }

    public virtual void Attack()
    {
        Debug.Log("MoveableUnit: Attacked Enemy");
    }
}
