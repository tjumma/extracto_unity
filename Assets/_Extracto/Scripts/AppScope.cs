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
        [SerializeField] private AppStateMachine appStateMachine;
        [SerializeField] private UIConnectWallet uiConnectWallet;
        [SerializeField] private UICreatePlayer uiCreatePlayer;
        [SerializeField] private UIMainMenu uiMainMenu;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(mainCamera);
            builder.RegisterComponent(reactToUnity);
            builder.RegisterComponent(unityToReact);
            
            builder.RegisterComponent(appStateMachine);
            builder.RegisterComponent(uiConnectWallet);
            builder.RegisterComponent(uiCreatePlayer);
            builder.RegisterComponent(uiMainMenu);

            builder.Register<Player>(Lifetime.Singleton);

            builder.RegisterEntryPoint<AppController>();
        }
    }
}