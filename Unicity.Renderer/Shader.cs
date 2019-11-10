using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Unicity.Renderer
{
    class Shader
    {
        int program = 0;

        public Shader(string vertexCode, string fragmentCode)
        {
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);

            GL.ShaderSource(vertexShader, vertexCode);
            GL.ShaderSource(fragmentShader, fragmentCode);

            GL.CompileShader(vertexShader);
            GL.CompileShader(fragmentShader);

            if (!ShaderCompiled(vertexShader))
            {
                GL.DeleteShader(vertexShader);
                GL.DeleteBuffer(fragmentShader);
                throw new Exception("Failed to compile vertex shader: " + GL.GetShaderInfoLog(vertexShader));
            }

            if (!ShaderCompiled(fragmentShader))
            {
                GL.DeleteShader(vertexShader);
                GL.DeleteBuffer(fragmentShader);
                throw new Exception("Failed to compile frgament shader: " + GL.GetShaderInfoLog(fragmentShader));
            }

            program = GL.CreateProgram();
            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);

            GL.LinkProgram(program);

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            if (!ProgramCompiled(program))
            {
                GL.DeleteProgram(program);
                throw new Exception("Failed to link shader program: " + GL.GetProgramInfoLog(program));
            }
        }

        public void Use()
        {
            GL.UseProgram(program);
        }

        public void SetUniform(string name, Vector4 value)
        {
            int location = GL.GetUniformLocation(program, name);
            GL.Uniform4(location, value);
        }

        private bool ShaderCompiled(int shader)
        {
            int[] output = new int[1];
            GL.GetShader(shader, ShaderParameter.CompileStatus, output);
            return output[0] != 0;
        }

        private bool ProgramCompiled(int program)
        {
            int[] output = new int[1];
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, output);
            return output[0] != 0;
        }
    }
}
