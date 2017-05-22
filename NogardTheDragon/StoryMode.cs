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
                      "\nwho lives with his family at Mountain of Dragons." +
                      "\nHe is very brave but happens to be afraid of heights." +
                      "\nAnd, This, is his story:" +
                      "\n" +
                      "\nIt was windy and rainy day when brave little Nogard" +
                      "\nwanted to prove to his teasing, older siblings that" +
                      "\nhe did know how fly. Just like a real dragon." +
                      "\nHe mustered up all of his courage, took a deep breath" +
                      "\nand started to run. Nogard closed his eyes and felt the" +
                      "\nair under his wings as his small feet started to lift" +
                      "\nfrom the ground. Just when he went over the cliff of" +
                      "\nthe mountain, Nogard couldn't help but to" +
                      "\nopen his eyes and look down, only to find the dark abyss" +
                      "\n staring back up at him. When he realized there was nothing" +
                      "\nbetween him and the hard ground down below, Nogards whole" +
                      "\nbody went numb and made his wings freeze up. The small," +
                      "\nbrave dragon went crashing down...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.FirstStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "A few hours passed before Nogard woke up again. He sat up" +
                      "\nand rubbed his little puppyeyes. He checked to see if" +
                      "\nhe was injured but all that he could feel acheing was" +
                      "\nhis tummy, that was screaming for some food." +
                      "\nLonging for a hot, homecooked meal, Nogard looked up" +
                      "\nat the mountain, wondering if his family was looking for" +
                      "\nhim. At the thought of how much he missed his mother, and" +
                      "\nthe embarressment he felt for failing to fly like a real" +
                      "\ndragon, Nogards eyes teared up." +
                      "\nLater as the tears started to dry on his face, Nogards sadness" +
                      "\nturned into determenation." +
                      "\n'I might not be able to fly like a dragon', he thought," +
                      "\n'but I'm gonna prove that I'm the bravest of them all!'." +
                      "\nAs a wild, fiery courage filled his body, Nogard started the" +
                      "\ndangerous climb back to his home and his family...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.SecondStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "The treacherous path which led back to Nogards home, was" +
                      "\nfilled with different kind of dangers lurking around" +
                      "\nevery corner. Amongst these dangers were creapy creatures" +
                      "\nwho waited for any kind of traveler passing through that" +
                      "\nthey could hurt and rob." +
                      "\nNogard had been terrified and the first sight of them, but" +
                      "\nhad managed to get away unhurt thanks to the fiery courage" +
                      "\nthat had previously filled, and given him, the power of" +
                      "\nfirebreathing." +
                      "\nHe knew he had a long way to go before he would reach the top" +
                      "\nof the mountain where his family was waiting for him, and" +
                      "\nthat he had to be careful where he placed every step." +
                      "\n'The slippery, sharp and hard edges of the path are" +
                      "\njust as, if not more dangerous then the creatures lurking" +
                      "\nabout', the brave and wise little dragon thought as he" +
                      "\ncontinued his journey to the top...",
                      new Vector2(50, 60), Color.Black, 0, Vector2.Zero, 0.3f, SpriteEffects.None, 1);
                    break;
                case StoryState.LastStory:
                    NogardGame.SpriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
                    NogardGame.SpriteBatch.DrawString(TextureManager.Font,
                      "When the top of the mountain was so close that Nogard could hear" +
                      "\nhis siblings calling out his name in anxious voices, the little" +
                      "\ndragon faced the most dangerous jump of the entire climb. Nogard" +
                      "\nclosed his eyes and breathed heavely with smoke coming out of his" +
                      "\nnostrils, as his heart began to pound faster." +
                      "\n'I can do this' he told himself. 'I am the bravest dragon of" +
                      "\nthem all and there is nothing I can't do'. " +
                      "\nThen he jumped so high that it almost felt like flying, and" +
                      "\nlanded right ontop of his unwitting siblings, making a big pile" +
                      "\nof mashed dragons at the edge of the moutaintop. His siblings" +
                      "\nthen screamed of joy as they realized it was Nogard who had" +
                      "\ncrashed down on them, and they all wanted to hear his story and" +
                      "\nhow he was able to get back up all on his own." +
                      "\nLater on, when Nogard was being served a homecooked meal by his" +
                      "\nloving mother, he told his family about his journey and all the" +
                      "\ndangers he had to face along the way. His mothers eyes teared up" +
                      "\nbecause of the pride she felt in having raised such a brave child," +
                      "\nand all of his siblings looked at him in awe." +
                      "\nIn that very moment, Nogard truly felt like the bravest" +
                      "\ndragon in the world..." +
                      "\nThe End!",
                      new Vector2(50, 30), Color.Black, 0, Vector2.Zero, 0.26f, SpriteEffects.None, 1);
                    break;
            }
        }
    }
}
