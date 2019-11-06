using System;
using System.Diagnostics;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer
{
    public class RenderWindow : IDisposable
    {
        const int UPS = 60;

        internal GameWindow window = null;

        Stopwatch loopTimer = new Stopwatch();

        public event EventHandler Init;
        public event EventHandler Update;
        public event EventHandler Render;
        public event EventHandler Destroy;

        public int Width
        {
            get => window.ClientSize.Width;
            set => window.ClientSize = new Size(value, window.ClientSize.Height);
        }

        public int Height
        {
            get => window.ClientSize.Height;
            set => window.ClientSize = new Size(window.ClientSize.Width, value);
        }

        public string Title
        {
            get => window.Title;
            set => window.Title = value;
        }

        bool running = false;

        public RenderWindow(int width, int height, string title)
        {
            window = new GameWindow(width, height, GraphicsMode.Default, title, GameWindowFlags.Default);

            window.UpdateFrame += Window_UpdateFrame;
            window.RenderFrame += Window_RenderFrame;
            window.Unload += Window_Unload;
            window.Resize += Window_Resize;
        }

        private void Window_UpdateFrame(object sender, FrameEventArgs e)
        {
            Update?.Invoke(this, EventArgs.Empty);
        }

        private void Window_RenderFrame(object sender, FrameEventArgs e)
        {
            Render?.Invoke(this, EventArgs.Empty);
            window.SwapBuffers();
        }

        private void Window_Unload(object sender, EventArgs e)
        {
            Destroy?.Invoke(this, EventArgs.Empty);
        }

        private void Window_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            Render?.Invoke(this, EventArgs.Empty);
            window.SwapBuffers();
        }

        public void Open()
        {
            if (running)
            {
                return;
            }

            Init?.Invoke(this, EventArgs.Empty);
            window.VSync = VSyncMode.Off;
            window.Run(UPS, 0);

            running = true;
        }

        public double GetFPS()
        {
            return window.RenderFrequency;
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
