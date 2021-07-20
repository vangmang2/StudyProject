using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimaition : MonoBehaviour
{
    [SerializeField] Animator animator;

    public HeroAnimaition SetAnimation(string name, bool value)
    {
        animator.SetBool(name, value);
        return this;
    }
}
