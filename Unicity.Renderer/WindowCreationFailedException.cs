using System;

namespace Unicity.Renderer
{
    class WindowCreationFailedException : Exception
    {
        public WindowCreationFailedException(string message) : base(message)
        {

        }
    }
}
