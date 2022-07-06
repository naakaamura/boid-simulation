using Microsoft.Xna.Framework;

namespace BoidSimulation.Components
{
    public interface ICustomUpdatable
    {
        public abstract void Update(GameTime gameTime);
    }
}