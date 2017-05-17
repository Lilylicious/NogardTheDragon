using Microsoft.Xna.Framework;
using NogardTheDragon.Map;

namespace NogardTheDragon.Managers
{
    public class GamePlayManager : BaseManager
    {
        public Map.Map ActiveMap;

        public override void Update(GameTime gameTime)
        {
            ActiveMap.Update(gameTime);
        }

        public override void Draw()
        {
            ActiveMap.Draw();
        }

        public void StartMap(string mapName)
        {
            ActiveMap = MapReader.CreateMap(mapName);
            NogardGame.TotalScore = 0;
            NogardGame.GameState = NogardGame.GameStateEnum.GameActive;
        }
    }
}