using System;
using Unicity.Renderer;
using Unicity.Renderer.Shapes;

namespace Unicity.Engine
{
    public class GameWindow : IDisposable
    {
        RenderWindow window = null;
        GraphicsRenderer renderer = null;

        public int Width { get => window.Width; set => window.Width = value; }
        public int Height { get => window.Height; set => window.Height = value; }

        public string Title { get => window.Title; set => window.Title = value; }

        bool disposed = false;

        public GameWindow(int width = 800, int height = 800, string title = "Unicity Renderer written by Adrian Ulbrich")
        {
            window = new RenderWindow(width, height, title);
            renderer = new GraphicsRenderer(window);

            renderer.SetRenderData(new Shape[] { new Triangle(new float[] { -1.0f, -0.5f, 0.0f, 0.0f, -0.5f, 0.0f, -0.5f,  0.5f, 0.0f }, 1.0f, 0.0f, 0.0f), new Triangle(new float[] { 0.0f, -0.5f, 0.0f, 1.0f, -0.5f, 0.0f, 0.5f, 0.5f, 0.0f }, 1.0f, 1.0f, 0.0f) });
        }

        public void Open(double ups = 60.0, double fps = 60.0)
        {
            window.Open(ups, fps);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose of managed resources
            }

            // Dispose of unmanaged resources
            renderer?.Dispose();
            window?.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
