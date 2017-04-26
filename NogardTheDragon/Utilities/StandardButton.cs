using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NogardTheDragon.Utilities
{
    public class StandardButton
    {
        public Rectangle Rect;
        public Color C = Color.Goldenrod;
        public bool ButtonClicked;

        public StandardButton(Rectangle rect)
        {
            this.Rect = rect;
        }

        public void Update(Color color)
        {
            if (Rect.Contains(KeyMouseReader.MousePosition))
            {
                C = color;
            }
            else
                C = Color.Goldenrod;

            if (Rect.Contains(KeyMouseReader.MousePosition) && KeyMouseReader.LeftClick())
            {
                ButtonClicked = true;
            }
            else
                ButtonClicked = false;
        }

        public void DrawStandardButton(int lineWidth, string buttonText, float textSize)
        {            
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X, Rect.Y, lineWidth, Rect.Height), C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X, Rect.Y, Rect.Width, lineWidth), C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X + Rect.Width, Rect.Y, lineWidth, Rect.Height + lineWidth), C);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(Rect.X, Rect.Y + Rect.Height, Rect.Width + lineWidth, lineWidth), C);

            NogardGame.SpriteBatch.DrawString(TextureManager.Font, buttonText, 
                new Vector2((Rect.X  + Rect.Width / 10), (Rect.Y + Rect.Height / 5)),
                C, 0f, Vector2.Zero, textSize, SpriteEffects.None, 1f);
        }

    }
}
