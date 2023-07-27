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

        private VisualElement _root;
        private VisualElement _initPlayerPanel;
        private TextField _playerNameField;
        private Button _initPlayerButton;

        private Button _incrementCounterButton;

        [Inject]
        public void Construct(UnityToReact unityToReact)
        {
            _unityToReact = unityToReact;
        }

        void Awake()
        {
            _root = document.rootVisualElement;
            _initPlayerPanel = _root.Q<VisualElement>("init-player-panel");
            _playerNameField = _initPlayerPanel.Q<TextField>("player-name-field");
            _initPlayerButton = _initPlayerPanel.Q<Button>("init-player-button");
            
            _incrementCounterButton = _root.Q<Button>("increment-counter-button");
        }

        private void OnEnable()
        {
            _initPlayerButton.clicked += OnInitPlayerButtonClicked;
            
            _incrementCounterButton.clicked += OnIncrementCounterButtonClicked;
        }
        
        private void OnDisable()
        {
            _initPlayerButton.clicked -= OnInitPlayerButtonClicked;
            
            _incrementCounterButton.clicked -= OnIncrementCounterButtonClicked;
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