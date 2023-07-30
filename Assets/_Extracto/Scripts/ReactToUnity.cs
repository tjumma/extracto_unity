using Newtonsoft.Json;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class ReactToUnity : MonoBehaviour
    {
        private Player _player;
        private Run _run;

        [SerializeField] private string testJson;
        
        [Inject]
        public void Construct(Player player, Run run)
        {
            _player = player;
            _run = run;
        }

        public void OnPlayerUpdated(string playerDataJson)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(playerDataJson);
            _player.PlayerData = playerData;
        }
        
        public void OnRunUpdated(string runDataJson)
        {
            RunData runData = JsonConvert.DeserializeObject<RunData>(runDataJson);
            _run.RunData = runData;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RunData runData = JsonConvert.DeserializeObject<RunData>(testJson);
                _run.RunData = runData;
            }
        }
    }
}