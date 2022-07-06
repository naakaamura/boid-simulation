using BoidSimulation.Components;
using BoidSimulation.Management;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.Systems
{
    public static class ComponentManager
    {
        internal static void UpdateComponents(GameTime gameTime)
        {
            foreach (object contentInstance in ContentInstanceManager.ContentInstances)
            {
                if (contentInstance is ICustomUpdatable updatable)
                {
                    updatable.Update(gameTime);
                }
            }
        }

        internal static void DrawComponents(SpriteBatch spriteBatch)
        {
            foreach (object contentInstance in ContentInstanceManager.ContentInstances)
            {
                if (contentInstance is ICustomDrawable drawable)
                {
                    drawable.Draw(spriteBatch);
                }
            }
        }
    }
}