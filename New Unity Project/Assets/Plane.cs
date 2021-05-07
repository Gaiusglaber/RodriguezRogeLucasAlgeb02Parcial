using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct plane
{
    Vector3 m_Normal;
    float m_Distance;
    public Vector3 normal
    {
        get { return m_Normal; }
        set { m_Normal = value; }
    }
    public float distance
    {
        get { return m_Distance; }
        set { m_Distance = value; }
    }
    public plane(Vector3 inNormal, Vector3 inPoint)
    {
        m_Normal = Vector3.Normalize(inNormal);
        m_Distance = -Vector3.Dot(m_Normal, inPoint);
    }
    public void SetNormalAndPosition(Vector3 inNormal, Vector3 inPoint)
    {
        m_Normal = Vector3.Normalize(inNormal);
        m_Distance = -Vector3.Dot(inNormal, inPoint);
    }

    public void Set3Points(Vector3 a, Vector3 b, Vector3 c)
    {
        m_Normal = Vector3.Normalize(Vector3.Cross(b - a, c - a));
        m_Distance = -Vector3.Dot(m_Normal, a);
    }

    public void Flip()
    {
        m_Normal = -m_Normal;
        m_Distance = -m_Distance;
    }
    public Vector3 ClosestPointOnPlane(Vector3 point)
    {
        var pointToPlaneDistance = Vector3.Dot(m_Normal, point) + m_Distance;
        return point - (m_Normal * pointToPlaneDistance);
    }
}
