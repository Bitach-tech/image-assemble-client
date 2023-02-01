﻿using Common.ReadOnlyDictionaries.Editor;
using Global.Services.Updaters.Logs;
using UnityEditor;

namespace Global.Services.Loggers.Editor.Services
{
    [ReadOnlyDictionaryPriority]
    [CustomPropertyDrawer(typeof(UpdaterLogs))]
    public class UpdaterLogsDrawer : ReadOnlyDictionaryPropertyDrawer
    {
        protected override bool IsCollapsed => false;
    }
}