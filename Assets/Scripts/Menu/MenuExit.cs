using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuExit : MenuBase, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        ExitGame();
    }

}
