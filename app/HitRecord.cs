namespace app
{
    public struct HitRecord
    {
        public float t;
        public Vector3 p;
        public Vector3 normal;
        public Material material;

        public HitRecord(float t, Vector3 p, Vector3 normal, Material material)
        {
            this.t = t;
            this.p = p;
            this.normal = normal;
            this.material = material;
        }
    }
}