using System;
using System.Numerics;

namespace app
{
    public struct Ray
    {
        public Vector3 origin, direction;

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Vector3 PointAt(float t)
        {
            return origin + direction * t;
        }
    }
}