namespace app
{
    public interface Hitable
    {
        bool DoesIntersect(Ray ray, float tMin, float tMax, ref HitRecord hitRecord);
        Vector3 NormalAt(Vector3 surfacePoint);
        Material Material { get; }
    }
}