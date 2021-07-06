using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour, ITarget
{
    [SerializeField] Transform trBody;
    public Transform pivot => trBody;

    public float hitpoints { get; private set; }


    void Start()
    {
        hitpoints = 100f;
    }

    public Dummy SetPosition(Vector3 position)
    {
        trBody.position = position;
        return this;
    }

    public void ActivateDummy()
    {
        gameObject.SetActive(true);
        hitpoints = 100f;
    }

    public void ReduceHitpoints(IDamageCauser causer)
    {
        hitpoints -= causer.damage;
        if (hitpoints <= 0)
            DestoryDummy();
    }

    public void DestoryDummy()
    {
        gameObject.SetActive(false);
    }
}
