using NogardTheDragon.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NogardTheDragon
{
    public class StoryMode : BaseManager
    {
        public enum StoryState
        {
            IntroStory,
            FirstStory,
            SecondStory,
            LastStory
        }

        public static StoryState Story = StoryState.IntroStory;
        public static bool IntroStory = true;

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.Story;
        }

        public override void Update(GameTime gameTime)
        {
            if (NogardGame.MapsComplete == 1)
                    Story = StoryState.FirstStory;
            if (NogardGame.MapsComplete == 2)
                Story = StoryState.SecondStory;
            if (NogardGame.MapsComplete > 2)
                Story = StoryState.LastStory;

            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.BackButton))
                {
                    NogardGame.MainMenuManager.Init();
                }

                else if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ContinueButton))
                {
                    if (NogardGame.MapsComplete == 0)
                        NogardGame.GamePlayManager.StartMap("LevelOne");
                    if (NogardGame.MapsComplete == 1)
                        NogardGame.GamePlayManager.StartMap("LevelTwo");
                    if (NogardGame.MapsComplete == 2)
                        NogardGame.GamePlayManager.StartMap("LevelThree");
                    if (NogardGame.MapsComplete > 2)
                        NogardGame.GameOverManager.Win();
                }
            }
        }

        public override void Draw()
        {
            switch (Story)
            {
                case StoryState.IntroStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "Nogard is a sweet, purple, puppyeyed baby dragon," +
                      "\nwho is very brave but happens to be afraid of heights." +
                      "\nAnd, This, is his story:" +
                      "\n" +
                      "\nIt was windy and rainy day when brave little Nogard" +
                      "\nwanted to prove to his teasing, older siblings that" +
                      "\nhe did know how fly. Just like a real dragon." +
                      "\nHe mustered up all of his courage, took a deep breath" +
                      "\nand started to run. Nogard closed his eyes and felt the" +
                      "\nair under his wings as his small feet started to lift" +
                      "\nfrom the ground. Just when he went over the cliff of" +
                      "\nthe Mountain of Dragons, Nogard couldn't help but to" +
                      "\nopen his eyes and look down, only to find the dark abyss" +
                      "\n staring back up at him. When he realized there was nothing" +
                      "\nbetween him and the hard ground down below, Nogards whole" +
                      "\nbody got numb and made his wings freeze up. The small," +
                      "\nbrave dragon went crashing down...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.FirstStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "FIIIIIIIIIIIIRST TEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEXXXXTTTTTTTT" +
                      "\nwho is very brave but happens to be afraid of heights." +
                      "\nAnd, This, is his story:" +
                      "\n" +
                      "\nIt was windy and rainy day when brave little Nogard" +
                      "\nwanted to prove to his teasing, older siblings that" +
                      "\nhe did know how fly. Just like a real dragon." +
                      "\nHe mustered up all of his courage, took a deep breath" +
                      "\nand started to run. Nogard closed his eyes and felt the" +
                      "\nair under his wings as his small feet started to lift" +
                      "\nfrom the ground. Just when he went over the cliff of" +
                      "\nthe Mountain of Dragons, Nogard couldn't help but to" +
                      "\nopen his eyes and look down, only to find the dark abyss" +
                      "\n staring back up at him. When he realized there was nothing" +
                      "\nbetween him and the hard ground down below, Nogards whole" +
                      "\nbody got numb and made his wings freeze up. The small," +
                      "\nbrave dragon went crashing down...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.SecondStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "SECOOOOOOND TEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEXXXXTTTTTTTT" +
                      "\nwho is very brave but happens to be afraid of heights." +
                      "\nAnd, This, is his story:" +
                      "\n" +
                      "\nIt was windy and rainy day when brave little Nogard" +
                      "\nwanted to prove to his teasing, older siblings that" +
                      "\nhe did know how fly. Just like a real dragon." +
                      "\nHe mustered up all of his courage, took a deep breath" +
                      "\nand started to run. Nogard closed his eyes and felt the" +
                      "\nair under his wings as his small feet started to lift" +
                      "\nfrom the ground. Just when he went over the cliff of" +
                      "\nthe Mountain of Dragons, Nogard couldn't help but to" +
                      "\nopen his eyes and look down, only to find the dark abyss" +
                      "\n staring back up at him. When he realized there was nothing" +
                      "\nbetween him and the hard ground down below, Nogards whole" +
                      "\nbody got numb and made his wings freeze up. The small," +
                      "\nbrave dragon went crashing down...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.LastStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "LAST FINAL TEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEXXXXTTTTTTTT" +
                      "\nwho is very brave but happens to be afraid of heights." +
                      "\nAnd, This, is his story:" +
                      "\n" +
                      "\nIt was windy and rainy day when brave little Nogard" +
                      "\nwanted to prove to his teasing, older siblings that" +
                      "\nhe did know how fly. Just like a real dragon." +
                      "\nHe mustered up all of his courage, took a deep breath" +
                      "\nand started to run. Nogard closed his eyes and felt the" +
                      "\nair under his wings as his small feet started to lift" +
                      "\nfrom the ground. Just when he went over the cliff of" +
                      "\nthe Mountain of Dragons, Nogard couldn't help but to" +
                      "\nopen his eyes and look down, only to find the dark abyss" +
                      "\n staring back up at him. When he realized there was nothing" +
                      "\nbetween him and the hard ground down below, Nogards whole" +
                      "\nbody got numb and made his wings freeze up. The small," +
                      "\nbrave dragon went crashing down...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
            }
        }
    }
}
