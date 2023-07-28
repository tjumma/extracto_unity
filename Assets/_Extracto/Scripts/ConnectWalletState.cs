using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class ConnectWalletState : StateBehaviour
    {
        public override string StateID => "ConnectWallet";

        private UIConnectWallet _uiConnectWallet;
        private Player _player;
        
        [Inject]
        public void Construct(UIConnectWallet uiConnectWallet, Player player)
        {
            _uiConnectWallet = uiConnectWallet;
            _player = player;
        }
        
        protected override void OnEnterState()
        {
            Debug.Log("Enter ConnectWallet state");
            _uiConnectWallet.SetEnabled(true);

            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }

        protected override void OnExitState()
        {
            Debug.Log("Exit ConnectWallet state");
            _uiConnectWallet.SetEnabled(false);
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }
        
        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (string.IsNullOrEmpty(playerData.publicKey))
                return;
            
            if (string.IsNullOrEmpty(playerData.name))
                StateMachine.TriggerByLabel("createPlayer");
            else if (!playerData.isInRun)
                StateMachine.TriggerByLabel("mainMenu");
            else
                StateMachine.TriggerByLabel("game");
        }
    }
}