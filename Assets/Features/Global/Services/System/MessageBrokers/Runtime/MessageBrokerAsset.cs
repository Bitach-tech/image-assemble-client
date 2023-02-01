using Common.DiContainer.Abstract;
using Cysharp.Threading.Tasks;
using Global.Common;
using Global.Setup.Service;
using Global.Setup.Service.Scenes;
using Global.System.MessageBrokers.Common;
using Global.System.MessageBrokers.Logs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Global.System.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
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