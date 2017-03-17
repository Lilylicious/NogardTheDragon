using Microsoft.Xna.Framework;
using NogardTheDragon.Map;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GamePlayManager
    {
        public Map.Map ActiveMap;
        public Player Player;

        public void StartGame()
        {
            ActiveMap = MapReader.ReadMap("SavedMap");
            NogardGame.GameOverManager.Init();
            NogardGame.GameState = NogardGame.GameStateEnum.GameActive;
        }

        public void Update(GameTime gameTime)
        {
            ActiveMap.Update(gameTime);
        }

        public void Draw()
        {
            ActiveMap.Draw();
        }
    }
}