using Birds;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GigantBird : TypeBirdBase
{
    protected override void SetupBird(Bird _bird)
    {
        _bird.GetComponent<Image>().color = Color.black;
    }

    protected override void WorkBird(Bird _bird)
    {
        if (Input.GetMouseButtonDown(0) && !_bird.IsCollision)
        {
            _bird.gameObject.transform.DOScale(2, 0.5f);

            _bird.IsCollision = true;
        }
    }

}
