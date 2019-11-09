using OpenTK;

namespace Unicity.Renderer.Shapes
{
    public class Triangle : Shape
    {
        internal float[] Vertices;
        internal Vector3 Color;

        public Triangle(float[] vertices, float red, float green, float blue)
        {
            Vertices = vertices;
            Color = new Vector3(red, green, blue);
        }
    }
}
