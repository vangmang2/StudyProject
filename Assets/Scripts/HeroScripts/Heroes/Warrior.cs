using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : HeroBase
{
    [SerializeField] WarriorAnimation animator;

    ITarget target;
    bool canMove;

    protected override void Init()
    {
        animator.SetIdleAnim(true);
        animator.SetMoveAnim(false);
        animator.SetCallbackAttackTrigger(() =>
        {
            this.Attack(target, () =>
            {
                target = null;
                canMove = false;
            });
        });
    }

    private void Update()
    {
        Move();
    }

    public void SetTarget(ITarget target)
    {
        this.target = target;
    }

    public void Move()
    {
        if (canMove)
        {
            this.MoveToTarget(target, attackableRange, out float deg, out float distance);
            UpdateAvatarView(deg);

            var isTargetAvaliable = target != null;
            var isInRange = distance <= attackableRange;
            var canAttack = isTargetAvaliable && isInRange;

            if (canAttack)
            {
                animator.SetMoveAnim(false);
                animator.SetIdleAnim(false);
                animator.SetAttackAnim(true);
            }
            else
            {
                animator.SetMoveAnim(true);
                animator.SetIdleAnim(false);
                animator.SetAttackAnim(false);
            }
        }
        else
        {
            UpdateAvatarView(-90f);

            animator.SetIdleAnim(true);
            animator.SetMoveAnim(false);
            animator.SetAttackAnim(false);
        }
    }

    public void EnableMoveToTarget(bool enable)
    {
        canMove = enable;
    }
}
