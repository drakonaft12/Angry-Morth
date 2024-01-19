using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// Класс, позволяющий реализовать перемещение картинки мышкой. Каждый метод выполняет по одному действию, поэтому соблюдается принцип единственной обязанности
public class VorcsRogatka : VorcsBase // Много интерфейсов, и у всех лишь один метод, поэтому поддерживает принцип разделения интерфейсов
{
    private Vector3 beginPoint;

    private void Start()
    {
        beginPoint = transform.position;
    }
    protected override void Move()
    {
        base.Move();

    }

    protected override void GoToUp()
    {
        Debug.Log((beginPoint - transform.position).magnitude);
        transform.position = beginPoint;
    }
}
