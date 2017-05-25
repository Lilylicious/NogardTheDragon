using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Managers;

namespace NogardTheDragon.Utilities
{
    public class StandardButton
    {
        public bool ButtonClicked;
        public Color C;
        public Rectangle Rect;

        public StandardButton(Rectangle rect)
        {
            Rect = rect;
        }

        public void Update(Color color, Color hoverColor)
        {
            if (Rect.Contains(KeyMouseReader.MousePosition))
                C = hoverColor;
            else
                C = color;

            if (Rect.Contains(KeyMouseReader.MousePosition) && KeyMouseReader.LeftClick())
                ButtonClicked = true;
            else
                ButtonClicked = false;
        }

        public void DrawStandardButton(int lineWidth, string buttonText, float textSize)
        {
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X, Rect.Y, lineWidth, Rect.Height),
                C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X, Rect.Y, Rect.Width, lineWidth),
                C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton,
                new Rectangle(Rect.X + Rect.Width, Rect.Y, lineWidth, Rect.Height + lineWidth), C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton,
                new Rectangle(Rect.X, Rect.Y + Rect.Height, Rect.Width + lineWidth, lineWidth), C);

            NogardGame.SpriteBatch.DrawString(TextureManager.Font, buttonText,
                new Vector2(Rect.X + Rect.Width / 10 * textSize, Rect.Y + Rect.Height / 5),
                C, 0f, Vector2.Zero, textSize, SpriteEffects.None, 1f);
        }
    }
}