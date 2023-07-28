using UnityEngine;
using VContainer.Unity;

namespace Extracto
{
    public class AppController : IStartable
    {
        public void Start()
        {
            Debug.Log("AppController Start");
        }
    }
}