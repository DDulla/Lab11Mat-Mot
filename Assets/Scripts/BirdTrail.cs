using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrail : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Transform birdTransform;
    public float horizontalSpeed = 4f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, birdTransform.position);
    }

    void Update()
    {
        Vector3 currentPoint = new Vector3(birdTransform.position.x - horizontalSpeed * Time.deltaTime, birdTransform.position.y, birdTransform.position.z);
        if (Vector3.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), currentPoint) > 0.1f)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPoint);
        }
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = lineRenderer.GetPosition(i);
            pos.x -= horizontalSpeed * Time.deltaTime;
            lineRenderer.SetPosition(i, pos);
        }
    }
}

