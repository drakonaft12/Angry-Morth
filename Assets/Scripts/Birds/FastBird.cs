using Birds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastBird : TypeBirdBase
{

    protected override void SetupBird(Bird _bird)
    {
        
    }

    protected override void WorkBird(Bird _bird)
    {
        if (Input.GetMouseButtonDown(0) && !_bird.IsCollision)
        {
            _bird.Launch(_bird.Rigidbody.velocity.normalized * 10);
            _bird.IsCollision = true;
        }
    }
}
