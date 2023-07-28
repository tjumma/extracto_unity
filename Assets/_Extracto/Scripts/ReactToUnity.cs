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

        public void OnPlayerUpdated(string playerDataJson)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(playerDataJson);
            _player.PlayerData = playerData;
        }
    }
}