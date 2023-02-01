using System;
using Features.Common.ReadOnlyDictionaries.Runtime;

namespace Features.Global.Services.Updaters.Logs
{
    [Serializable]
    public class UpdaterLogs : ReadOnlyDictionary<UpdaterLogType, bool>
    {
    }
}