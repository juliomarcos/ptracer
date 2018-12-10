namespace app
{
    public class Camera
    {
        Vector3 llc = new Vector3(-2, -1, -1);
        Vector3 hor = new Vector3(4, 0, 0);
        Vector3 ver = new Vector3(0, 2, 0);
        Vector3 origin = Vector3.Zero;

        public Ray RayOfUV(float u, float v)
        {
            return new Ray(origin, llc + hor * u + v * ver);
        }
    }
}