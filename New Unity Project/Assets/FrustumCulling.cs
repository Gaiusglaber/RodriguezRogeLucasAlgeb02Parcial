using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrustumCulling : MonoBehaviour
{
    public Vector3[] points = new Vector3[8];
    
    public float initWith = 3.0f;
    public float initHeight = 2.0f;
    public float lastWidth = 6.0f;
    public float lastHeight = 5.0f;
    public float distanceBetweenPoints = 5.0f;
    public Plane[] planes = new Plane[6];
    void Start()
    {
        points[0] = new Vector3(initWith, initHeight, 0);
        points[1] = new Vector3(-initWith, initHeight, 0);
        points[2] = new Vector3(-initWith, -initHeight, 0);
        points[3] = new Vector3(initWith, -initHeight, 0);

        points[4] = new Vector3(lastWidth, lastHeight, distanceBetweenPoints);
        points[5] = new Vector3(-lastWidth, lastHeight, distanceBetweenPoints);
        points[6] = new Vector3(-lastWidth, -lastHeight, distanceBetweenPoints);
        points[7] = new Vector3(lastWidth, -lastHeight, distanceBetweenPoints);
        
        //back
        planes[0].Set3Points(points[0], points[1], points[2]);
        //front
        planes[1].Set3Points(points[4], points[5], points[6]);
        //top
        planes[2].Set3Points(points[0], points[1], points[4]);
        //down
        planes[3].Set3Points(points[2], points[3], points[7]);
        //left
        planes[4].Set3Points(points[1], points[2], points[5]);
        //right
        planes[5].Set3Points(points[0], points[3], points[5]);
    }

    void Update()
    {
        Debug.DrawLine(points[0], points[1]);
        Debug.DrawLine(points[1], points[2]);
        Debug.DrawLine(points[2], points[3]);
        Debug.DrawLine(points[0], points[3]);

        Debug.DrawLine(points[4], points[0]);
        Debug.DrawLine(points[5], points[1]);
        Debug.DrawLine(points[6], points[2]);
        Debug.DrawLine(points[7], points[3]);

        Debug.DrawLine(points[4], points[5]);
        Debug.DrawLine(points[5], points[6]);
        Debug.DrawLine(points[6], points[7]);
        Debug.DrawLine(points[4], points[7]);
    }
}
