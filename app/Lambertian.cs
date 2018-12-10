namespace app
{
    public class Lambertian : Material
    {
        private Vector3 albedo;

        public Lambertian(Vector3 albedo)
        {
            this.albedo = albedo;
        }

        public override bool Scatter(Ray rayIn, ref HitRecord hitRecord, out Vector3 attenuation, out Ray scattered)
        {
            Vector3 target = hitRecord.p + hitRecord.normal + MyRandom.PointInUnitSphere2();
            scattered = new Ray(hitRecord.p, target - hitRecord.p);
            attenuation = albedo;
            return true;
        }
    }
}