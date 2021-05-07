using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

namespace CustomMath
{
    public struct Vec3 : IEquatable<Vec3>
    {
        #region Variables
        public float x;
        public float y;
        public float z;

        public float sqrMagnitude { get { throw new NotImplementedException(); } }
        public Vector3 normalized { get { throw new NotImplementedException(); } }
        public float magnitude { get { throw new NotImplementedException(); } }
        #endregion

        #region constants
        public const float epsilon = 1e-05f;
        #endregion

        #region Default Values
        public static Vec3 Zero { get { return new Vec3(0.0f, 0.0f, 0.0f); } }
        public static Vec3 One { get { return new Vec3(1.0f, 1.0f, 1.0f); } }
        public static Vec3 Forward { get { return new Vec3(0.0f, 0.0f, 1.0f); } }
        public static Vec3 Back { get { return new Vec3(0.0f, 0.0f, -1.0f); } }
        public static Vec3 Right { get { return new Vec3(1.0f, 0.0f, 0.0f); } }
        public static Vec3 Left { get { return new Vec3(-1.0f, 0.0f, 0.0f); } }
        public static Vec3 Up { get { return new Vec3(0.0f, 1.0f, 0.0f); } }
        public static Vec3 Down { get { return new Vec3(0.0f, -1.0f, 0.0f); } }
        public static Vec3 PositiveInfinity { get { return new Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity); } }
        public static Vec3 NegativeInfinity { get { return new Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity); } }
        #endregion                                                                                                                                                                               

        #region Constructors
        public Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0.0f;
        }

        public Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vec3(Vec3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector3 v3)
        {
            this.x = v3.x;
            this.y = v3.y;
            this.z = v3.z;
        }

        public Vec3(Vector2 v2)
        {
            this.x = v2.x;
            this.y = v2.y;
            this.z = 0.0f;
        }
        #endregion

        #region Operators
        public static bool operator ==(Vec3 left, Vec3 right)
        {
            float diff_x = left.x - right.x;
            float diff_y = left.y - right.y;
            float diff_z = left.z - right.z;
            float sqrmag = diff_x * diff_x + diff_y * diff_y + diff_z * diff_z;
            return sqrmag < epsilon * epsilon;
        }
        public static bool operator !=(Vec3 left, Vec3 right)
        {
            return !(left == right);
        }

        public static Vec3 operator +(Vec3 leftV3, Vec3 rightV3)
        {
            return new Vec3(leftV3.x + rightV3.x, leftV3.y + rightV3.y, leftV3.z + rightV3.z);
        }

        public static Vec3 operator -(Vec3 leftV3, Vec3 rightV3)
        {
            throw new NotImplementedException();
        }

        public static Vec3 operator -(Vec3 v3)
        {
            throw new NotImplementedException();
        }

        public static Vec3 operator *(Vec3 v3, float scalar)
        {
            throw new NotImplementedException();
        }
        public static Vec3 operator *(float scalar, Vec3 v3)
        {
            throw new NotImplementedException();
        }
        public static Vec3 operator /(Vec3 v3, float scalar)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Vector3(Vec3 v3)
        {
            return new Vector3(v3.x, v3.y, v3.z);
        }

        public static implicit operator Vector2(Vec3 v2)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Functions
        public override string ToString()
        {
            return "X = " + x.ToString() + "   Y = " + y.ToString() + "   Z = " + z.ToString();
        }
        public static float Angle(Vec3 from, Vec3 to)
        {
            return (float)Math.Acos((from.x * to.x) + (from.y * to.y) + (from.z * to.z) / 
                  (Math.Sqrt (Math.Pow(from.x,2))+ Math.Pow(from.y, 2)+ Math.Pow(from.z, 2)) *
                  (Math.Sqrt(Math.Pow(to.x, 2)) + Math.Pow(to.y, 2) + Math.Pow(to.z, 2)));

        }
        public static Vec3 ClampMagnitude(Vec3 vector, float maxLength)
        {
            if (Magnitude(vector) > maxLength)
            {
                if (vector.x > maxLength)
                {
                    vector.x = maxLength;
                }

                if (vector.y > maxLength)
                {
                    vector.y = maxLength;
                }

                if (vector.z > maxLength)
                {
                    vector.z = maxLength;
                }
            }
            else
            {
                vector = new Vec3((float) Math.Sqrt(vector.x / 2), (float) Math.Sqrt(vector.y / 2),
                    (float) Math.Sqrt(vector.z / 2));
            }
            return vector;
        }
        public static float Magnitude(Vec3 vector)
        {
            return (float)Math.Sqrt(Math.Pow(vector.x,2)+ Math.Pow(vector.y, 2)+ Math.Pow(vector.z, 2));
        }
        public static Vec3 Cross(Vec3 a, Vec3 b)
        {
            Vec3 vector;
            vector.x = a.y * b.z - a.z - b.y;
            vector.y = a.z * b.x - a.x - b.z;
            vector.z = a.x * b.y - a.y - b.x;
            return vector;
        }
        public static float Distance(Vec3 a, Vec3 b)
        {
            return (float)Math.Sqrt(Math.Pow((a.x-b.x),2)+ Math.Pow((a.y - b.y), 2)+ Math.Pow((a.z - b.z), 2));
        }
        public static float Dot(Vec3 a, Vec3 b)
        {
            return (a.x*b.x)+(a.y*b.y)+(a.z*b.z);
        }
        public static Vec3 Lerp(Vec3 a, Vec3 b, float t)
        {
            if (t < 0)
            {
                t = 0;
            }else if (t > 1)
            {
                t = 1;
            }
            Vec3 vector;
            vector.x = a.x + (t * (b.x - a.x));
            vector.y = a.y + (t * (b.y - a.y));
            vector.z = a.z + (t * (b.z - a.z));
            return vector;
        }
        public static Vec3 LerpUnclamped(Vec3 a, Vec3 b, float t)
        {
            Vec3 vector;
            vector.x = a.x + (t * (b.x - a.x));
            vector.y = a.y + (t * (b.y - a.y));
            vector.z = a.z + (t * (b.z - a.z));
            return vector;
        }
        public static Vec3 Max(Vec3 a, Vec3 b)
        {
            Vec3 vector;
            vector.x = (a.x > b.x) ? a.x : b.x;
            vector.y = (a.y > b.y) ? a.y : b.y;
            vector.z = (a.z > b.z) ? a.z : b.z;
            return vector;
        }
        public static Vec3 Min(Vec3 a, Vec3 b)
        {
            Vec3 vector;
            vector.x = (a.x < b.x) ? a.x : b.x;
            vector.y = (a.y < b.y) ? a.y : b.y;
            vector.z = (a.z < b.z) ? a.z : b.z;
            return vector;
        }
        public static float SqrMagnitude(Vec3 vector)
        {
            return (float)Math.Sqrt(Magnitude(vector));
        }
        public static Vec3 Project(Vec3 vector, Vec3 onNormal)
        {
            return onNormal*(Dot(vector,onNormal)/Magnitude(onNormal));
        }
        public static Vec3 Reflect(Vec3 inDirection, Vec3 inNormal)
        {
            return 2 * (Dot(inNormal, inDirection) * (inNormal - inDirection));
        }
        public void Set(float newX, float newY, float newZ)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
        }
        public void Scale(Vec3 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
            this.z *= scale.z;
        }
        public void Normalize()
        {
            this /= Magnitude(this);
        }
        #endregion

        #region Internals
        public override bool Equals(object other)
        {
            if (!(other is Vec3)) return false;
            return Equals((Vec3)other);
        }

        public bool Equals(Vec3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2) ^ (z.GetHashCode() >> 2);
        }
        #endregion
    }
}