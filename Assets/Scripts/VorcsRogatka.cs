using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// �����, ����������� ����������� ����������� �������� ������. ������ ����� ��������� �� ������ ��������, ������� ����������� ������� ������������ �����������
public class VorcsRogatka : VorcsBase // ����� �����������, � � ���� ���� ���� �����, ������� ������������ ������� ���������� �����������
{
    private Vector3 beginPoint;
    [SerializeField] float length = 100f;
    public UnityEvent<Vector2> onRelease;


    private void Start()
    {
        beginPoint = transform.position;
    }
    protected override void Move()
    {
        if ((beginPoint - Input.mousePosition).magnitude >= length)
        {
            if (clickRet)
            {
                var direct = (Input.mousePosition - beginPoint).normalized * length;
                transform.position = beginPoint + direct;
            }
        }
        else
        base.Move();
    }

    protected override void GoToUp()
    {
        var delta = beginPoint - transform.position;
        transform.position = beginPoint;

        onRelease?.Invoke(delta.normalized * (delta.magnitude / length));
    }
}
