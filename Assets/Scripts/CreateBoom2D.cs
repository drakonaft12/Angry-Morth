using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class CreateBoom2D
{
    public static CreateBoom2D boom2D;

    private List<GameObject> booms;

    public CreateBoom2D()
    {
        boom2D = this;
        booms = new List<GameObject>
        {
            BoomCreate(1, 0).Result
        };
    }

    public async void Boom(float forse, float variation, Vector2 point, float radius = 225)
    {
        var coll = (int)((forse-1) / 1000000)+1;
        var newcoll = coll > booms.Count ? coll - booms.Count : 0;
        float ost = forse % 1000000;
        if (ost == 0) ost = 1000000;
        for (int i = 0; i < newcoll; i++)
        {
           booms.Add(BoomCreate(1000000, variation * 1000000).Result);   
        }
        var forsePoint = booms[0].GetComponent<PointEffector2D>();
        forsePoint.forceMagnitude = ost;
        forsePoint.forceVariation = variation * ost;

        for (int i = 0; i < coll; i++)
        {
            booms[i].transform.position = point;
            BoomRadius(radius, i);
        }
        for (int i = 0; i < coll; i++)
        {
            booms[i].SetActive(true);
        }
        await Task.Delay(200);
        for (int i = 0; i < coll; i++)
        {
            booms[i].SetActive(false);
        }
    }


    private async Task<GameObject> BoomCreate(float magnitude, float variation)
    {
            var item = new GameObject("BoomEffect");           
            var forsePoint = item.AddComponent<PointEffector2D>();
            forsePoint.forceMagnitude = magnitude;
            forsePoint.forceVariation = variation;
            item.SetActive(false);
            return item;
    }

    private async void BoomRadius(float radius, int i)
    {
        var collider = booms[i].AddComponent<CircleCollider2D>();
        collider.radius = radius;
        collider.isTrigger = true;
        collider.usedByEffector = true;
    }
    }
