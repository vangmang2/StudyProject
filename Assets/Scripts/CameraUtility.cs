using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtility
{
    public static Vector2 ToScreenPos(this Camera target, Vector2 screenSize, Vector2 position)
    {
        var viewportPoint = target.ScreenToViewportPoint(position) - new Vector3(0.5f, 0.5f);
        var worldPoint = new Vector2(viewportPoint.x * screenSize.x, viewportPoint.y * screenSize.y);
        return worldPoint;
    }
}
