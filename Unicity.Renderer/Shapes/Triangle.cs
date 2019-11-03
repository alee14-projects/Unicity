using System;
using System.Drawing;
using static Unicity.Renderer.GraphicsRenderer;
using static SharpGL.OpenGL;

namespace Unicity.Renderer.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(PointF pos1, PointF pos2, PointF pos3)
        {
            Init(pos1.X, pos1.Y, pos2.X, pos2.Y, pos3.X, pos3.Y);
        }

        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            Init(x1, y1, x2, y2, x3, y3);
        }

        private void Init(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            float[] data =
            {
                x1, y1,
                x2, y2,
                x3, y3
            };

            GL.GenBuffers(1, buffers);
            GL.BindBuffer(GL_ARRAY_BUFFER, buffers[0]);
            GL.BufferData(GL_ARRAY_BUFFER, data, GL_STATIC_DRAW);
        }

        internal override void Render()
        {
            GL.EnableVertexAttribArray(0);
            GL.BindBuffer(GL_ARRAY_BUFFER, buffers[0]);
            GL.VertexAttribPointer(0, 2, GL_FLOAT, false, 0, IntPtr.Zero);
            GL.DrawArrays(GL_TRIANGLES, 0, 3);
            GL.DisableVertexAttribArray(0);
        }
    }
}
