using Common.DiContainer.Abstract;
using Global.MessageBrokers.Common;
using Global.MessageBrokers.Logs;
using Global.Setup.Service;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Global.MessageBrokers.Runtime
{
    [InlineEditor]
    [CreateAssetMenu(fileName = MessageBrokerRouter.ServiceName,
        menuName = MessageBrokerRouter.ServicePath)]
    public class MessageBrokerAsset : ScriptableObject, IGlobalServiceFactory
    {
        [SerializeField] [Indent] private MessageBrokerLogSettings _logSettings;

        public void Create(
            IDependencyRegister builder,
            IGlobalServiceBinder serviceBinder,
            IGlobalCallbacks callbacks)
        {
            builder.Register<MessageBrokerLogger>()
                .WithParameter(_logSettings);

            var messageBroker = new MessageBroker();

            builder.Register<MessageBrokerProxy>()
                .WithParameter(messageBroker)
                .AsSelfResolvable();
        }
    }
}