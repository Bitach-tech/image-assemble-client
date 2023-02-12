using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Common;

namespace Global.Publisher.Yandex.Reviews
{
    public class Reviews : IReviews
    {
        public Reviews(YandexCallbacks callbacks)
        {
            _callbacks = callbacks;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly ReviewsInternal _internal = new();
        
        public async UniTask Review()
        {
            var completion = new UniTaskCompletionSource();
            
            void OnReviewed()
            {
                completion.TrySetResult();
            }
            
            _callbacks.Reviwed += OnReviewed;
            
            _internal.ShowReview();

            await completion.Task;
            
            _callbacks.Reviwed -= OnReviewed;
        }
    }
}