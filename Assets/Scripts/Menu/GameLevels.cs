using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameLevels : MonoBehaviour,IPointerDownHandler 
{
    [SerializeField] TextMeshProUGUI[] gameLevels;

    private void Start()
    {
        foreach (var item in gameLevels)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        foreach (var item in gameLevels)
        {
            item.gameObject.SetActive(true);
        }
    }
}
