using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace NogardTheDragon.Managers
{
    public class MusicManager : BaseManager
    {
        private NogardGame.GameStateEnum LastGameState = NogardGame.GameStateEnum.MainMenu;

        public override void Init()
        {
            MediaPlayer.Volume = 0.5f;
        }

        public override void Update(GameTime gameTime)
        {
            if (PauseCheck() && NogardGame.GameState != LastGameState)
                MediaPlayer.Stop();

            if (MediaPlayer.State == MediaState.Stopped)
                switch (NogardGame.GameState)
                {
                    case NogardGame.GameStateEnum.MainMenu:
                        MediaPlayer.Play(TextureManager.Song1);
                        break;
                    case NogardGame.GameStateEnum.GameActive:
                        MediaPlayer.Play(TextureManager.Song2);
                        break;
                    case NogardGame.GameStateEnum.HighScoreView:
                        break;
                    case NogardGame.GameStateEnum.Story:
                        break;
                    case NogardGame.GameStateEnum.GameOver:
                        break;
                    case NogardGame.GameStateEnum.Pause:
                        break;
                    case NogardGame.GameStateEnum.MapMaker:
                        break;
                    case NogardGame.GameStateEnum.LevelSelector:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            LastGameState = NogardGame.GameState;
        }

        private bool PauseCheck()
        {
            return !(LastGameState == NogardGame.GameStateEnum.GameActive &&
                     NogardGame.GameState == NogardGame.GameStateEnum.Pause ||
                     LastGameState == NogardGame.GameStateEnum.Pause &&
                     NogardGame.GameState == NogardGame.GameStateEnum.GameActive);
        }
    }
}