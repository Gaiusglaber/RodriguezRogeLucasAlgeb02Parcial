using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInPlane : MonoBehaviour
{
    public Plane plane1;
    public Plane plane2;
    public Plane plane3;
    public Plane plane4;
    public Plane plane5;
    public Plane plane6;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 point1 = new Vector3(-4, -4, -4);
        Vector3 point2 = new Vector3(4, -4, -4);
        Vector3 point3 = new Vector3(4, 4, -4);
        Vector3 point4 = new Vector3(-4, 4, -4);
        Vector3 point5 = new Vector3(-4, -4, 4);
        Vector3 point6 = new Vector3(4, -4, 4);
        Vector3 point7 = new Vector3(4, 4, 4);
        Vector3 point8 = new Vector3(-4, 4, 4);

        plane1 = new Plane(point4, point8);
        plane2 = new Plane(point1, point6);
        plane3 = new Plane(point5, point7);
        plane4 = new Plane(point1, point3);
        plane5 = new Plane(point1, point5);
        plane6 = new Plane(point2, point6);

        plane1.SetNormalAndPosition(plane1.normal,cube.transform.position);
        plane2.SetNormalAndPosition(plane2.normal, cube.transform.position);
        plane3.SetNormalAndPosition(plane3.normal, cube.transform.position);
        plane4.SetNormalAndPosition(plane4.normal, cube.transform.position);
        plane5.SetNormalAndPosition(plane5.normal, cube.transform.position);
        plane6.SetNormalAndPosition(plane6.normal, cube.transform.position);
    }

    private bool IsInsidePlane()
    {
        //como los lados de los planos "miran" para afuera !GetSide(Vector3) es para la cara inexistente de adentro 
        return !plane1.GetSide(cube.transform.position) && !plane2.GetSide(cube.transform.position) &&
               !plane3.GetSide(cube.transform.position)
               && !plane4.GetSide(cube.transform.position) && !plane5.GetSide(cube.transform.position) &&
               !plane6.GetSide(cube.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsInsidePlane())
        {
            Debug.Log("El cubo esta adentro de los planos");
        }
        else
        {
            Debug.Log("El cubo esta afuera de los planos");
        }
    }
}
