using BoidSimulation.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BoidSimulation.UI
{
    public sealed class UISystem : GameSystem
    {
        public static List<UIElement> Elements { get; private set; }

        public override void LoadContent()
        {
            Elements = new List<UIElement>();
            
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            Elements?.Clear();
            Elements = null;

            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Elements.ForEach(x => x.Update(gameTime));

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Elements.ForEach(x => x.Draw(spriteBatch));

            base.Draw(spriteBatch);
        }

        public static T ActivateElement<T>(T element) where T : UIElement
        {
            Elements.Add(element);
            return element;
        }

        public static bool DeactivateElement<T>(T element) where T : UIElement
        {
            return Elements.Remove(element);   
        }
    }
}