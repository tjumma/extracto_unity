using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Extracto
{
    public class AppScope : LifetimeScope
    {
        [SerializeField] private Camera mainCamera;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
        }

        private void Start()
        {
            WebGLInput.captureAllKeyboardInput = false;
        }
    }
}