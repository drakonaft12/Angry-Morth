using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlojnostBase : MonoBehaviour
{
    //����������� ����� ��� ���������� �������� ����� ������� � �������� ��� ��������� ������� ���������

    protected const string key = "dificlt";

    protected abstract void UrowniSlojn();

    private void Start()
    {
        UrowniSlojn();
    }


    public int dificlt { get => PlayerPrefs.GetInt(key, 0); set { PlayerPrefs.SetInt(key, value); } }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(key, 0);
    }
}
