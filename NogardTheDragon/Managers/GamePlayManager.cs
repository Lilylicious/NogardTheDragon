using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using NogardTheDragon.Map;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    public class GamePlayManager : BaseManager
    {
        public Map.Map ActiveMap;

        public override void Update(GameTime gameTime)
        {
            if (KeyMouseReader.KeyPressed(Keys.Escape))
                NogardGame.PauseManager.Init();

            ActiveMap.Update(gameTime);
        }

        public override void Draw()
        {
            ActiveMap.Draw();
        }

        public void StartMap(string mapName)
        {
            ActiveMap = MapReader.CreateMap(mapName);
            NogardGame.GameState = NogardGame.GameStateEnum.GameActive;
        }
    }
}