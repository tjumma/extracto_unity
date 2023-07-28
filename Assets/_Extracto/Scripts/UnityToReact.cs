using System.Runtime.InteropServices;
using UnityEngine;

namespace Extracto
{
    public class UnityToReact : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void GameReady();

        [DllImport("__Internal")]
        private static extern void IncrementRun(string message);

        [DllImport("__Internal")]
        private static extern void InitPlayer(string playerName);

        public void InvokeGameReady()
        {
            Debug.Log("InvokeGameReady");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            WebGLInput.captureAllKeyboardInput = false;
            GameReady();
#endif
        }

        public void InvokeIncrementRun(string message)
        {
            Debug.Log("InvokeIncrementRun");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            IncrementRun(message);
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