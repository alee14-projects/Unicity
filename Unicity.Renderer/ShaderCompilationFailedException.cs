using System;

namespace Unicity.Renderer
{
    class ShaderCompilationFailedException : Exception
    {
        public ShaderCompilationFailedException(string message) : base(message) { }
    }
}
