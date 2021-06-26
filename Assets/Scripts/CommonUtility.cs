using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonUtility 
{
    public static Vector2 Copy(this Vector2 v, float? x = null, float? y = null)
        => new Vector2(x ?? v.x, y ?? v.y);

    public static Vector3 Copy(this Vector3 v, float? x = null, float? y = null, float? z = null)
        => new Vector3(x ?? v.x, y ?? v.y, z ?? v.z);
}
