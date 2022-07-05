using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation
{
    public sealed class BoidGame : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        public BoidGame() : base()
        {
            Graphics = new(this);

            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            base.LoadContent();
        }
    }
}