using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVector : MonoBehaviour
{
    public enum Ejercicios { Uno, Dos, Tres, Cuatro, Cinco, Seis, Siete, Ocho, Nueve, Diez};

    public Vector3 a;
    public Vector3 b;
    public Vector3 c;
    public Ejercicios ej;
    public void Update()
    {
        switch (ej){
            case Ejercicios.Uno:
                c.x = a.x + b.x;
                c.y = a.y + b.y;
                c.z = a.z + b.z;
                break;
            case Ejercicios.Dos:
                c.x = a.x - b.x;
                c.y = a.y - b.y;
                c.z = a.z - b.z;
                break;
            case Ejercicios.Tres:
                c.x = a.x * b.x;
                c.y = a.y * b.y;
                c.z = a.z * b.z;
                break;
            case Ejercicios.Cuatro:
                c.x = a.y * b.z - a.z - b.y;
                c.y = a.z * b.x - a.x - b.z;
                c.z = a.x * b.y - a.y - b.x;
                break;
            case Ejercicios.Cinco:
                if (a.x > b.x)
                {
                    if (c.x < a.x)
                    {
                        c.x += 0.1f;
                    }
                    else
                    {
                        c.x = a.x;
                    }
                }
                else
                {
                    if (c.x < b.x)
                    {
                        c.x += 0.1f;
                    }
                    else
                    {
                        c.x = b.x;
                    }
                }
                if (a.y > b.y)
                {
                    if (c.y < a.y)
                    {
                        c.y += 0.1f;
                    }
                    else
                    {
                        c.y = a.y;
                    }
                }
                else
                {
                    if (c.y < b.y)
                    {
                        c.y += 0.1f;
                    }
                    else
                    {
                        c.y = b.y;
                    }
                }
                if (a.z > b.z)
                {
                    if (c.z < a.z)
                    {
                        c.z += 0.1f;
                    }
                    else
                    {
                        c.z = a.z;
                    }
                }
                else
                {
                    if (c.z < b.z)
                    {
                        c.z += 0.1f;
                    }
                    else
                    {
                        c.z = b.z;
                    }
                }// incorrecto
                break;
            case Ejercicios.Seis:
                c.x = (a.x < b.x) ? a.x : b.x;
                c.y = (a.y < b.y) ? a.y : b.y;
                c.z = (a.z < b.z) ? a.z : b.z;
                break;
            case Ejercicios.Siete:
                break;
            case Ejercicios.Ocho:
                c.x = a.x - b.x;
                break;
            case Ejercicios.Nueve:
                break;
            case Ejercicios.Diez:
                break;
        }
    }
}