using System;

namespace app
{
    public class MyRandom
    {
        private static readonly Random generator = new Random();
        
        public static double NextGaussian(double mu = 0, double sigma = 1)
        {
            var u1 = generator.NextDouble();
            var u2 = generator.NextDouble();

            var rand_std_normal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                  Math.Sin(2.0 * Math.PI * u2);

            var rand_normal = mu + sigma * rand_std_normal;

            return rand_normal;
        }
        
        public static Vector3 PointInUnitSphere()
        {
            float x = (float) NextGaussian();
            float y = (float) NextGaussian();
            float z = (float) NextGaussian();
            return new Vector3(x, y, z).Normalized;
        }

        public static Vector3 PointInUnitSphere2()
        {
            Vector3 p;
            do {
                p = 2.0f * new Vector3(generator.NextDouble(), generator.NextDouble(), generator.NextDouble()) - Vector3.One;
            } while (p.SqrMagnitude >= 1.0);
            return p; 
        }
    }
}