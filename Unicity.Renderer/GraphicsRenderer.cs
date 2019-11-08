using System.IO;
using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer
{
    public class GraphicsRenderer
    {
        RenderWindow window = null;

        // Tests
        float[] vertices =
        {
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f, 0.5f, 0.0f
        };

        Shader shader = null;

        int VBO = 0;

        public GraphicsRenderer(RenderWindow window)
        {
            this.window = window;
        }

        public void TestInit()
        {
            window.MakeCurrent();

            string vertexCode = File.ReadAllText("shaders/test.vert");

            shader = new Shader(vertexCode, "");

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
        }

        public void TestLoop()
        {
            window.MakeCurrent();
        }
    }
}
