using System;

namespace app
{
    public abstract class Material
    {
        
        protected readonly DirectionalLight fixedLight = new DirectionalLight(
            new Vector3(-0.2f, 0.7f, 0.2f).Normalized,
            new Vector3(1f, 0.5f, 0.1f),
            1.2f
        );
        
        protected readonly Vector3 ambientLight = new Vector3(0.1f, 0.1f, 0.1f);

        public Vector3 SurfaceColor(Ray ray, Vector3 surfaceNormal)
        {
            return 0.5f * new Vector3(surfaceNormal.x + 1, surfaceNormal.y + 1, surfaceNormal.z + 1);
        }

        public abstract bool Scatter(Ray rayIn, ref HitRecord hitRecord, out Vector3 attenuation, out Ray scattered);
    }
} 