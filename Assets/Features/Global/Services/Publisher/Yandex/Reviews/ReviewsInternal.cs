using System.Runtime.InteropServices;

namespace Global.Publisher.Yandex.Reviews
{
    public class ReviewsInternal
    {
        [DllImport("__Internal")]
        private static extern void Review();

        public void ShowReview()
        {
            Review();
        }
    }
}