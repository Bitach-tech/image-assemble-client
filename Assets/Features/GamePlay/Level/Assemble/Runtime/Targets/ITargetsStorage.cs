using System.Collections.Generic;

namespace Features.GamePlay.Level.Assemble.Runtime.Targets
{
    public interface ITargetsStorage
    {
        IReadOnlyList<PuzzleTarget> Available { get; }

        void OnTaken(PuzzleTarget target);
        void OnTaken(int id);
        void OnReset();
    }
}