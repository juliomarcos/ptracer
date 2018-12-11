using System;
using System.Security.Cryptography;

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
// GEOMETRIC SOLUTION. DOESN'T WORK, DON'T KNOW WHY            
//            Vector3 L = center - ray.origin;
//            double tca = L.Dot(ray.direction.Normalized);
//            if (tca < 0) return false;
//            double d2 = L.SqrMagnitude - tca * tca;
//            double r2 = radius * radius;
//            if (d2 > r2) return false;
//            double thc = Math.Sqrt(r2 - d2);
//            double t0 = tca - thc;
//            double t1 = tca + thc; // this should be test for both points
//            float t = (float) Math.Min(t0, t1);
//            if (t > tMin && t < tMax)
//            {
//                hitRecord.t = t;
//                hitRecord.p = ray.PointAt(t);
//                hitRecord.normal = (hitRecord.p - center) / radius;
//                hitRecord.material = material;
//                return true;
//            }
//            return false;
            
            Vector3 oc = ray.origin - center;
            float a = ray.direction.SqrMagnitude;
            float b = oc.Dot(ray.direction);
            float c = oc.SqrMagnitude - radius * radius;
            float discriminant = b * b - a * c;
            if (discriminant > 0)
            {
                float t = (-b - MathF.Sqrt(b * b - a * c)) / a;
                if (t > tMin && t < tMax)
                {
                    FillHitRecord(ray, out hitRecord, t);
                    return true;
                }
                t = (-b + MathF.Sqrt(b * b - a * c)) / a;
                if (t > tMin && t < tMax)
                {
                    FillHitRecord(ray, out hitRecord, t);
                    return true;
                }
            }

            return false;
        }

        private void FillHitRecord(Ray ray, out HitRecord hitRecord, float t)
        {
            hitRecord.t = t;
            hitRecord.p = ray.PointAt(t);
            hitRecord.normal = (hitRecord.p - center) / radius;
            hitRecord.material = material;
        }
    }
}