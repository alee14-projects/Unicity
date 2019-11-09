using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer
{
    public class RenderWindow : IDisposable
    {
        public event EventHandler Update;
        public event EventHandler Render;

        GameWindow window = null;

        public int Width { get => window.Width; set => window.Width = value; }
        public int Height { get => window.Height; set => window.Height = value; }

        public string Title { get => window.Title; set => window.Title = value; }

        bool disposed = false;

        public RenderWindow(int width, int height, string title)
        {
            window = new GameWindow(width, height, GraphicsMode.Default, title, GameWindowFlags.Default, DisplayDevice.Default, 4, 0, GraphicsContextFlags.ForwardCompatible);
            window.Load += Window_Load;
            window.Resize += Window_Resize;
            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
        }
        private void Window_Load(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Window_RenderFrame(this, new FrameEventArgs());
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            Update?.Invoke(this, EventArgs.Empty);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Render?.Invoke(this, EventArgs.Empty);

            window.SwapBuffers();
        }
        
        public void Open(double ups, double fps)
        {
            window.Run(ups, fps);
        }

        public void MakeCurrent()
        {
            if (window.IsExiting)
            {
                return;
            }
            window.MakeCurrent();
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
