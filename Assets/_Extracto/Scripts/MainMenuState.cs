using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class MainMenuState : StateBehaviour
    {
        public override string StateID => "MainMenu";
        
        private UIMainMenu _uiMainMenu;
        private Player _player;
        
        [Inject]
        public void Construct(UIMainMenu uiMainMenu, Player player)
        {
            _uiMainMenu = uiMainMenu;
            _player = player;
        }
        
        protected override void OnEnterState()
        {
            Debug.Log("Enter MainMenu state");
            _uiMainMenu.SetEnabled(true);
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }

        protected override void OnExitState()
        {
            Debug.Log("Exit MainMenu state");
            _uiMainMenu.SetEnabled(false);
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }
        
        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (string.IsNullOrEmpty(playerData.publicKey))
                StateMachine.TriggerByLabel("connectWallet");
            else if (string.IsNullOrEmpty(playerData.name))
                StateMachine.TriggerByLabel("createPlayer");
        }
    }
}