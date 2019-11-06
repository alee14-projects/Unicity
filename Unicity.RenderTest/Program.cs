using Unicity.Renderer;
using Unicity.Renderer.Shapes;

namespace Unicity.RenderTest
{
    class Program
    {
        static RenderWindow window = null;
        static Camera camera = null;
        static GraphicsRenderer renderer = null;

        static Rectangle[] cube = null;

        static void Main(string[] args)
        {
            camera = new Camera(CameraProjectionMode.Perspective);

            using (window = new RenderWindow(400, 400, "Render Test"))
            using (renderer = new GraphicsRenderer(window, camera))
            {
                window.Init += Window_Init;
                window.Update += Window_Update;
                window.Render += Window_Render;
                window.Destroy += Window_Destroy;

                window.Open();
            }
        }

        private static void Window_Init(object sender, System.EventArgs e)
        {
            renderer.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            renderer.SetDrawColor(1.0f, 0.0f, 1.0f);

            cube = new Rectangle[]
            {
                new Rectangle(-1.0f,  1.0f, -1.0f,
                               1.0f,  1.0f, -1.0f,
                              -1.0f, -1.0f, -1.0f,
                               1.0f, -1.0f, -1.0f),

                new Rectangle(-1.0f,  1.0f,  1.0f,
                               1.0f,  1.0f,  1.0f,
                              -1.0f, -1.0f,  1.0f,
                               1.0f, -1.0f,  1.0f),

                new Rectangle(-1.0f,  1.0f,  1.0f,
                               1.0f,  1.0f,  1.0f,
                              -1.0f,  1.0f, -1.0f,
                               1.0f,  1.0f, -1.0f),

                new Rectangle(-1.0f, -1.0f,  1.0f,
                               1.0f, -1.0f,  1.0f,
                              -1.0f, -1.0f, -1.0f,
                               1.0f, -1.0f, -1.0f),

                new Rectangle(-1.0f,  1.0f, -1.0f,
                              -1.0f,  1.0f,  1.0f,
                              -1.0f, -1.0f, -1.0f,
                              -1.0f, -1.0f, -1.0f),

                new Rectangle(1.0f,  1.0f, -1.0f,
                              1.0f,  1.0f,  1.0f,
                              1.0f, -1.0f, -1.0f,
                              1.0f, -1.0f, -1.0f)
            };
        }

        private static void Window_Update(object sender, System.EventArgs e)
        {
            
        }

        private static void Window_Render(object sender, System.EventArgs e)
        {
            renderer.ClearScreen();
            renderer.DrawShapes(cube);
        }

        private static void Window_Destroy(object sender, System.EventArgs e)
        {
            foreach (Rectangle rect in cube)
            {
                rect.Dispose();
            }
        }
    }
}
