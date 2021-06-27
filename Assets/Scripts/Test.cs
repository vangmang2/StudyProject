using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            joystick.AddListener(HandleJoystick);
        else if (Input.GetKeyDown(KeyCode.W))
            joystick.RemoveListner(HandleJoystick);
    }

    private void HandleJoystick(float deg, float dist)
    {
        Debug.Log($"Listen {deg} {dist}");
    }
}
