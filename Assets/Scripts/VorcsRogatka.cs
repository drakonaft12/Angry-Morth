using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// �����, ����������� ����������� ����������� �������� ������. ������ ����� ��������� �� ������ ��������, ������� ����������� ������� ������������ �����������
public class VorcsRogatka : VorcsBase // ����� �����������, � � ���� ���� ���� �����, ������� ������������ ������� ���������� �����������
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
