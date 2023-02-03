using Common.DiContainer.Abstract;
using Common.Local.Services.Abstract;
using Cysharp.Threading.Tasks;
using GamePlay.Level.Assemble.Common;
using Global.Scenes.ScenesFlow.Handling.Data;
using Global.Scenes.ScenesFlow.Runtime.Abstract;
using Global.UI.UiStateMachines.Runtime;
using NaughtyAttributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Level.Assemble.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = AssembleRoutes.ServiceName,
        menuName = AssembleRoutes.ServicePath)]
    public class AssemblerAsset : ScriptableObject, ILocalServiceAsyncFactory
    {
        [SerializeField] private UiConstraints _constraints;
        [SerializeField] [Indent] [Scene] private string _scene;

        public async UniTask Create(
            IDependencyRegister builder,
            ILocalServiceBinder serviceBinder,
            ISceneLoader sceneLoader,
            ILocalCallbacks callbacks)
        {
            var sceneData = new TypedSceneLoadData<Assembler>(_scene);
            var loadResult = await sceneLoader.Load(sceneData);

            var assembler = loadResult.Searched;

            builder.RegisterComponent(assembler)
                .WithParameter(_constraints)
                .As<IAssembler>()
                .AsCallbackListener();
        }
    }
}