using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Common.Paths;
using GamePlay.Level.Assemble.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AssembleRoutes.ServiceName,
        menuName = AssembleRoutes.ServicePath)]
    public class PuzzleAssemblerAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] [Indent] [Scene] private string _scene;
        [SerializeField] [Indent] private PuzzleAssembler _prefab;

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<PuzzleAssembler>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);

            var assembler = loadResult.Searched;
        }
    }
}