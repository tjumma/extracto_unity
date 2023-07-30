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
        
        private Label _cooldownLabel;
        private Label _healthLabel;
        private Label _damageLabel;
        
        public void SetEnabled(bool isEnabled)
        {
            _characterScreen.style.display = isEnabled ? DisplayStyle.Flex : DisplayStyle.None;
            GetComponent<MeshRenderer>().enabled = isEnabled;
        }

        void Awake()
        {
            _root = document.rootVisualElement;
            _characterScreen = _root.Q<VisualElement>("character-screen");
            _cooldownPB = _characterScreen.Q<ProgressBar>("cooldown-progress-bar");
            _cooldownLabel = _cooldownPB.Q<Label>("cooldown-label");
            _healthPB = _characterScreen.Q<ProgressBar>("health-progress-bar");
            _healthLabel = _healthPB.Q<Label>("health-label");
            _damageLabel = _characterScreen.Q<Label>("damage-label");
        }

        public void ApplyData(CharacterInfo characterInfo)
        {
            _cooldownPB.value = (float)((float)characterInfo.cooldownTimer / (float)characterInfo.cooldown) * 100;
            _cooldownLabel.text = $"Next action: {characterInfo.cooldownTimer} / {characterInfo.cooldown}";
            _healthPB.value = (float)((float)characterInfo.health / (float)characterInfo.maxHealth) * 100;
            _healthLabel.text = $"HP: {characterInfo.health} / {characterInfo.maxHealth}";
            _damageLabel.text = $"Damage: {characterInfo.attackDamage}";
        }
    }
}