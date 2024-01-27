using Birds;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TypeBirdBase
{

    protected abstract void SetupBird(Bird _bird);

    protected abstract void WorkBird(Bird _bird);

    public void AddSetup(Bird _bird)
    {
        SetupBird(_bird);
        _bird.WorkInput!.AddListener(WorkBird);
    }

}
