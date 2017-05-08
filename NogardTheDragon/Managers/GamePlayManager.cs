using Microsoft.Xna.Framework;
using NogardTheDragon.Map;
using NogardTheDragon.Objects;

namespace NogardTheDragon.Managers
{
    public class GamePlayManager : BaseManager
    {
        public Map.Map ActiveMap;
        public Player Player;

        public override void Init()
        {
            ActiveMap = MapReader.CreateMap("SavedMap");
            NogardGame.KillBonus = 0;
            NogardGame.TotalScore = 0;
            NogardGame.GameState = NogardGame.GameStateEnum.GameActive;
        }

        public override void Update(GameTime gameTime)
        {
            ActiveMap.Update(gameTime);
        }

        public override void Draw()
        {
            ActiveMap.Draw();
        }
    }
}