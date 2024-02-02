using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


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

    public async void Boom(float forse, float variation, Vector2 point, float radius = 225, int delay = 200)
    {
        var coll = (int)((forse - 1) / 1000000) + 1;
        var newcoll = coll > booms.Count ? coll - booms.Count : 0;
        float ost = (forse - 1) % 1000000 + 1;

        for (int i = 0; i < newcoll; i++)
        {
            booms.Add(BoomCreate(1000000, variation * 1000000).Result);
        }
        BoomColliderStat(variation, ost);

        BoomRadius(radius, point, coll);

        BoomActive(coll, true);
        await Task.Delay(delay);
        BoomActive(coll, false);
    }


    private async Task<GameObject> BoomCreate(float magnitude, float variation)
    {
        var item = new GameObject("BoomEffect");
        var collider = item.AddComponent<CircleCollider2D>();
        var forsePoint = item.AddComponent<PointEffector2D>();
        collider.isTrigger = true;
        collider.usedByEffector = true;
        forsePoint.forceMagnitude = magnitude;
        forsePoint.forceVariation = variation;
        item.SetActive(false);
        return item;
    }
    private void BoomColliderStat(float variation, float ost)
    {
        var forsePoint = booms[0].GetComponent<PointEffector2D>();
        forsePoint.forceMagnitude = ost;
        forsePoint.forceVariation = variation * ost;
    }

    private void BoomActive(int coll, bool active)
    {
        for (int i = 0; i < coll; i++)
        {
            booms[i].SetActive(active);
        }
    }

    private void BoomRadius(float radius, Vector2 point, int coll)
    {
        for (int i = 0; i < coll; i++)
        {
            booms[i].transform.position = point;
            booms[i].GetComponent<CircleCollider2D>().radius = radius;
        }
        
    }
    }
