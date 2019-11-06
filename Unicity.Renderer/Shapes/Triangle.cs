using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer.Shapes
{
    public class Triangle : Shape
    {
        int vao = 0;
        int vbo = 0;

        float[] vertices = null;

        public Triangle(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3)
        {
            vertices = new float[]
            {
                x1, y1, z1,
                x2, y2, z2,
                x3, y3, z3
            };

            vao = GL.GenVertexArray();
            vbo = GL.GenBuffer();
            
            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

        }

        internal override void Draw(Shader shader, GraphicsRenderer renderer)
        {
            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);

            float[] newVertices = new float[vertices.Length];

            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }

        public override void Dispose()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(vbo);
        }
    }
}
