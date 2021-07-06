using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Random = UnityEngine.Random;

public class DummySpawner : MonoBehaviour
{
    [SerializeField] Dummy dummy;
    IDisposable disposable;

    private void Start()
    {
        disposable = this.ObserveEveryValueChanged(spawner => spawner.dummy.hitpoints)
                         .Where(hitpoints => hitpoints <= 0)
                         .Subscribe((x) =>
                         {
                             dummy.SetPosition(new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(- 4f, 4f)))
                                  .ActivateDummy();
                         });
    }

    private void OnDestroy()
    {
        disposable.Dispose();
    }
}
