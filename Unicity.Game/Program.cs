using Unicity.Engine;

namespace Unicity.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GameWindow gameWindow = new GameWindow(400, 400, "Render Test"))
            {
                gameWindow.Open();
            }
        }
    }
}
