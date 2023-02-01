using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Common.Local.Services.Abstract;
using Features.Common.NestedScriptableObjects.Attributes;
using Features.GamePlay.Common.Paths;
using Features.Global.Services.ScenesFlow.Runtime.Abstract;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.GamePlay.Level.ImageStorage.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GamePlayAssetsPaths.ServicePrefix + "ImageStorage",
        menuName = GamePlayAssetsPaths.ImageStorage + "Service")]
    public class ImageStorageAsset : LocalServiceAsset
    {
        [SerializeField] [NestedScriptableObjectList]
        private List<LevelImage> _images;

        [SerializeField] private ImageStorage _prefab;

        public override async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var storage = Instantiate(_prefab);
            storage.name = "ImageStorage";

            var array = _images.ToArray();

            builder.RegisterComponent(storage)
                .As<IImageStorage>()
                .WithParameter(array);

            serviceBinder.AddToModules(storage);
        }
    }
}