using UnityEngine;

namespace Features.GamePlay.Level.Assemble.Runtime.StartPositions
{
    public interface IRandomStartPositions
    {
        Vector2 GetRandom();
    }
}