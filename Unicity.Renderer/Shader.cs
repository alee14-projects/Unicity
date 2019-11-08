using System;
using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer
{
    class Shader
    {
        //int program = 0;

        public Shader(string vertexCode, string fragmentCode)
        {
            int vertex = GL.CreateShader(ShaderType.VertexShader);

            GL.ShaderSource(vertex, vertexCode);
            GL.CompileShader(vertex);

            if (!Compiled(vertex))
            {
                GL.DeleteShader(vertex);
                throw new Exception("Failed to compile vertex shader: " + GL.GetShaderInfoLog(vertex));
            }
        }

        private bool Compiled(int shader)
        {
            int[] output = new int[1];
            GL.GetShader(shader, ShaderParameter.CompileStatus, output);
            return output[0] != 0;
        }
    }
}
