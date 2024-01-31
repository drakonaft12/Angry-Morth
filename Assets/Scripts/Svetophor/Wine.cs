using DG.Tweening;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class Wine : MonoBehaviour // �����, ������������ ������� ������ � � ���������
{
    [SerializeField] VorcsBase vorsRed, vorsGreen, vorsYelou;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] MenuBase Menu; // ������������ ������� ����������� ������, ��� ��� � MenuBase - ����������� ����� � ���� ��������� ��� ������� Menu
    bool Work = true;
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
        if (Work)
        {
            var rasnRedX = Mathf.Abs(vorsYelou.transform.position.x - vorsRed.transform.position.x);
            var rasnGreenX = Mathf.Abs(vorsYelou.transform.position.x - vorsGreen.transform.position.x);

            var rasnRedY = vorsYelou.transform.position.y < vorsRed.transform.position.y;
            var rasnGreenY = vorsYelou.transform.position.y > vorsGreen.transform.position.y;

            var clickoff = !vorsRed.clickRet && !vorsGreen.clickRet && !vorsYelou.clickRet;
            if (rasnRedX < tochnost && rasnGreenX < tochnost && rasnRedY && rasnGreenY && clickoff)
            {
                textMeshPro.text = "�� �������, ����������!!!";
                ResetMenu();
            }
        }
    }


    private async void ResetMenu()
    {
        await Task.Delay(3000);
        Menu.StartScene("Menu");
    }
    
}

