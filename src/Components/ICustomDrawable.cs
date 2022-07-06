using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.Components
{
    public interface ICustomDrawable
    {
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}