using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Extracto
{
    public class UICreatePlayer : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        
        private UnityToReact _unityToReact;

        private VisualElement _root;
        private VisualElement _createPlayerScreen;
        private VisualElement _createPlayerPanel;
        private TextField _playerNameField;
        private Button _createPlayerButton;
        
        [Inject]
        public void Construct(UnityToReact unityToReact)
        {
            _unityToReact = unityToReact;
        }
        
        public void SetEnabled(bool isEnabled)
        {
            _createPlayerScreen.style.display = isEnabled ? DisplayStyle.Flex : DisplayStyle.None;
        }

        void Awake()
        {
            _root = document.rootVisualElement;
            
            _createPlayerScreen = _root.Q<VisualElement>("create-player-screen");
            
            _createPlayerPanel = _createPlayerScreen.Q<VisualElement>("create-player-panel");
            _playerNameField = _createPlayerPanel.Q<TextField>("player-name-field");
            _createPlayerButton = _createPlayerPanel.Q<Button>("create-player-button");
        }
        
        private void OnEnable()
        {
            _createPlayerButton.clicked += OnCreatePlayerButtonClicked;
        }
        
        private void OnDisable()
        {
            _createPlayerButton.clicked -= OnCreatePlayerButtonClicked;
        }
        
        private void OnCreatePlayerButtonClicked()
        {
            Debug.Log("CreatePlayer button clicked");
            _unityToReact.InvokeInitPlayer(_playerNameField.value);
        }
    }
}