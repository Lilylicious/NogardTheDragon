//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;

//namespace NogardTheDragon.Animation
//{
//    class Background
//    {
//        List<Vector2> background;
//        int bgSpacing;
//        float bgSpeed;
//        Texture2D[] tex;
//        GameWindow window;
//        public Background(ContentManager Content, GameWindow window)
//        {
//            this.tex = new Texture2D[3];
//            this.window = window;
//            tex[0] = Content.Load<Texture2D>("");

//            background = new List<Vector2>();
//            bgSpacing = tex[0].Width;
//            bgSpeed = 0.10f;
//            for (int i = 0; i < (window.ClientBounds.Width / bgSpacing) + 2; i++)
//            {
//                background.Add(new Vector2(i * bgSpacing, window.ClientBounds.Height - tex[0].Height));
//            }
//        }

//        public void Update()
//        {
//            for (int i = 0; i < background.Count; i++)
//            {
//                background[i] = new Vector2(background[i].Y - bgSpeed, background[i].X);
//                if (background[i].Y <= -bgSpacing)
//                {
//                    int j = i - 1;
//                    if (j < 0)
//                    {
//                        j = background.Count - 1;
//                    }
//                    background[i] = new Vector2(background[j].Y + bgSpacing - 1, background[i].X);
//                }
//            }
//        }

//        public void Draw(SpriteBatch sb)
//        {
//            foreach (Vector2 v in background)
//            {
//                sb.Draw(tex[0], v, Color.White);
//            }
//        }
//    }
//}

