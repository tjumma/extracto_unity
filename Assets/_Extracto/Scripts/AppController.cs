using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

namespace Extracto
{
    public class AppController : IStartable, IAsyncStartable
    {
        public void Start()
        {
            Debug.Log("AppController Start");
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            Debug.Log("AppController StartAsync");
        }
    }
}