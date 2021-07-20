using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WarriorAnimation : HeroAnimaition
{
    Action callback_AttackTrigger;

    public WarriorAnimation SetCallbackAttackTrigger(Action callback)
    {
        callback_AttackTrigger = callback;
        return this;
    }

    public void SetMoveAnim(bool enable)
    {
        SetAnimation("Move", enable);
    }

    public void SetIdleAnim(bool enable)
    {
        SetAnimation("Idle", enable);
    }

    public void SetAttackAnim(bool enable)
    {
        SetAnimation("Attack", enable);
    }

    public void OnTriggerAttack()
    {
        callback_AttackTrigger?.Invoke();
    }
}
