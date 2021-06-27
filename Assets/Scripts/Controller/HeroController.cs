using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] HeroBase heroBase;
    [SerializeField] Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        joystick.AddListener(heroBase.UpdateAvatarView);
    }
}
