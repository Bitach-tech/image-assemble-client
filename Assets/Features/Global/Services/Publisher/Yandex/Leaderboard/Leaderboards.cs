using Global.Publisher.Abstract.Leaderboards;

namespace Global.Publisher.Yandex.Leaderboard
{
    public class Leaderboards : ILeaderboards
    {
        private readonly LeaderboardsInternal _internal = new();
        
        public void SetScore(ILeaderboardEntry entry, int score)
        {
            var target = entry.GetLeaderboardName();
            
            _internal.SetLeaderBoard_Internal(target, score);
        }
    }
}