using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}