namespace Unicity.Renderer.Shapes
{
    public class Rectangle : Shape
    {
        Triangle rect1 = null;
        Triangle rect2 = null;

        public Rectangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
        {
            rect1 = new Triangle(x1, y1, z1, x2, y2, z2, x3, y3, z3);
            rect2 = new Triangle(x3, y3, z3, x2, y2, z2, x4, y4, z4);
        }

        internal override void Draw(Shader shader, GraphicsRenderer renderer)
        {
            rect1.Draw(shader, renderer);
            rect2.Draw(shader, renderer);
        }

        public override void Dispose()
        {
            rect1.Dispose();
            rect2.Dispose();
        }
    }
}
