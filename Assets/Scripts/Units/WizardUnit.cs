using UnityEngine;
using System.Collections;
using System;

public class WizardUnit : MoveableUnit {


    private void Start()
    {
        AttackRange = 2;
        MoveRange = 2;
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
        Debug.Log("Wizard Attacked");
    }
}
