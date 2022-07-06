using BoidSimulation.Components;
using BoidSimulation.Management;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.Systems
{
    public abstract class GameSystem : IContentInstance, ICustomUpdatable, ICustomDrawable
    {
        public virtual void LoadContent() { }

        public virtual void UnloadContent() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}