using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Extracto
{
    [RequireComponent(typeof(UIDocument))]
    public class UIMainMenu : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private UnityToReact _unityToReact;
        private Player _player;

        private VisualElement _root;

        private VisualElement _mainMenuScreen;
        private VisualElement _playerDataPanel;
        private Label _publicKeyLabel;
        private Label _nameLabel;
        private Label _runsFinishedLabel;
        private Label _bestScoreLabel;
        private VisualElement _gameButtonsPanel;
        private Button _startNewRunButton;

        [Inject]
        public void Construct(UnityToReact unityToReact, Player player)
        {
            _unityToReact = unityToReact;
            _player = player;
        }
        
        public void SetEnabled(bool isEnabled)
        {
            _mainMenuScreen.style.display = isEnabled ? DisplayStyle.Flex : DisplayStyle.None;
        }

        void Awake()
        {
            _root = document.rootVisualElement;

            _mainMenuScreen = _root.Q<VisualElement>("main-menu-screen");
            
            _playerDataPanel = _mainMenuScreen.Q<VisualElement>("player-data-panel");
            _publicKeyLabel = _playerDataPanel.Q<Label>("public-key-label");
            _nameLabel = _playerDataPanel.Q<Label>("name-label");
            _runsFinishedLabel = _playerDataPanel.Q<Label>("runs-finished-label");
            _bestScoreLabel = _playerDataPanel.Q<Label>("best-score-label");
            
            _gameButtonsPanel = _mainMenuScreen.Q<VisualElement>("game-buttons-panel");
            _startNewRunButton = _gameButtonsPanel.Q<Button>("start-new-run-button");
        }

        private void OnEnable()
        {
            _startNewRunButton.clicked += OnStartNewRunButtonClicked;
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }
        
        private void OnDisable()
        {
            _startNewRunButton.clicked -= OnStartNewRunButtonClicked;
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }

        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (playerData == null)
                return;

            _publicKeyLabel.text = $"Public key: {playerData.publicKey}";
            _nameLabel.text = $"Name: {playerData.name}";
            _runsFinishedLabel.text = $"Runs finished: {playerData.runsFinished}";
            _bestScoreLabel.text = $"Best score: {playerData.bestScore}";
        }

        private void OnStartNewRunButtonClicked()
        {
            Debug.Log("StartNewRun button clicked");
            _unityToReact.InvokeStartNewRun();
        }
    }
}