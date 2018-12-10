namespace app
{
    public class DirectionalLight
    {
        public readonly Vector3 direction;
        public readonly Vector3 color;
        public readonly float intensity;

        public DirectionalLight(Vector3 direction, Vector3 color, float intensity)
        {
            this.direction = direction;
            this.color = color;
            this.intensity = intensity;
        }
    }
}