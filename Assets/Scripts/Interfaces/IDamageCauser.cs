using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageCauser 
{
    float damage { get; }
    float attackableRange { get; }
}
