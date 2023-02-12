using System.Runtime.InteropServices;

namespace Global.Publisher.Yandex.Purchases
{
    public class PurchasesInternal
    {
        [DllImport("__Internal")]
        private static extern void Purchase(string id);

        public void Purchase_Internal(string id)
        {
            Purchase(id);
        }
    }
}