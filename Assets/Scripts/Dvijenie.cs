using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dvijenie : MonoBehaviour //Отвечает за движение картинок по диагонали. Передаётся интерфейс, чтобы хоть где-то сохранить принцип инверсии зависимостей. Заодно может пригодиться для других картинок...
{
    private Canvas canvas;
    private float velocity = 1;
    private Vector2 dvij;
    private ITransfotm item;

    public void AddZnach(Canvas _canvas, ITransfotm _item, float _velocity) // Для инициализации
    {
        canvas = _canvas;
        item = _item;
        velocity = _velocity;
    }

    private void Start() // Начальное направление
    {
        var naprx = Random.Range(0, 1) * 2 - 1;
        var napry = Random.Range(0, 1) * 2 - 1;
        dvij = new Vector2(naprx, napry);
    }

    private void Update() // Само движение
    {
           
         if (item.transforms.x <= 50) { dvij.x = 1; }
         if (item.transforms.y <= 50) { dvij.y = 1; }
         if (item.transforms.x >= canvas.renderingDisplaySize.x - 50) { dvij.x = -1; }
         if (item.transforms.y >= canvas.renderingDisplaySize.y - 50) { dvij.y = -1; }
         item.transforms += dvij * velocity;
            
        
    }
}
