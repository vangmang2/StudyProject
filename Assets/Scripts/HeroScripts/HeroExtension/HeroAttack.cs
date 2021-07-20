using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class HeroAttack 
{
    public static void Attack(this HeroBase hero, ITarget target, Action enemyEliminatedCallback)
    {
        if (target == null)
            return;

        target.ReduceHitpoints(hero);
        if (target.hitpoints <= 0f)
            enemyEliminatedCallback();
    }
}
