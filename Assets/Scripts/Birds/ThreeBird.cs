using Birds;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class ThreeBird : TypeBirdBase
{
    private BirdSpawn birdSpawn;
    public ThreeBird(BirdSpawn spawn)
    {
        birdSpawn = spawn;
    }
    protected override void SetupBird(Bird _bird)
    {
        _bird.GetComponent<Image>().color = Color.cyan;
        _bird.transform.localScale *= 0.5f;
    }

    protected override void WorkBird(Bird _bird)
    {
        if (Input.GetMouseButtonDown(0) && !_bird.IsCollision)
        {
            birdSpawn.NextBird(_bird, Vector3.up*15);
            birdSpawn.NextBird(_bird, Vector3.down*15);
            _bird.IsCollision = true;
        }
    }

}
