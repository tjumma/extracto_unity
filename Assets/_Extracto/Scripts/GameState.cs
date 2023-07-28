using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class GameState : StateBehaviour
    {
        public override string StateID => "Game";
        
        private Player _player;
        private UIGame _uiGame;
        
        [Inject]
        public void Construct(Player player, UIGame uiGame)
        {
            _player = player;
            _uiGame = uiGame;
        }
        
        protected override void OnEnterState()
        {
            Debug.Log("Enter Game state");
            _uiGame.SetEnabled(true);
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }

        protected override void OnExitState()
        {
            Debug.Log("Exit Game state");
            _uiGame.SetEnabled(false);
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }
        
        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (string.IsNullOrEmpty(playerData.publicKey))
                StateMachine.TriggerByLabel("connectWallet");
            else if (string.IsNullOrEmpty(playerData.name))
                StateMachine.TriggerByLabel("createPlayer");
            else if (!playerData.isInRun)
                StateMachine.TriggerByLabel("mainMenu");
        }
    }
}