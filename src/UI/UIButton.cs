using BoidSimulation.Input;
using Microsoft.Xna.Framework;

namespace BoidSimulation.UI
{
    public class UIButton : UIElement
    {
        public Action OnClickAction;

        public UIButton(Action onClickAction)
        {
            OnClickAction = onClickAction;
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle mouseRectangle = new((int)MouseInputSystem.CurrentPosition.X, (int)MouseInputSystem.CurrentPosition.Y, 8, 8);
            Rectangle elementRectangle = new((int)Position.X, (int)Position.Y, Width, Height);

            if (mouseRectangle.Intersects(elementRectangle))
            {
                if (MouseInputSystem.JustLeftClicked || MouseInputSystem.JustRightClicked)
                {
                    OnClickAction.Invoke();
                }
            }

            base.Update(gameTime);
        }
    }
}