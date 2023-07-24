using System.Runtime.InteropServices;
using UnityEngine;

namespace Extracto
{
    public class UnityToReact : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void IncrementCounter (string message);

        public void InvokeIncrementCounter(string message)
        {
            Debug.Log("InvokeIncrementCounter");
            
#if UNITY_WEBGL == true && UNITY_EDITOR == false
            IncrementCounter(message);
#endif
        }
    }
}