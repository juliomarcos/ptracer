namespace app
{
    public class Color
    {
        private static readonly Vector3 red = new Vector3(0.8f, 0.1f, 0.15f);
        private static readonly Vector3 bookBlue = new Vector3(0.5f, 0.7f, 1.0f);
        private static readonly Vector3 purple = new Vector3(0.6f, 0.12f, 0.63f);
        
        public static Vector3 Red => red;
        public static Vector3 BookBlue => bookBlue;
        public static Vector3 Purple => purple;
    }
}