using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class GameReadyState : StateBehaviour
    {
        public override string StateID => "GameReady";

        private UnityToReact _unityToReact;
        private Player _player;

        [Inject]
        public void Construct(UnityToReact unityToReact, Player player)
        {
            _unityToReact = unityToReact;
            _player = player;
        }

        protected override void OnEnterState()
        {
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
            _unityToReact.InvokeGameReady();
        }

        protected override void OnExitState()
        {
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }

        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (string.IsNullOrEmpty(playerData.publicKey))
                StateMachine.TriggerByLabel("connectWallet");
            else if (string.IsNullOrEmpty(playerData.name))
                StateMachine.TriggerByLabel("createPlayer");
            else
                StateMachine.TriggerByLabel("mainMenu");
        }
    }
}