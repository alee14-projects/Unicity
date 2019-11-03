using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using GLFW;

namespace Unicity.Renderer
{
    public class RenderWindow : IDisposable
    {
        const int FPS = 60;

        internal NativeWindow window = null;

        Stopwatch loopTimer = new Stopwatch();

        public event EventHandler Init;
        public event EventHandler Update;
        public event EventHandler Render;

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

        public RenderWindow(int width, int height, string title)
        {
            if (!File.Exists(Glfw.LIBRARY + ".dll"))
            {
                throw new WindowCreationFailedException("A required library file is missing and operation cannot continue.");
            }

            if (!Glfw.Init())
            {
                throw new WindowCreationFailedException("Failed to initialize GLFW.");
            }

            window = new NativeWindow(width, height, title);
            window.SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, SizeChangeEventArgs e)
        {
            GraphicsRenderer.GL.Viewport(0, 0, Width, Height);
            UpdateWindow();
        }

        public void StartUpdateLoop()
        {
            if (loopTimer.IsRunning) return;

            loopTimer.Start();

            Init?.Invoke(this, EventArgs.Empty);

            while (!window.IsClosed)
            {
                Glfw.PollEvents();

                if (!window.IsClosing) UpdateWindow();
            }

            loopTimer.Stop();
        }

        private void UpdateWindow()
        {
            if (loopTimer.Elapsed.TotalMilliseconds >= 1000 / FPS)
            {
                loopTimer.Restart();

                Update?.Invoke(this, EventArgs.Empty);
                Render?.Invoke(this, EventArgs.Empty);

                window.SwapBuffers();
            }
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
            Glfw.Terminate();

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
