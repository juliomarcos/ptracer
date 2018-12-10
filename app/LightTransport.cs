namespace app
{
    public class LightTransport
    {
        public static Vector3 BgColor(Ray ray)
        {
            Vector3 unitDir = ray.direction.Normalized;
            float t = 0.5f * (unitDir.y + 1f);
            return Vector3.Lerp(Vector3.One, app.Color.BookBlue, t);
        }

        public static Vector3 CalculateColor(Ray ray, World world, int depth)
        {
            HitRecord hitRecord = new HitRecord();
            if (world.Hit(ray, 0.001f, float.MaxValue, ref hitRecord))
            {                
                if (depth < 50 && hitRecord.material.Scatter(ray, ref hitRecord, out Vector3 attenuation, out Ray scattered))
                {
                    return attenuation * CalculateColor(scattered, world, depth + 1);
                }
                else
                {
                    return Vector3.Zero;
                }
            }
            else
            {
                return BgColor(ray);
            }            
        }
    }
}