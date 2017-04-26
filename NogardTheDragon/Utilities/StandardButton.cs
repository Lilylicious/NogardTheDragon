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
        public Rectangle rect;
        public Color c = Color.Goldenrod;
        public bool buttonClicked;

        public StandardButton(Rectangle rect)
        {
            this.rect = rect;
        }

        public void Update(Color color)
        {
            if (rect.Contains(KeyMouseReader.mousePosition))
            {
                c = color;
            }
            else
                c = Color.Goldenrod;

            if (rect.Contains(KeyMouseReader.mousePosition) && KeyMouseReader.LeftClick())
            {
                buttonClicked = true;
            }
            else
                buttonClicked = false;
        }

        public void DrawStandardButton(int lineWidth, string buttonText, float textSize)
        {            
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(rect.X, rect.Y, lineWidth, rect.Height), c);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(rect.X, rect.Y, rect.Width, lineWidth), c);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(rect.X + rect.Width, rect.Y, lineWidth, rect.Height + lineWidth), c);
            NogardGame.SpriteBatch.Draw(TextureManager.RectButton, new Rectangle(rect.X, rect.Y + rect.Height, rect.Width + lineWidth, lineWidth), c);

            NogardGame.SpriteBatch.DrawString(TextureManager.Font, buttonText, 
                new Vector2((rect.X  + rect.Width / 10), (rect.Y + rect.Height / 5)),
                c, 0f, Vector2.Zero, textSize, SpriteEffects.None, 1f);
        }

    }
}
