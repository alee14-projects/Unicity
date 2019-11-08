namespace Unicity.Engine
{
    public class GameObject
    {
        public float X = 0;
        public float Y = 0;
        public float Z = 0;

        public float ScaleX = 0;
        public float ScaleY = 0;
        public float ScaleZ = 0;

        public Model Model = null;

        public GameObject()
        {

        }

        public GameObject(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
