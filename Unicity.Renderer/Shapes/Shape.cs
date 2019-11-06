using System;

namespace Unicity.Renderer.Shapes
{
    public class Shape : IDisposable
    {
        internal virtual void Draw(Shader shader, GraphicsRenderer renderer)
        {

        }

        public virtual void Dispose()
        {

        }
    }
}
