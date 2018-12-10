using System;
using System.IO;
using System.Numerics;

namespace app
{
    class Program
    {


        static void Main(string[] args)
        {
            string path = "out/f.ppm";
            int nx = 800;
            int ny = 400;
            int antiAliasingSamples = 100; 

            Random randomGenerator = new Random();
            Camera camera = new Camera();
            
            Sphere centerSphere = new Sphere(new Vector3(0, 0, -1), 0.5f, new Lambertian(Color.Red));
            Sphere groundSphere = new Sphere(new Vector3(0f, -100.5f, -1f), 100f, new Lambertian(new Vector3(0.34f, 0.3f, 0.3f)));
            Sphere leftSphere = new Sphere(new Vector3(-1, 0, -1), 0.5f, new Lambertian(new Vector3(0.3, 0.21f, 0.66f)));
            Sphere rightSphere = new Sphere(new Vector3(1, 0, -1), 0.5f, new Lambertian(new Vector3(0.8, 0.6, 0.2)));
            World world = new World(centerSphere, groundSphere, leftSphere, rightSphere);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("P3");
                writer.WriteLine("{0} {1}", nx, ny);
                writer.WriteLine("255");
                
                for (int j = ny - 1; j >= 0; j--)
                {
                    for (int i = 0; i < nx; i++)
                    {
                        // anti aliasing
                        Vector3 finalColor = Vector3.Zero;
                        for (int s = 0; s < antiAliasingSamples; s++)
                        {
                            float u = (float) (i + randomGenerator.NextDouble()) / nx;
                            float v = (float) (j + randomGenerator.NextDouble()) / ny;
                            Ray ray = camera.RayOfUV(u, v);
                        
                            // single ray collision
                            // call a light transport algorithm                            
                            finalColor += LightTransport.CalculateColor(ray, world, 0);
                        }

                        finalColor /= antiAliasingSamples;
                        finalColor = new Vector3(MathF.Sqrt(finalColor.x), MathF.Sqrt(finalColor.y), MathF.Sqrt(finalColor.z));
                        //finalColor = new Vector3(finalColor.x, finalColor.y, finalColor.z);
                        int ir = (int) (255.99f * finalColor.r);
                        int ig = (int) (255.99f * finalColor.g);
                        int ib = (int) (255.99f * finalColor.b);
                        writer.WriteLine("{0} {1} {2}", ir, ig, ib);
                    }
                }
            }
        }
    }
}