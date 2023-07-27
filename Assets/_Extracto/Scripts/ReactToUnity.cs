using Newtonsoft.Json;
using UnityEngine;

namespace Extracto
{
    public class ReactToUnity : MonoBehaviour
    {
        public void OnWalletConnected(string publicKey)
        {
            Debug.Log($"Unity knows that wallet {publicKey} was connected");
        }

        public void OnPlayerDataUpdated(string playerDataJson)
        {
            PlayerData playerData = JsonConvert.DeserializeObject<PlayerData>(playerDataJson);
            Debug.Log(playerData.name);
            Debug.Log(playerData.authority);
            Debug.Log(playerData.runsFinished);
        }
    }
}