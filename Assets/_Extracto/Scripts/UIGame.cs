using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Extracto
{
    [RequireComponent(typeof(UIDocument))]
    public class UIGame : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private UnityToReact _unityToReact;
        private Player _player;

        private VisualElement _root;
        
        private VisualElement _welcomeScreen;
        private VisualElement _initPlayerPanel;
        private TextField _playerNameField;
        private Button _initPlayerButton;

        private VisualElement _gameScreen;
        private VisualElement _playerDataPanel;
        private Label _authorityLabel;
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

        void Awake()
        {
            _root = document.rootVisualElement;
            
            _welcomeScreen = _root.Q<VisualElement>("welcome-screen");
            
            _initPlayerPanel = _welcomeScreen.Q<VisualElement>("init-player-panel");
            _playerNameField = _initPlayerPanel.Q<TextField>("player-name-field");
            _initPlayerButton = _initPlayerPanel.Q<Button>("init-player-button");
            
            _gameScreen = _root.Q<VisualElement>("game-screen");
            
            _playerDataPanel = _gameScreen.Q<VisualElement>("player-data-panel");
            _authorityLabel = _playerDataPanel.Q<Label>("authority-label");
            _nameLabel = _playerDataPanel.Q<Label>("name-label");
            _runsFinishedLabel = _playerDataPanel.Q<Label>("runs-finished-label");
            
            _gameButtonsPanel = _gameScreen.Q<VisualElement>("game-buttons-panel");
            _incrementCounterButton = _gameButtonsPanel.Q<Button>("increment-counter-button");
        }

        private void OnEnable()
        {
            _initPlayerButton.clicked += OnInitPlayerButtonClicked;
            _incrementCounterButton.clicked += OnIncrementCounterButtonClicked;
            
            _player.PlayerDataRP.ForEachAsync(OnPlayerDataUpdated, this.GetCancellationTokenOnDestroy()).Forget();
        }
        
        private void OnDisable()
        {
            _initPlayerButton.clicked -= OnInitPlayerButtonClicked;
            _incrementCounterButton.clicked -= OnIncrementCounterButtonClicked;
        }

        private void OnPlayerDataUpdated(PlayerData playerData)
        {
            _welcomeScreen.style.display = (playerData == null) ? DisplayStyle.Flex : DisplayStyle.None;
            _gameScreen.style.display = (playerData == null) ? DisplayStyle.None : DisplayStyle.Flex;

            if (playerData == null)
                return;

            _authorityLabel.text = $"Authority: {playerData.authority}";
            _nameLabel.text = $"Name: {playerData.name}";
            _runsFinishedLabel.text = $"Runs finished: {playerData.runsFinished}";
        }

        private void OnInitPlayerButtonClicked()
        {
            Debug.Log("InitPlayerButton clicked");
            _unityToReact.InvokeInitPlayer(_playerNameField.value);
        }

        private void OnIncrementCounterButtonClicked()
        {
            Debug.Log("IncrementCounterButton clicked");
            _unityToReact.InvokeIncrementCounter("testerino");
        }
    }
}