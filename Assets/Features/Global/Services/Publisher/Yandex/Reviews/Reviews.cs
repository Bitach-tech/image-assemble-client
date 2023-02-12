using Cysharp.Threading.Tasks;
using Global.Pauses.Runtime;
using Global.Publisher.Abstract.Reviews;
using Global.Publisher.Yandex.Common;

namespace Global.Publisher.Yandex.Reviews
{
    public class Reviews : IReviews
    {
        public Reviews(YandexCallbacks callbacks, IPause pause)
        {
            _callbacks = callbacks;
            _pause = pause;
        }

        private readonly YandexCallbacks _callbacks;
        private readonly IPause _pause;
        private readonly ReviewsInternal _internal = new();

        private bool _isReviewed;
        
        public async UniTask Review()
        {
            if (_isReviewed == true)
                return;
            
            _pause.Pause();
            
            var completion = new UniTaskCompletionSource();
            
            void OnReviewed()
            {
                completion.TrySetResult();
            }
            
            _callbacks.Reviewed += OnReviewed;
            
            _internal.ShowReview();

            _isReviewed = true;

            await completion.Task;
            
            _callbacks.Reviewed -= OnReviewed;
            
            _pause.Continue();
        }
    }
}