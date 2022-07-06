using BoidSimulation.Boids;
using BoidSimulation.Management;
using BoidSimulation.Systems;
using BoidSimulation.UI;
using BoidSimulation.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation
{
    public sealed class BoidGame : Game
    {
        public static GraphicsDeviceManager Graphics { get; private set; } 
        public static SpriteBatch SpriteBatch { get; private set; }
        public static BoidGame Instance { get; private set; }
        public static Random Random { get; private set; }

        public BoidGame() : base()
        {
            if (Instance is not null)
            {
                throw new InvalidOperationException("Game does not support multiple instances.");
            }

            Instance = this;

            IsMouseVisible = true;
            IsFixedTimeStep = false;

            Graphics = new(Instance);
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Random = new Random(694201337);

            ContentInstanceManager.LoadInstances();

            InitializeButtons();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            ContentInstanceManager.UnloadInstances();

            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            ComponentManager.UpdateComponents(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin();

            ComponentManager.DrawComponents(SpriteBatch);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        private void InitializeButtons()
        {
            // Spawn.
            UISystem.ActivateElement(new UIImageButton(() => BoidSystem.SpawnInRandomPoint(), Content.Load<Texture2D>("Assets/Textures/SpawnButton"))
            {
                Position = new Vector2(40f, ScreenUtils.ScreenHeight - 40f)
            });

            // Kill.
            UISystem.ActivateElement(new UIImageButton(() => BoidSystem.KillLastBoid(), Content.Load<Texture2D>("Assets/Textures/KillButton"))
            {
                Position = new Vector2(40f * 2f, ScreenUtils.ScreenHeight - 40f)
            });

            // Add Force.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxForce++, Content.Load<Texture2D>("Assets/Textures/AddForceButton"))
            {
                Position = new Vector2(40f * 3f, ScreenUtils.ScreenHeight - 40f)
            });

            // Reduce Force.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxForce--, Content.Load<Texture2D>("Assets/Textures/ReduceForceButton"))
            {
                Position = new Vector2(40f * 4f, ScreenUtils.ScreenHeight - 40f)
            });

            // Add Speed.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxSpeed++, Content.Load<Texture2D>("Assets/Textures/AddSpeedButton"))
            {
                Position = new Vector2(40f * 5f, ScreenUtils.ScreenHeight - 40f)
            });

            // Reduce Speed.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxSpeed--, Content.Load<Texture2D>("Assets/Textures/ReduceSpeedButton"))
            {
                Position = new Vector2(40f * 6f, ScreenUtils.ScreenHeight - 40f)
            });

            // Add View.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxView++, Content.Load<Texture2D>("Assets/Textures/AddViewButton"))
            {
                Position = new Vector2(40f * 7f, ScreenUtils.ScreenHeight - 40f)
            });
            // Reduce View.
            UISystem.ActivateElement(new UIImageButton(() => Boid.MaxView--, Content.Load<Texture2D>("Assets/Textures/ReduceViewButton"))
            {
                Position = new Vector2(40f * 8f, ScreenUtils.ScreenHeight - 40f)
            });
            
            // Reset.
            UISystem.ActivateElement(new UIImageButton(() => BoidSystem.ResetBoids(), Content.Load<Texture2D>("Assets/Textures/ResetButton"))
            {
                Position = new Vector2(40f * 9f, ScreenUtils.ScreenHeight - 40f)
            });
        }
    }
}