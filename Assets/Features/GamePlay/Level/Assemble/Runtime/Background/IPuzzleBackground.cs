using UnityEngine;

namespace Features.GamePlay.Level.Assemble.Runtime.Background
{
    public interface IPuzzleBackground
    {
        void Enable(Sprite sprite);
        void Disable();
    }
}