using System;
using System.Numerics;

namespace app
{
    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float v) {
            x = v;
            y = v;
            z = v;
        }

        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public Vector3(double x, double y, double z) {
            this.x = (float) x;
            this.y = (float) y;
            this.z = (float) z;
        }

        public Vector3(Vector3 o)
        {
            x = o.x;
            y = o.y;
            z = o.z;
        }

        public float r { get { return x; }}
        public float g { get { return y; }}
        public float b { get { return z; }}
        
        static readonly Vector3 zeroVector = new Vector3(0);
        public static Vector3 Zero { get {return zeroVector;} }
        static readonly  Vector3 oneVector = new Vector3(1);
        public static Vector3 One { get {return oneVector;} }
        public float SqrMagnitude { get { return x * x + y * y + z * z; } }

        public static Vector3 operator*(Vector3 v, float t)
        {
            return new Vector3(
                v.x*t,
                v.y*t,
                v.z*t
            );
        }
        
        public static Vector3 operator*(float t, Vector3 v)
        {
            return new Vector3(
                v.x*t,
                v.y*t,
                v.z*t
            );
        }
        
        public static Vector3 operator*(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.x*b.x,
                a.y*b.y,
                a.z*b.z
            );
        }
        
        public static Vector3 operator/(Vector3 v, float t)
        {
            return new Vector3(
                v.x/t,
                v.y/t,
                v.z/t
            );
        }
        
        public static Vector3 operator/(float t, Vector3 v)
        {
            return new Vector3(
                v.x/t,
                v.y/t,
                v.z/t
            );
        }
        
        public static Vector3 operator+(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.x + b.x,
                a.y + b.y,
                a.z + b.z
            );
        }
        
        public static Vector3 operator-(Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.x - b.x,
                a.y - b.y,
                a.z - b.z
            );
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(
                -v.x,
                -v.y,
                -v.z
            );
        }

        public float Dot(Vector3 b)
        {
            return x * b.x + y * b.y + z * b.z;
        }

        public float Magnitude
        {
            get { return (float) Math.Sqrt(x * x + y * y + z * z); }
        }
        
        public Vector3 Normalized
        {
            get { return this / Magnitude; }
        }

        public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
        {
            return ((1.0f - t) * a) + (t * b);
        }
    }
}