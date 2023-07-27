using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Extracto
{
    public class PlayerSubscriber : IStartable
    {
        private Player _player;
        
        [Inject]
        public void Construct(Player player)
        {
            _player = player;
        }

        public void Start()
        {
            _player.PlayerDataRP.ForEachAsync(newPlayerData =>
            {
                if (newPlayerData != null)
                {
                    Debug.Log(newPlayerData.name);
                    Debug.Log(newPlayerData.authority);
                    Debug.Log(newPlayerData.runsFinished);
                }
                else
                {
                    Debug.Log("PlayerData is null");
                }
            });
        }
    }
}