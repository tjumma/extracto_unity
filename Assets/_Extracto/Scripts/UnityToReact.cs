using System.Runtime.InteropServices;
using UnityEngine;

namespace Extracto
{
    public class UnityToReact : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void IncrementCounter(string message);

        [DllImport("__Internal")]
        private static extern void InitPlayer(string playerName);

        public void InvokeIncrementCounter(string message)
        {
            Debug.Log("InvokeIncrementCounter");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            IncrementCounter(message);
#endif
        }
        
        public void InvokeInitPlayer(string playerName)
        {
            Debug.Log("InvokeInitPlayer");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            InitPlayer(playerName);
#endif
        }
    }
}