using System;

namespace Global.Publisher.Yandex.DataStorages
{
    public interface IStorageEntry
    {
        string Key { get; }
        event Action Changed;
        string Serialize();
        void Deserialize(string raw);
    }
}