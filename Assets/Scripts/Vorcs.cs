using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Класс, позволяющий реализовать перемещение картинки мышкой. Каждый метод выполняет по одному действию, поэтому соблюдается принцип единственной обязанности
public class Vorcs : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler,IPointerUpHandler, ITransfotm // Много интерфейсов, и у всех лишь один метод, поэтому поддерживает принцип разделения интерфейсов
{
    private bool click = false;
    private Vector2 evOnl = Vector2.zero;
    private Vector2 evOnlPress = Vector2.zero;

    public bool clickRet => click;

    public Vector2 transforms { get => (Vector2)transform.position; set { if (!click) transform.position = (Vector3)value; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
        evOnlPress = eventData.position - (Vector2)transform.position;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        evOnl = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
    }

    private void Update()
    {
        if (click)
        {
            transform.position = (Vector3)(evOnl-evOnlPress);
        }
    }

}
