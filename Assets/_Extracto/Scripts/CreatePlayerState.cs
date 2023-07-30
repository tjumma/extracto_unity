using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class CreatePlayerState : StateBehaviour
    {
        public override string StateID => "CreatePlayer";

        private UICreatePlayer _uiCreatePlayer;
        private Player _player;

        [Inject]
        public void Construct(UICreatePlayer uiCreatePlayer, Player player)
        {
            _uiCreatePlayer = uiCreatePlayer;
            _player = player;
        }

        protected override void OnEnterState()
        {
            _uiCreatePlayer.SetEnabled(true);

            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }

        protected override void OnExitState()
        {
            _uiCreatePlayer.SetEnabled(false);

            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }

        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (string.IsNullOrEmpty(playerData.publicKey))
            {
                StateMachine.TriggerByLabel("connectWallet");
            }
            else if (!string.IsNullOrEmpty(playerData.name))
            {
                if (!playerData.isInRun)
                    StateMachine.TriggerByLabel("mainMenu");
                else
                    StateMachine.TriggerByLabel("game");
            }
        }
    }
}