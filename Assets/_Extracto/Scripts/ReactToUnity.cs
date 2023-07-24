using UnityEngine;

namespace Extracto
{
    public class ReactToUnity : MonoBehaviour
    {
        public void OnWalletConnected(string publicKey)
        {
            Debug.Log($"Unity knows that wallet {publicKey} was connected");
        }
    }
}