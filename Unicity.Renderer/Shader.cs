using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Unicity.Renderer
{
    public class Shader
    {
        int id = 0;

        public Shader(string vertexShaderSource, string fragmentShaderSource)
        {
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            int[] isCompiled = new int[1];
            GL.GetShader(vertexShader, ShaderParameter.CompileStatus, isCompiled);
            if (isCompiled[0] == 0)
            {
                string infoLog = GL.GetShaderInfoLog(vertexShader);
                GL.DeleteShader(vertexShader);
                throw new ShaderCompilationFailedException("Failed to compile vertex shader:\n" + infoLog);
            }

            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            GL.GetShader(fragmentShader, ShaderParameter.CompileStatus, isCompiled);
            if (isCompiled[0] == 0)
            {
                string infoLog = GL.GetShaderInfoLog(fragmentShader);
                GL.DeleteShader(fragmentShader);
                GL.DeleteShader(vertexShader);
                throw new ShaderCompilationFailedException("Failed to compile fragment shader:\n" + infoLog);
            }

            int program = GL.CreateProgram();

            GL.AttachShader(program, vertexShader);
            GL.AttachShader(program, fragmentShader);

            GL.LinkProgram(program);

            int[] isLinked = new int[1];
            GL.GetProgram(program, GetProgramParameterName.LinkStatus, isLinked);
            if (isLinked[0] == 0)
            {
                string infoLog = GL.GetProgramInfoLog(program);
                GL.DeleteProgram(program);
                GL.DeleteShader(fragmentShader);
                GL.DeleteShader(vertexShader);
                throw new ShaderCompilationFailedException("Failed to link shader program");
            }

            GL.DetachShader(program, vertexShader);
            GL.DetachShader(program, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            id = program;
        }

        public void Use()
        {
            GL.UseProgram(id);
        }

        public void SetUniform(string name, Matrix4 value)
        {
            int uniformLocation = GL.GetUniformLocation(id, name);

            GL.UniformMatrix4(uniformLocation, false, ref value);
        }

        public void SetUniform(string name, Vector3 value)
        {
            int uniformLocation = GL.GetUniformLocation(id, name);

            GL.Uniform3(uniformLocation, ref value);
        }

        public void SetUniform(string name, float value)
        {
            int uniformLocation = GL.GetUniformLocation(id, name);

            GL.Uniform1(uniformLocation, value);
        }

        public void Delete()
        {
            GL.DeleteProgram(id);
        }
    }
}
