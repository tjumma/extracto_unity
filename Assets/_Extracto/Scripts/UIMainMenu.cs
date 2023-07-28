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
        private VisualElement _gameButtonsPanel;
        private Button _incrementCounterButton;

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
            
            _gameButtonsPanel = _mainMenuScreen.Q<VisualElement>("game-buttons-panel");
            _incrementCounterButton = _gameButtonsPanel.Q<Button>("increment-counter-button");
        }

        private void OnEnable()
        {
            _incrementCounterButton.clicked += OnIncrementCounterButtonClicked;
            _player.OnPlayerDataUpdated += OnPlayerDataUpdated;
        }
        
        private void OnDisable()
        {
            _incrementCounterButton.clicked -= OnIncrementCounterButtonClicked;
            _player.OnPlayerDataUpdated -= OnPlayerDataUpdated;
        }

        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            if (playerData == null)
                return;

            _publicKeyLabel.text = $"Public key: {playerData.publicKey}";
            _nameLabel.text = $"Name: {playerData.name}";
            _runsFinishedLabel.text = $"Runs finished: {playerData.runsFinished}";
        }

        private void OnIncrementCounterButtonClicked()
        {
            Debug.Log("IncrementCounterButton clicked");
            _unityToReact.InvokeIncrementCounter("testerino");
        }
    }
}