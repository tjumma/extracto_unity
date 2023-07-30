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
        
        [DllImport("__Internal")]
        private static extern void Upgrade(int cardId, int slotId);

        public void InvokeGameReady()
        {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            WebGLInput.captureAllKeyboardInput = false;
            GameReady();
#endif
        }
        
        public void InvokeInitPlayer(string playerName)
        {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            InitPlayer(playerName);
#endif
        }

        public void InvokeStartNewRun()
        {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            StartNewRun();
#endif
        }
        
        public void InvokeFinishRun()
        {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            FinishRun();
#endif
        }
        
        public void InvokeUpgrade(int cardId, int slotId)
        {

#if UNITY_WEBGL == true && UNITY_EDITOR == false
            Upgrade(cardId, slotId);
#endif
        }
    }
}