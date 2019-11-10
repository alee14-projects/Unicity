using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Unicity.Renderer.Shapes;

namespace Unicity.Renderer
{
    public class GraphicsRenderer : IDisposable
    {
        RenderWindow window = null;

        // Tests
        List<float> triangleVerts = new List<float>();
        int triangleCount = -1;
        int triangleVBO = -1;
        int triangleVAO = -1;

        Shader shader = null;

        bool disposed = false;

        public GraphicsRenderer(RenderWindow window)
        {
            this.window = window;
            window.Render += Window_Render;

            string vertexCode = Encoding.UTF8.GetString(Properties.Resources.vertexShader);
            string fragmentCode = Encoding.UTF8.GetString(Properties.Resources.fragmentShader);

            shader = new Shader(vertexCode, fragmentCode);
            shader.Use();

            shader.SetUniform("inColor", new Vector4(1.0f, 1.0f, 1.0f, 1.0f));

            GL.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);
            SetRenderData(new Shape[0]);
        }

        public void SetRenderData(Shape[] shapes)
        {
            triangleVerts = new List<float>();

            triangleCount = 0;

            for (int i = 0; i < shapes.Length; i++)
            {
                if (typeof(Triangle) == shapes[i].GetType())
                {
                    foreach (float val in ((Triangle)shapes[i]).Vertices)
                    {
                        triangleVerts.Add(val);
                    }

                    triangleCount++;
                }
            }

            for (int i = 0; i < shapes.Length; i++)
            {
                if (typeof(Triangle) == shapes[i].GetType())
                {
                    Vector3 color = ((Triangle)shapes[i]).Color;
                    triangleVerts.Add(color.X);
                    triangleVerts.Add(color.Y);
                    triangleVerts.Add(color.Z);
                    triangleVerts.Add(color.X);
                    triangleVerts.Add(color.Y);
                    triangleVerts.Add(color.Z);
                    triangleVerts.Add(color.X);
                    triangleVerts.Add(color.Y);
                    triangleVerts.Add(color.Z);
                }
            }

            if (triangleVAO != -1)
            {
                GL.DeleteVertexArray(triangleVAO);
            }

            if (triangleVBO != -1)
            {
                GL.DeleteBuffer(triangleVBO);
            }

            triangleVAO = GL.GenVertexArray();
            triangleVBO = GL.GenBuffer();
            
            GL.BindVertexArray(triangleVAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, triangleVBO);
            GL.BufferData(BufferTarget.ArrayBuffer, triangleVerts.Count * sizeof(float), triangleVerts.ToArray(), BufferUsageHint.DynamicDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), triangleVerts.Count / 2 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }

        private void Window_Render(object sender, System.EventArgs e)
        {
            window.MakeCurrent();

            shader.Use();
            
            GL.BindVertexArray(triangleVAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, triangleCount * 3);
            GL.BindVertexArray(0);
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
            GL.DeleteVertexArray(triangleVAO);
            GL.DeleteBuffer(triangleVBO);

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}