using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Extracto
{
    public class UIGame : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        
        private UnityToReact _unityToReact;
        private Player _player;
        private Run _run;

        private VisualElement _root;
        
        private VisualElement _gameScreen;
        private VisualElement _runDataPanel;
        private Label _scoreLabel;
        private Label _experienceLabel;
        
        private VisualElement _gameButtonsPanel;
        private Button _finishRunButton;
        
        [Inject]
        public void Construct(UnityToReact unityToReact, Player player, Run run)
        {
            _unityToReact = unityToReact;
            _player = player;
            _run = run;
        }
        
        public void SetEnabled(bool isEnabled)
        {
            _gameScreen.style.display = isEnabled ? DisplayStyle.Flex : DisplayStyle.None;
        }
        
        void Awake()
        {
            _root = document.rootVisualElement;

            _gameScreen = _root.Q<VisualElement>("game-screen");
            
            _runDataPanel = _gameScreen.Q<VisualElement>("run-data-panel");
            _scoreLabel = _runDataPanel.Q<Label>("score-label");
            _experienceLabel = _runDataPanel.Q<Label>("experience-label");

            _gameButtonsPanel = _gameScreen.Q<VisualElement>("game-buttons-panel");
            _finishRunButton = _gameButtonsPanel.Q<Button>("finish-run-button");
        }

        private void OnEnable()
        {
            _finishRunButton.clicked += OnFinishRunButtonClicked;
            _run.OnRunDataUpdated += OnRunDataUpdated;
        }

        private void OnDisable()
        {
            _finishRunButton.clicked -= OnFinishRunButtonClicked;
            _run.OnRunDataUpdated += OnRunDataUpdated;
        }

        private void OnRunDataUpdated(RunData runData)
        {
            _scoreLabel.text = $"Score: ${runData.score}";
        }

        private void OnFinishRunButtonClicked()
        {
            Debug.Log("FinishRun button clicked");
            _unityToReact.InvokeFinishRun();
        }
    }
}