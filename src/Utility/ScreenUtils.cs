namespace BoidSimulation.Utility
{
    public static class ScreenUtils
    {
        public static float ScreenWidth => BoidGame.Instance.GraphicsDevice.Viewport.Width;
        public static float ScreenHeight => BoidGame.Instance.GraphicsDevice.Viewport.Height;
    }
}