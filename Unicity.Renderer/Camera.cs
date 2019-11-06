using OpenTK;

namespace Unicity.Renderer
{
    public enum CameraProjectionMode
    {
        Ortographic,
        Perspective
    }

    public class Camera
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;

        Matrix4 projectionMatrix = Matrix4.Identity;

        CameraProjectionMode projectionMode = CameraProjectionMode.Ortographic;

        public Camera(CameraProjectionMode projectionMode = CameraProjectionMode.Ortographic)
        {
            this.projectionMode = projectionMode;
        }

        public void Initialize()
        {
            switch (projectionMode)
            {
                case CameraProjectionMode.Ortographic:
                    projectionMatrix = Matrix4.CreateOrthographic(600f, 600.0f, 0.1f, 100f);
                    break;
                case CameraProjectionMode.Perspective:
                    projectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), 1f, 0.1f, 100f);
                    break;
                    
            }
        }

        public void UpdateView(Shader shader)
        {
            Matrix4 modelMatrix = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(-55.0f));
            Matrix4 viewMatrix = Matrix4.CreateTranslation(0.0f, 0.0f, -8.0f);

            shader.SetUniform("model", modelMatrix);
            shader.SetUniform("view", viewMatrix);
            shader.SetUniform("projection", projectionMatrix);
        }
    }
}
