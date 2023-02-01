using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Services.Setup.Abstract;
using Global.Services.Setup.Abstract.Scenes;
using Global.Services.System.MessageBrokers.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.Services.System.MessageBrokers.Runtime
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