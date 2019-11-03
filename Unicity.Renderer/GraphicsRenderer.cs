using GLFW;
using SharpGL;
using System;
using Unicity.Renderer.Shapes;
using static SharpGL.OpenGL;

namespace Unicity.Renderer
{
    public class GraphicsRenderer : IDisposable
    {
        internal static OpenGL GL = new OpenGL();

        public RenderWindow window { get; }

        public GraphicsRenderer(RenderWindow window)
        {
            this.window = window;
        }

        public void SetClearColor(float red, float green, float blue, float alpha)
        {
            GL.ClearColor(red, green, blue, alpha);
        }

        public void ClearScreen()
        {
            Glfw.MakeContextCurrent(window.window);
            GL.Clear(GL_COLOR_BUFFER_BIT);
        }

        public void RenderShape(Shape shape)
        {
            shape.Render();
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
