using GamePlay.Loop.Difficulties;

namespace GamePlay.Menu.Runtime
{
    public readonly struct PlayClickEvent
    {
        public PlayClickEvent(LevelDifficulty difficulty)
        {
            Difficulty = difficulty;
        }

        public readonly LevelDifficulty Difficulty;
    }
}