using BoidSimulation.Management;
using BoidSimulation.Systems;
using BoidSimulation.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.Boids
{
    public sealed class BoidSystem : GameSystem
    {
        public static List<Boid> Boids { get; private set; }

        public override void LoadContent()
        {
            Boid.MaxForce = 8f;
            Boid.MaxSpeed = 32f;
            Boid.MaxView = 128f;
            
            Boids = new List<Boid>();

            base.LoadContent();
        }

        public override void UnloadContent()
        {
            Boids?.Clear();
            Boids = null;

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Boid boid in Boids)
            {
                boid.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Boid boid in Boids)
            {
                boid.Draw(spriteBatch);
            }
            
            base.Draw(spriteBatch);
        }

        public static Boid SpawnInRandomPoint()
        {
            Boid boid = new()
            {
                Position = new Vector2(BoidGame.Random.Next((int)ScreenUtils.ScreenWidth), BoidGame.Random.Next((int)ScreenUtils.ScreenHeight))
            };
            Boids.Add(boid);

            return boid;
        }

        public static void KillLastBoid()
        {
            if (Boids.Count > 0)
            {
                Boids.RemoveAt(0);
            }
        }

        public static void ResetBoids()
        {
            ContentInstanceManager.GetInstance<BoidSystem>().UnloadContent();
            ContentInstanceManager.GetInstance<BoidSystem>().LoadContent();
        }
    }
}