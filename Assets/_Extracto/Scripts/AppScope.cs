using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Extracto
{
    public class AppScope : LifetimeScope
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private ReactToUnity reactToUnity;
        [SerializeField] private UnityToReact unityToReact;
        [SerializeField] private UIGame ui;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
            builder.RegisterComponent(reactToUnity);
            builder.RegisterComponent(unityToReact);
            builder.RegisterComponent(ui);
            
            builder.Register<Player>(Lifetime.Singleton);

            builder.RegisterEntryPoint<AppController>();
        }

        private void Start()
        {
            unityToReact.InvokeGameReady();
        }
    }
}