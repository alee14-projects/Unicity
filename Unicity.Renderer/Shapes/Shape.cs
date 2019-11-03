using System;
using static Unicity.Renderer.GraphicsRenderer;

namespace Unicity.Renderer.Shapes
{
    public class Shape : IDisposable
    {
        protected uint[] buffers = new uint[1];

        public void Dispose()
        {
            GL.DeleteBuffers(1, buffers);
        }

        internal virtual void Render() { }
    }
}
