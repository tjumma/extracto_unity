using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Extracto
{
    public class AppScope : LifetimeScope
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private ReactToUnity reactToUnity;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
            builder.RegisterComponent(reactToUnity);
        }

        private void Start()
        {
            WebGLInput.captureAllKeyboardInput = false;
        }
    }
}