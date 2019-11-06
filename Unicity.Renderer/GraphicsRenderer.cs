using System;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using Unicity.Renderer.Shapes;

namespace Unicity.Renderer
{
    public class GraphicsRenderer : IDisposable
    {
        public RenderWindow window { get; }
        public Camera camera = null;

        Shader shader = null;
         
        public GraphicsRenderer(RenderWindow window, Camera camera)
        {
            this.window = window;
            this.camera = camera;

            Console.WriteLine("Compiling GLSL shaders...");

            string vertexShader = Encoding.UTF8.GetString(Properties.Resources.vertexShader);
            string fragmentShader = Encoding.UTF8.GetString(Properties.Resources.fragmentShader);
            shader = new Shader(vertexShader, fragmentShader);
            shader.Use();

            Console.WriteLine("Reticulating splines...");

            GL.ClearDepth(1.0f);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            camera.Initialize();
            window.Update += Window_Update;

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }

        private void Window_Update(object sender, EventArgs e)
        {
            camera.UpdateView(shader);
            shader.Use();
        }

        public void SetClearColor(float red, float green, float blue, float alpha)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        public void SetDrawColor(float red, float green, float blue)
        {
            shader.SetUniform("color", new Vector3(red, green, blue));
        }

        public void DrawShape(Shape shape)
        {
            shape.Draw(shader, this);
        }

        public void DrawShapes(Shape[] shapes)
        {
            foreach (Shape shape in shapes)
            {
                DrawShape(shape);
            }
        }

        public void ClearScreen()
        {
            window.window.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            // Return of already disposed
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects here
            }

            // Dispose of any unmanaged resources
            window?.Dispose();
            shader.Delete();

            // Set disposed flag to true
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
