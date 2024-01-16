using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuStart : MenuBase, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        StartScene("SampleScene");
    }

}
