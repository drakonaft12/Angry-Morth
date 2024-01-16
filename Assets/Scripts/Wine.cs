using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using System;
using System.Threading;

public class Wine : MonoBehaviour // Класс, определяющий условия победы и её результат
{
    [SerializeField] Vorcs vorsRed, vorsGreen, vorsYelou;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] MenuBase Menu; // Поддерживает принцип подстановки Лисков, так как в MenuBase - абстрактный класс и сюда передаётся его потомок Menu
    bool Work = true, ret = false;
    float tochnost = 10f;


    private void Start()
    {
        if(vorsRed == null || vorsGreen == null || vorsYelou == null)
        {
            Work = false;
            textMeshPro.text = "Dont work, stupid!";
        }
    }

    private void Update()
    {
        if (ret)
        {
            StartCoroutine(ResetMenu());
        }
        if (Work)
        {
            var rasnRedX = Mathf.Abs(vorsYelou.transform.position.x - vorsRed.transform.position.x);
            var rasnGreenX = Mathf.Abs(vorsYelou.transform.position.x - vorsGreen.transform.position.x);

            var rasnRedY = vorsYelou.transform.position.y < vorsRed.transform.position.y;
            var rasnGreenY = vorsYelou.transform.position.y > vorsGreen.transform.position.y;

            var clickoff = !vorsRed.clickRet && !vorsGreen.clickRet && !vorsYelou.clickRet;
            if (rasnRedX < tochnost && rasnGreenX < tochnost && rasnRedY && rasnGreenY && clickoff)
            {
                textMeshPro.text = "Ты победил, поздравляю!!!";
                ret = true;
            }
        }
    }

    private IEnumerator ResetMenu()
    {
        Thread.Sleep(5000);
        Menu.StartScene("Menu");
        yield return 1;
    }
}

