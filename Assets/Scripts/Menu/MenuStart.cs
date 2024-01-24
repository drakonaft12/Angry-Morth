using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuStart : MenuBase, IPointerDownHandler
{
    [SerializeField] SceneAsset scene;
    public void OnPointerDown(PointerEventData eventData)
    {
        
        StartScene(scene.name);
    }

}
