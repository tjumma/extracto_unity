using Ilumisoft.VisualStateMachine;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class GameState : StateBehaviour
    {
        public override string StateID => "Game";

        [SerializeField] private RunDataProcessor runDataProcessor;
        
        private Player _player;
        private Run _run;
        private UIGame _uiGame;
        
        [Inject]
        public void Construct(Player player, Run run, UIGame uiGame)
        {
            _player = player;
            _run = run;
            _uiGame = uiGame;
        }
        
        protected override void OnEnterState()
        {
            Debug.Log("Enter Game state");
            _uiGame.SetEnabled(true);
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
            _run.OnRunDataUpdated += OnRunDataUpdated;
        }

        protected override void OnExitState()
        {
            Debug.Log("Exit Game state");
            _uiGame.SetEnabled(false);
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
            _run.OnRunDataUpdated -= OnRunDataUpdated;

            runDataProcessor.OnGameExit();
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
        
        private void OnRunDataUpdated(RunData runData)
        {
            Debug.Log("GameState OnRunDataUpdated");
            runDataProcessor.Process(runData);
        }
    }
}