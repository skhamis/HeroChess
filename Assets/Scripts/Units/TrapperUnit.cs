using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TrapperUnit : MoveableUnit
{
    private void Start()
    {
        AttackRange = 1;
        MoveRange = 3;
    }

    public override bool[,] PossibleActions()
    {
        return base.PossibleActions();
    }

    public override bool EnemyInAttackRange(int x, int z)
    {
        return base.EnemyInAttackRange(x, z);
    }

    public override void Attack()
    {
        Debug.Log("Trapper Attacked");
    }
}
