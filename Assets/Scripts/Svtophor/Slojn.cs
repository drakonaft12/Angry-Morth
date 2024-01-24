using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Slojn : SlojnostBase // Класс, работающий с изменением уровня сложности, тем самым являясь модификацией SlojnostBase и сохраняющий принцип открытости-закрытости
{
    [SerializeField] Canvas canvas;
    [SerializeField] Vorcs[] objects;
    [SerializeField] float velocity = 1;
    bool goToRandom = false;



    private void RandomPosition()
    {
        foreach (var item in objects)
        {
            var x = Random.Range(50, canvas.renderingDisplaySize.x - 50);
            var y = Random.Range(50, canvas.renderingDisplaySize.y - 50);
            item.transforms = new Vector2(x, y);
            if (goToRandom) { item.gameObject.AddComponent<Dvijenie>().AddZnach(canvas,item,velocity); }
        }

    }

    protected override void UrowniSlojn()
    {
        switch (dificlt)
        {
            case 0:
                dificlt = 1;
                break;
            case 1:
                RandomPosition();
                dificlt = 2;
                break;
            case 2:
                goToRandom = true;
                RandomPosition();
                dificlt = 3;
                break;
            default:
                goToRandom = true;
                RandomPosition();
                velocity *= 2.75f * dificlt;
                dificlt += 1;
                break;
        }
    }
}

