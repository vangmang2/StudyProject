using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget 
{
    float hitpoints { get; }
    Transform pivot { get; }

    void ReduceHitpoints(IDamageCauser causer);
}
