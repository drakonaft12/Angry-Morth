using Birds;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BoomBird : TypeBirdBase
{


    public BoomBird()
    {
        
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
        await Task.Delay((int)(3000 * Time.timeScale));
        await _bird.transform.DOScale(1.2f, 0.2f).SetLoops(2,LoopType.Yoyo).AsyncWaitForCompletion();
        _bird.Rigidbody.isKinematic = true;
        CreateBoom2D.boom2D.Boom(50000000, 0.4f, _bird.transform.position,200, (int)(150 * Time.timeScale));
        await Task.Delay((int)(150 * Time.timeScale));
        _bird.Rigidbody.isKinematic = false;
        
    }
}
