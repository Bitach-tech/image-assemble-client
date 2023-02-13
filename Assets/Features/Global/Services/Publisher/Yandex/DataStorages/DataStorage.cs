using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Global.Publisher.Abstract.DataStorages;
using Global.Publisher.Yandex.Common;
using Global.Setup.Service.Callbacks;
using UnityEngine;

namespace Global.Publisher.Yandex.DataStorages
{
    public class DataStorage : IDataStorage, IGlobalAsyncAwakeListener
    {
        public DataStorage(YandexCallbacks callbacks, IStorageAPI api)
        {
            _callbacks = callbacks;
            _api = api;
        }
        
        private readonly YandexCallbacks _callbacks;
        private readonly IStorageAPI _api;
        
        private Dictionary<string, object> _data = new();
        
        public async UniTask OnAwakeAsync()
        {
            var completion = new UniTaskCompletionSource<Dictionary<string, object>>();

            void OnReceived(string raw)
            {
                Debug.Log($"Raw: {raw}");
                var data = JsonUtility.FromJson<Dictionary<string, object>>(raw);
                completion.TrySetResult(data);
            }

            _callbacks.UserDataReceived += OnReceived;
            
            _api.Get_Internal();

            _data = await completion.Task;
            
            _callbacks.UserDataReceived -= OnReceived;
        }
        
        public bool HasKey(string key)
        {
            return _data.ContainsKey(key);
        }

        public T GetValue<T>(string key) where T : class
        {
            return _data[key] as T;
        }

        public void SetValue<T>(string key, T data)
        {
            _data[key] = data;

            var json = JsonUtility.ToJson(_data);

            _api.Set_Internal(json);
        }
    }
}