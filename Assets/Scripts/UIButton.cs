using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIButton : MonoBehaviour
{
    Action<bool> onClick;
    bool mClicked;

    public UIButton SetActionOnClick(Action<bool> callback)
    {
        onClick = callback;
        return this;
    }

    public void OnClick()
    {
        mClicked = !mClicked;
        onClick?.Invoke(mClicked);
    }
}
