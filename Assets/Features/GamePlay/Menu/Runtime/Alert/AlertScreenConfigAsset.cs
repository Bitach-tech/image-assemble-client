using Features.GamePlay.Common.Paths;
using UnityEngine;

namespace Features.GamePlay.Menu.Runtime.Alert
{
    [CreateAssetMenu(fileName = "Config_AlertScreen", menuName = MenuAssetsPaths.Root + "AlertConfig")]
    public class AlertScreenConfigAsset : ScriptableObject
    {
        [SerializeField] private string _ownerName;

        public string OwnerName => _ownerName;
    }
}