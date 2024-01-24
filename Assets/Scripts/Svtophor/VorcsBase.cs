using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �����, ����������� ����������� ����������� �������� ������. ������ ����� ��������� �� ������ ��������, ������� ����������� ������� ������������ �����������
public abstract class VorcsBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, ITransfotm // ����� �����������, � � ���� ���� ���� �����, ������� ������������ ������� ���������� �����������
{
    private bool click = false;
    private Vector2 evOnlPress = Vector2.zero;

    public Vector2 evPress => evOnlPress;
    public bool clickRet => click;

    public Vector2 transforms { get => (Vector2)transform.position; set { if (!click) transform.position = (Vector3)value; } }

    public void OnPointerDown(PointerEventData eventData)
    {
        click = true;
        evOnlPress = eventData.position - (Vector2)transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        click = false;
        GoToUp();
    }

    protected abstract void GoToUp();

    private void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (click)
        {
            transform.position = (Vector2)(Input.mousePosition) - evOnlPress;
        }
    }

}
