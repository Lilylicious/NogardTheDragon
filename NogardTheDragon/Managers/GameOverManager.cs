using Microsoft.Xna.Framework;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GameOverManager : BaseManager
    {
        private readonly NogardGame Instance;
        private Player Player;
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
            foreach (var gameObject in NogardGame.GamePlayManager.ActiveMap.Objects)
            {
                /*The keyword "as" tries to assign the variable o as a Player object. If it can't, o becomes null.
                 * This is equivalent to doing the following
                 * 
                 * if(gameObject is Player){
                 * Player = gameObject;
                 * }
                 */

                var o = gameObject as Player;
                if (o != null)
                    Player = o;
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw()
        {
            Instance.GraphicsDevice.Clear(Color.Black);

            //if won then Victory! If not won then Losing screen
        }
    }
}