using Newtonsoft.Json;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class ReactToUnity : MonoBehaviour
    {
        private Player _player;
        
        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }
        
        public void OnWalletConnected(string publicKey)
        {
            Debug.Log($"Unity knows that wallet {publicKey} was connected");
        }

        public void OnPlayerDataUpdated(string playerDataJson)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(playerDataJson);
            _player.PlayerDataRP.Value = playerData;
        }
    }
}