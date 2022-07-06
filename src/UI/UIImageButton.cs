using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.UI
{
    public class UIImageButton : UIButton
    {
        public Texture2D Texture;

        public UIImageButton(Action onClickAction, Texture2D texture) : base(onClickAction)
        {
            Texture = texture;
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);

            base.Draw(spriteBatch);
        }
    }
}