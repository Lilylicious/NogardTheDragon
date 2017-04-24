using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class MainMenuManager : BaseManager
    {
        private NogardGame game;
        
        public MainMenuManager(NogardGame game)
        {
            this.game = game;
        }

        public override void Init()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.MainMenu;
        }

        public override void Update(GameTime gameTime)
        {
            NogardGame.ButtonManager.Update(gameTime);

            foreach (StandardButton b in NogardGame.ButtonManager.Buttons)
            {
                if (b.buttonClicked && b.Equals(NogardGame.ButtonManager.PlayButton))
                {
                    NogardGame.GamePlayManager.Init();
                }
                if (b.buttonClicked && b.Equals(NogardGame.ButtonManager.ScoreButton))
                {

                }
                if (b.buttonClicked && b.Equals(NogardGame.ButtonManager.ExitButton))
                {
                    game.Exit();
                }
                if (b.buttonClicked && b.Equals(NogardGame.ButtonManager.MapButton))
                {
                    NogardGame.MapMakerManager.Init();
                }
            }
        }

        public override void Draw()
        {
            NogardGame.SpriteBatch.Draw(TextureManager.MainMenuBackTex, new Vector2(-100, 0), Color.White);
            NogardGame.ButtonManager.Draw();
        }
    }
}
