using UnityEngine;
using UnityEngine.UIElements;

namespace Extracto
{
    public class UICharacter : MonoBehaviour
    {
        [SerializeField] private UIDocument document;

        private VisualElement _root;
        private VisualElement _characterScreen;
        
        private ProgressBar _cooldownPB;
        private ProgressBar _healthPB;

        void Awake()
        {
            _root = document.rootVisualElement;
            _characterScreen = _root.Q<VisualElement>("character-screen");
            _cooldownPB = _characterScreen.Q<ProgressBar>("cooldown-progress-bar");
            _healthPB = _characterScreen.Q<ProgressBar>("health-progress-bar");
        }

        public void ApplyData(CharacterInfo characterInfo)
        {
            Debug.Log($"cooldown is {(float)((float)characterInfo.cooldownTimer / (float)characterInfo.cooldown)}");
            _cooldownPB.value = (float)((float)characterInfo.cooldownTimer / (float)characterInfo.cooldown) * 100;
        }
    }
}