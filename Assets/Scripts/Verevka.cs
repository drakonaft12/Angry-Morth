using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verevka : MonoBehaviour
{
    [SerializeField] private RectTransform rotationPoint, endLine;
    private Vector2 startPos;

    private void Awake()
    {
        startPos = (transform as RectTransform).anchoredPosition;
    }

    private void BildLine()
    {
        var rast = endLine.transform.position - rotationPoint.transform.position;
        Rastianut(-rast.magnitude*0.8f, 0);
        RotatePoint(-rast);

    }

    private void Rastianut(float x, float y)
    {
        (transform as RectTransform).sizeDelta = new Vector2(x<0?-x:x, y<0?-y:y);
        (transform as RectTransform).anchoredPosition = startPos + new Vector2(x / 2, y / 2);
    }

    private void RotatePoint(Vector2 vector)
    {
        var q = new Quaternion();
        q.SetEulerAngles(0, 0, Mathf.Atan2(vector.y, vector.x));
        rotationPoint.rotation = q;


    }


    private void Update()
    {
        BildLine();
    }
}
