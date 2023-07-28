using System.Runtime.InteropServices;
using UnityEngine;

namespace Extracto
{
    public class UnityToReact : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void GameReady();
        
        [DllImport("__Internal")]
        private static extern void InitPlayer(string playerName);

        [DllImport("__Internal")]
        private static extern void StartNewRun();
        
        [DllImport("__Internal")]
        private static extern void FinishRun();

        public void InvokeGameReady()
        {
            Debug.Log("InvokeGameReady");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            WebGLInput.captureAllKeyboardInput = false;
            GameReady();
#endif
        }
        
        public void InvokeInitPlayer(string playerName)
        {
            Debug.Log("InvokeInitPlayer");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            InitPlayer(playerName);
#endif
        }

        public void InvokeStartNewRun()
        {
            Debug.Log("InvokeStartNewRun");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            StartNewRun();
#endif
        }
        
        public void InvokeFinishRun()
        {
            Debug.Log("InvokeFinishRun");

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            FinishRun();
#endif
        }
    }
}