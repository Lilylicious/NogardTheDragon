using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class PauseManager : BaseManager
    {
        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.Pause;
        }

        public override void Update(GameTime gameTime)
        {
            if(KeyMouseReader.KeyPressed(Keys.Escape))
                NogardGame.GameState = NogardGame.GameStateEnum.GameActive;

            foreach (var b in NogardGame.ButtonManager.Buttons)
            {
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.ResumeButton))
                    NogardGame.GameState = NogardGame.GameStateEnum.GameActive;
                if (b.ButtonClicked && b.Equals(NogardGame.ButtonManager.PauseMenuButton))
                    NogardGame.MainMenuManager.Init();
            }
        }

        public override void Draw()
        {
            NogardGame.SpriteBatch.Draw(TextureManager.StandardPlatformTex, new Rectangle(0, 0, 900, 700), new Color(0,0,0, 150));
        }
    }
}
