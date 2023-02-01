using System;
using Common.ReadOnlyDictionaries.Runtime;

namespace Global.Services.System.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}