#nullable enable
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;


namespace Birds
{
    [Serializable]
    public class BirdTransfer
    {
        [SerializeField] private float duration = 1;
        [SerializeField] private float jumpPower = 2;


        public IEnumerator Transfer(Bird bird, Vector3 target)
        {
            yield return bird.transform.DOJump(
                target,
                jumpPower,
                1,
                duration
            )!.WaitForCompletion();
        }
    }
}