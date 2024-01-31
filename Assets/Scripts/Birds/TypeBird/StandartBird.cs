using Birds;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandartBird : TypeBirdBase
{

    protected override void SetupBird(Bird _bird)
    {
        _bird.GetComponent<Image>().color = Color.red;
    }

    protected override void WorkBird(Bird _bird)
    {

    }
}