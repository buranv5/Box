using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerControll player;

    public void OnPointerDown(PointerEventData eventData)
    {
        player.ChangeBlockState(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.ChangeBlockState(false);
    }
}
