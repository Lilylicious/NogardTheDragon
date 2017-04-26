using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GameOverManager : BaseManager
    {
        private readonly NogardGame Instance;
        private bool Won;

        public GameOverManager(NogardGame game)
        {
            Instance = game;
        }

        public void Win()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.GameOver;
            Won = true;
        }

        public void Lose()
        {
            NogardGame.GameState = NogardGame.GameStateEnum.GameOver;
            Won = false;
        }

        public override void Init()
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw()
        {
            Instance.GraphicsDevice.Clear(Color.Black);

            if(Won)
                NogardGame.SpriteBatch.Draw(TextureManager.PlayerTex, Vector2.One, Color.White);
            else
                NogardGame.SpriteBatch.Draw(TextureManager.StandardEnemyTex, Vector2.One, Color.White);
        }
    }
}