using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMath;
public class NewVector : MonoBehaviour
{
    public enum Ejercicios { Uno, Dos, Tres, Cuatro, Cinco, Seis, Siete, Ocho, Nueve, Diez};
    [SerializeField] public Vector3 A;
    [SerializeField] public Vector3 B;
    [SerializeField] public Vec3 a;
    [SerializeField] public Vec3 b;
    [SerializeField] public Vec3 c;
    [SerializeField] public float aux = 0;
    public Ejercicios ej;
    private void Start()
    {
        a = A;
        b = B;
        MathDebbuger.Vector3Debugger.AddVector(a, "A");
        MathDebbuger.Vector3Debugger.AddVector(b, "B");
        MathDebbuger.Vector3Debugger.AddVector(c, "C");
        MathDebbuger.Vector3Debugger.EnableEditorView();
    }
    public void Update()
    {
        a = A;
        b = B;
        switch (ej)
        {
            case Ejercicios.Uno:
                c = a + b;
                break;
            case Ejercicios.Dos:
                c = b - a;
                break;
            case Ejercicios.Tres:
                c.x = a.x * b.x;
                c.y = a.y * b.y;
                c.z = a.z * b.z;
                break;
            case Ejercicios.Cuatro:
                c = Vec3.Cross(a, b);
                break;
            case Ejercicios.Cinco:
                aux += Time.deltaTime;
                c = Vec3.Lerp(a, b, aux);
                if (aux > 1) { aux = 0; }
                break;
            case Ejercicios.Seis:
                c=Vec3.Max(a, b);
                break;
            case Ejercicios.Siete:
                c = Vec3.Project(a, b);
                break;
            case Ejercicios.Ocho:
                c = (a + b).normalized * Vec3.Distance(a, b);
                break;
            case Ejercicios.Nueve:
                c = Vec3.Reflect(a, b).normalized;
                break;
            case Ejercicios.Diez:
                aux += Time.deltaTime;
                c = Vec3.LerpUnclamped(a, b, aux);
                break;
        }
        MathDebbuger.Vector3Debugger.UpdatePosition("C", c);
        MathDebbuger.Vector3Debugger.UpdatePosition("B", b);
        MathDebbuger.Vector3Debugger.UpdatePosition("A", a);

        MathDebbuger.Vector3Debugger.UpdateColor("C", Color.blue);
        MathDebbuger.Vector3Debugger.UpdateColor("B", Color.white);
        MathDebbuger.Vector3Debugger.UpdateColor("A", Color.black);
    }
}