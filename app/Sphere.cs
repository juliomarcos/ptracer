using System;

namespace app
{
    public struct Sphere : Hitable
    {
        public Vector3 center;
        public float radius;
        private Material material;

        public Sphere(Vector3 center, float radius, Material material)
        {
            this.center = center;
            this.radius = radius;
            this.material = material;
        }

        public Material Material => material;

        public Vector3 NormalAt(Vector3 surfacePoint)
        {
            return (surfacePoint - center) / radius; // since we know radius is the length of this vector
        }
        
        public bool DoesIntersect(Ray ray, float tMin, float tMax, ref HitRecord hitRecord)
        {
            Vector3 L = center - ray.origin;
            float tca = L.Dot(ray.direction.Normalized);
            if (tca < 0)
            {
                // L and D are in opposite directions, no intersection happens
                hitRecord.t = float.MaxValue;
                return false;
            }
            float d2 = L.SqrMagnitude - tca * tca;
            float r2 = radius * radius;
            if (d2 > r2)
            {
                hitRecord.t = float.MaxValue;
                return false;
            }
            float thc = MathF.Sqrt(r2 - d2);            
            float t0 = tca - thc;
            if (t0 > tMin && t0 < tMax)
            {
                hitRecord.t = t0;
                hitRecord.p = ray.PointAt(t0);
                hitRecord.normal = (hitRecord.p - center) / radius;
                hitRecord.material = material;
                return true;
            }
            float t1 = tca + thc; // this should be test for both roots
            if (t1 > tMin && t1 < tMax)
            {
                hitRecord.t = t1;
                hitRecord.p = ray.PointAt(t1);
                hitRecord.normal = (hitRecord.p - center) / radius;
                hitRecord.material = material;
                return true;
            }
            return false;
        }
    }
}