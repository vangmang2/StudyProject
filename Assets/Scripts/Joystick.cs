using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour,
                        IDragHandler,
                        IEndDragHandler
{
    [SerializeField] Camera uiCamera;
    [SerializeField] RectTransform rtPivot, rtStick;

    event Action<float, float> onDragAction;

    public void AddListener(Action<float, float> dragCallback)
    {
        onDragAction += dragCallback;
    }

    public void RemoveListner(Action<float, float> dragCallback)
    {
        onDragAction -= dragCallback;
    }

    float radius => rtPivot.sizeDelta.x * 0.35f;
    Vector2 screenSize => new Vector2(Screen.width, Screen.height);

    public void OnDrag(PointerEventData eventData)
    {
        var eventPos = uiCamera.ToScreenPos(screenSize, eventData.position);
        var point = eventPos - (Vector2)rtPivot.localPosition;
        var deg = Mathf.Atan2(point.y, point.x);
        var dist = Mathf.Min(point.magnitude, radius);
        var pos = new Vector2(Mathf.Cos(deg), Mathf.Sin(deg)) * dist;

        rtStick.anchoredPosition = pos;
        onDragAction?.Invoke(deg * Mathf.Rad2Deg, dist / radius);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rtStick.anchoredPosition = Vector2.zero;
    }
}
