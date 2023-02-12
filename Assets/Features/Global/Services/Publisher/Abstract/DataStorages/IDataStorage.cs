using Cysharp.Threading.Tasks;

namespace Global.Publisher.Abstract.DataStorages
{
    public interface IDataStorage
    {
        bool HasKey(string key);
        T GetValue<T>(string key) where T : class;
        void SetValue<T>(T data, string key);
    }
}