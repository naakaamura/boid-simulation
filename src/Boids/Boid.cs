using BoidSimulation.Components;
using BoidSimulation.Extensions;
using BoidSimulation.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.Boids
{
    public sealed class Boid : ICustomUpdatable, ICustomDrawable
    {
        public static float MaxForce = 8f;
        public static float MaxSpeed = 32f;
        public static float MaxView = 128f;

        public const int Width = 8;
        public const int Height = 8;
        
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
     
        public void Update(GameTime gameTime)
        {
            ApplyCollision();
            
            ApplyCohesion();
            ApplySeparation();
            ApplyAllignment();

            Velocity += Acceleration * gameTime.GetDelta();
            Velocity = Velocity.LimitLength(MaxSpeed);

            Position += Velocity * gameTime.GetDelta();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = BoidGame.Instance.Content.Load<Texture2D>("Assets/Textures/Boid");
            float rotation = Velocity.ToRotation() + MathHelper.PiOver2;
            
            spriteBatch.Draw(texture, Position, null, Color.White, rotation, texture.GetSize() / 2f, 0.5f, SpriteEffects.None, 0f);
        }

        private void ApplyCohesion()
        {
            Vector2 steer = Vector2.Zero;
            int otherBoidCount = 0;

            foreach (Boid otherBoid in BoidSystem.Boids)
            {
                if (otherBoid != this)
                {
                    float distance = Vector2.DistanceSquared(Position, otherBoid.Position);
                    
                    if (distance > 0f && distance < MaxView * MaxView)
                    {
                        steer += otherBoid.Position;
                        
                        otherBoidCount++;
                    }
                }
            }
                    
            if (otherBoidCount > 0)
            {
                steer /= otherBoidCount;
            }

            if (steer != Vector2.Zero)
            {
                steer -= Position;
                steer.Normalize();
                steer *= MaxSpeed;

                Vector2 acceleration = (steer - Velocity).LimitLength(MaxForce);
                Acceleration += acceleration;
            }
        }

        private void ApplySeparation()
        {
            Vector2 steer = Vector2.Zero;
            int otherBoidCount = 0;

            foreach (Boid otherBoid in BoidSystem.Boids)
            {
                if (otherBoid != this)
                {
                    float distance = Vector2.DistanceSquared(Position, otherBoid.Position);

                    if (distance > 0f && distance < MaxView * MaxView)
                    {
                        Vector2 direction = Position - otherBoid.Position;
                        direction.Normalize();
                        
                        Vector2 weight = direction / distance;
                        steer += weight;

                        otherBoidCount++;
                    }
                }
            }

            if (otherBoidCount > 0)
            {
                steer /= otherBoidCount;
            }

            if (steer != Vector2.Zero)
            {
                steer.Normalize();
                steer *= MaxSpeed;

                Vector2 acceleration = (steer - Velocity).LimitLength(MaxForce);
                Acceleration += acceleration;
            }
        }

        private void ApplyAllignment()
        {
            Vector2 steer = Vector2.Zero;
            int otherBoidCount = 0;

            foreach (Boid otherBoid in BoidSystem.Boids)
            {
                if (otherBoid != this)
                {
                    float distance = Vector2.DistanceSquared(Position, otherBoid.Position);

                    if (distance > 0f && distance < MaxView * MaxView)
                    {
                        steer += otherBoid.Velocity;

                        otherBoidCount++;
                    }
                }
            }

            if (otherBoidCount > 0)
            {
                steer /= otherBoidCount;
            }

            if (steer != Vector2.Zero)
            {
                steer.Normalize();
                steer *= MaxSpeed;

                Vector2 acceleration = (steer - Velocity).LimitLength(MaxForce);
                Acceleration += acceleration;
            }
        }

        private void ApplyCollision()
        {
            if (Position.X < Width)
            {
                Position.X = Width;
            }
            else if (Position.X > ScreenUtils.ScreenWidth - Width)
            {
                Position.X = ScreenUtils.ScreenWidth - Width;
            }

            if (Position.Y < Height)
            {
                Position.Y = Height;
            }
            else if (Position.Y > ScreenUtils.ScreenHeight - Height)
            {
                Position.Y = ScreenUtils.ScreenHeight - Height;
            }
        }
    }
}