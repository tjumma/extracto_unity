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
        private Button _incrementCounterButton;

        [Inject]
        public void Construct(UnityToReact unityToReact)
        {
            _unityToReact = unityToReact;
        }

        void Awake()
        {
            _root = document.rootVisualElement;
            _incrementCounterButton = _root.Q<Button>("increment-counter-button");
        }

        private void OnEnable()
        {
            _incrementCounterButton.clicked += OnIncrementCounterButtonClicked;
        }
        
        private void OnDisable()
        {
            _incrementCounterButton.clicked -= OnIncrementCounterButtonClicked;
        }

        private void OnIncrementCounterButtonClicked()
        {
            Debug.Log("IncrementCounterButton clicked");
            _unityToReact.InvokeIncrementCounter("testerino");
        }
    }
}