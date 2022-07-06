using BoidSimulation.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.UI
{
    public class UIElement : ICustomUpdatable, ICustomDrawable
    {
        public Vector2 Position;

        public int Width;
        public int Height;

        public virtual void Update(GameTime gameTime) { }
        
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}