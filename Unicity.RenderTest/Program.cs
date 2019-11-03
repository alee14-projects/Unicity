using Unicity.Renderer;
using Unicity.Renderer.Shapes;

namespace Unicity.RenderTest
{
    class Program
    {
        static RenderWindow window = null;
        static GraphicsRenderer renderer = null;

        static Triangle triangle;

        static void Main(string[] args)
        {
            using (window = new RenderWindow(400, 400, "Test123"))
            using (renderer = new GraphicsRenderer(window))
            {
                window.Init += Window_Init;
                window.Update += Window_Update;
                window.Render += Window_Render;

                window.StartUpdateLoop();
            }
        }

        private static void Window_Init(object sender, System.EventArgs e)
        {
            renderer.SetClearColor(0, 1, 0, 1);
            triangle = new Triangle(0.0f, 1.0f, -1.0f, -1.0f, 1.0f, -1.0f);
        }

        private static void Window_Update(object sender, System.EventArgs e)
        {
            
        }

        private static void Window_Render(object sender, System.EventArgs e)
        {
            renderer.ClearScreen();
            renderer.RenderShape(triangle);
        }
    }
}
