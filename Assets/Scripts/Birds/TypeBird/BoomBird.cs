using Birds;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BoomBird : TypeBirdBase
{

    GameObject[] booms;

    public BoomBird()
    {
        booms = new GameObject[20];
        for (int i = 0; i < 20; i++)
        {
            booms[i] = BoomCreate().Result;
        }
    }
    protected override void SetupBird(Bird _bird)
    {
        _bird.GetComponent<Image>().color = Color.gray;
    }

    protected override void WorkBird(Bird _bird)
    {
        if (Input.GetMouseButtonDown(0) && !_bird.IsCollision)
        {
            Boom(_bird);

            _bird.IsCollision = true;
        }
    }

    private async void Boom(Bird _bird)
    {
        await Task.Delay(3000);
        await _bird.transform.DOScale(1.2f, 0.2f).SetLoops(2,LoopType.Yoyo).AsyncWaitForCompletion();
        _bird.Rigidbody.isKinematic = true;
        for (int i = 0; i < booms.Length; i++)
        {
            booms[i].transform.position = _bird.transform.position;
            booms[i].SetActive(true);
        }
        await Task.Delay(200);
        _bird.Rigidbody.isKinematic = false;
        for (int i = 0; i < booms.Length; i++)
        {
            booms[i].SetActive(false);
        }
    }

    private async Task<GameObject> BoomCreate()
    {
        var item = new GameObject("BoomEffect");
        var collider = item.AddComponent<CircleCollider2D>();
        var forsePoint = item.AddComponent<PointEffector2D>();
        collider.radius = 225;
        collider.isTrigger = true;
        collider.usedByEffector = true;
        forsePoint.forceMagnitude = 10000000;
        forsePoint.forceVariation = 10000000;
        item.SetActive(false);
        return item;
    }
}
