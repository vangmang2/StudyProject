using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroMovement 
{
    // Update에서 호출된다.
    public static void MoveToTarget(this HeroBase hero, ITarget target, float range, out float distance)
    {
        if (target == null)
        {
            distance = 0f;
            return;
        }
        var point = target.pivot.position - hero.pivot.position;
        var deg = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
        distance = point.magnitude;

        hero.UpdateAvatarView(deg);

        if (distance >= range)
        {
            var direction = point.normalized;
            var speed = direction * hero.velocity * Time.deltaTime;

            hero.pivot.position += speed;
        }
        else
        {

        }
    }
}
