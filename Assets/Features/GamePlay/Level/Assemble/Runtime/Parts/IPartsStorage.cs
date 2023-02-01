using System.Collections.Generic;

namespace Features.GamePlay.Level.Assemble.Runtime.Parts
{
    public interface IPartsStorage
    {
        IReadOnlyList<PuzzlePart> Available { get; }

        void Add(PuzzlePart part);
        void OnLocked(PuzzlePart part);

        void OnReset();
    }
}