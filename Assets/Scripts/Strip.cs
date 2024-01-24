using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Strip : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] Transform target;

    private const int PointCount = 2;
    private const int StartPoint = 0;
    private const int EndPoint = 1;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = PointCount;

        lineRenderer.SetPosition(StartPoint, transform.position);
    }
    private void Update()
    {
        lineRenderer.SetPosition(EndPoint, target.transform.position);
    }
}
