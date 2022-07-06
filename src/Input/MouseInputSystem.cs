using BoidSimulation.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BoidSimulation.Input
{
    public sealed class MouseInputSystem : GameSystem
    {
        public static MouseState CurrentState { get; private set; }
        public static MouseState PreviousState { get; private set; }

        public static Vector2 CurrentPosition { get; private set; }
        public static Vector2 PreviousPosition { get; private set; }

        public static bool JustLeftClicked => CurrentState.LeftButton == ButtonState.Pressed && PreviousState.LeftButton == ButtonState.Released;
        public static bool JustRightClicked => CurrentState.RightButton == ButtonState.Pressed && PreviousState.RightButton == ButtonState.Released;

        public override void Update(GameTime gameTime)
        {
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();

            PreviousPosition = CurrentPosition;
            CurrentPosition = new Vector2(CurrentState.X, CurrentState.Y);

            base.Update(gameTime);
        }
    }
}