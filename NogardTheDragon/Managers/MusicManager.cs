using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using NogardTheDragon.Utilities;

namespace NogardTheDragon.Managers
{
    class MusicManager : BaseManager
    {
        bool songStart = false;

        public override void Init()
        {

        }
        public override void Update(GameTime gameTime)
        {
            switch (NogardGame.GameState)
            {
                case NogardGame.GameStateEnum.MainMenu:
                    if (NogardGame.GameState == NogardGame.GameStateEnum.MainMenu && !songStart)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(WinmmMp3MediaType.Song1);
                        songStart = true;
                    }
                    else if (NogardGame.GameState != NogardGame.GameStateEnum.MainMenu && songStart == true)
                    {
                        MediaPlayer.Stop();
                        songStart = false;
                    }
                    break;
                case NogardGame.GameStateEnum.GameActive:
                    if (NogardGame.GameState == NogardGame.GameStateEnum.GameActive && !songStart)
                    {
                        MediaPlayer.Stop();
                        MediaPlayer.Play(WinmmMp3MediaType.Song2);
                        songStart = true;
                    }
                    else if (NogardGame.GameState != NogardGame.GameStateEnum.GameActive && songStart == true)
                    {
                        MediaPlayer.Stop();
                        songStart = false;
                    }
                    break;
                case NogardGame.GameStateEnum.Pause:
                    if (NogardGame.GameState == NogardGame.GameStateEnum.Pause && !songStart)
                    {
                        MediaPlayer.Stop();
                        songStart = false;
                    }
                    else if (NogardGame.GameState != NogardGame.GameStateEnum.Pause && songStart == true)
                    {
                        MediaPlayer.Play(WinmmMp3MediaType.Song2);
                        songStart = true;
                    }
                    break;
            }
        }
    }
}
