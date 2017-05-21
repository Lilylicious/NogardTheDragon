using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NogardTheDragon.Managers
{
    public class LevelSelectorManager : BaseManager
    {
        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.LevelSelector;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.LevelOneButton))
                {
                    NogardGame.GamePlayManager.StartMap("LevelOne");
                    NogardGame.MapsComplete = 0;
                }
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.LevelTwoButton))
                {
                    NogardGame.GamePlayManager.StartMap("LevelTwo");
                    NogardGame.MapsComplete = 1;
                }
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.LevelThreeButton))
                {
                    NogardGame.GamePlayManager.StartMap("LevelThree");
                    NogardGame.MapsComplete = 2;
                }
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.BackButton))
                    NogardGame.MainMenuManager.Init();
            }
        }
    }
}
