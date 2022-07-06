using Microsoft.Xna.Framework;

namespace BoidSimulation.Extensions
{
    public static class GameTimeExtensions
    {
        public static float GetDelta(this GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}