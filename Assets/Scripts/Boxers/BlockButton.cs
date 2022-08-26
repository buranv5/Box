using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action<bool> OnBlockStateChange;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnBlockStateChange?.Invoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnBlockStateChange?.Invoke(false);
    }
}
