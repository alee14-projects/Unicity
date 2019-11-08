using System;
using Unicity.Renderer;

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

            window.Render += Window_Render;

            renderer.TestInit();
        }

        private void Window_Render(object sender, EventArgs e)
        {
            renderer.TestLoop();
        }

        public void Open(double ups = 60.0, double fps = 60.0)
        {
            window.Open(ups, fps);
            renderer.TestInit();
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
