using Features.Global.Common;
using NaughtyAttributes;
using UnityEngine;

namespace Features.Common.Local.ComposedSceneConfig
{
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ConfigPrefix + "ComposedScene",
        menuName = GlobalAssetsPaths.Config + "ComposedScene")]
    public class ComposedScenesConfig : ScriptableObject
    {
        [SerializeField] [Scene] private string _servicesScene;

        public string ServicesScene => _servicesScene;
    }
}