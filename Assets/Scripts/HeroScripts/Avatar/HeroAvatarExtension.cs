using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HeroAvatarExtension 
{
    public static SpriteRenderer XAxisChangedSprite(this SpriteRenderer target)
    {
        target.transform.localScale = target.transform.localScale.Copy(x: target.transform.localScale.x * -1f);
        return target;
    }
}
