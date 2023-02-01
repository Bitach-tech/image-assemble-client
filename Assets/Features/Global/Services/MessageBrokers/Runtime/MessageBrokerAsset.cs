using Cysharp.Threading.Tasks;
using Features.Common.DiContainer.Abstract;
using Features.Global.Common;
using Features.Global.Services.Common.Abstract;
using Features.Global.Services.Common.Abstract.Scenes;
using Features.Global.Services.MessageBrokers.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Features.Global.Services.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = GlobalAssetsPaths.ServicePrefix + "MessageBroker",
        menuName = GlobalAssetsPaths.MessageBroker + "Service")]
    public class MessageBrokerAsset : GlobalServiceAsset
    {
        [SerializeField] [Indent] private MessageBrokerLogSettings _logSettings;

        public override async UniTask Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalSceneLoader sceneLoader,
            IGlobalCallbacks callbacks)
        {
            builder.Register<MessageBrokerLogger>()
                .WithParameter(_logSettings);

            builder.Register<MessageBrokerProxy>()
                .AsSelfResolvable();
        }
    }
}