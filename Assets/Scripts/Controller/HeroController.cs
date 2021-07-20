using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] Warrior heroBase;
    [SerializeField] Joystick joystick;
    [SerializeField] UIButton uiButton;

    [SerializeField] Dummy tempDummy; // 임시로 넣은 것. 얘 있으면 안 된다.

    // Start is called before the first frame update
    void Start()
    {
        joystick.AddListener(heroBase.UpdateAvatarView);
        uiButton.SetActionOnClick((clicked) =>
        {
            heroBase.SetTarget(tempDummy);
            heroBase.EnableMoveToTarget(clicked);
        });
    }


}
