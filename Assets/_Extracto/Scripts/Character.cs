using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Extracto
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private UICharacter _ui;

        public CharacterInfo CurrentInfo;
        public int CurrentSlotIndex;

        private SlotController _slotController;
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Death = Animator.StringToHash("Death");

        public void InitData(CharacterInfo characterInfo, UICharacter ui, SlotController slotController, int slotIndex)
        {
            _slotController = slotController;
            CurrentInfo = characterInfo;
            CurrentSlotIndex = slotIndex;
            if (characterInfo.alignment == 1)
                Debug.Log($"INITIAL SLOT INDEX: {CurrentSlotIndex}");
            _ui = ui;
            
            _ui.SetEnabled(true);
            _ui.ApplyData(characterInfo);
        }
        
        public void UpdateData(CharacterInfo newInfo, int newSlotIndex)
        {

            if (newSlotIndex != CurrentSlotIndex)
            {
                _ui.SetEnabled(false);
                
                var newUI = _slotController.GetCharacterUI(newSlotIndex);
                _ui = newUI;

                // transform.position = _slotController.GetSlotPosition(newSlotIndex);
                transform.DOMove(_slotController.GetSlotPosition(newSlotIndex), 0.9f);

                _ui.SetEnabled(true);

                CurrentSlotIndex = newSlotIndex;
            }
            
            if (newInfo.state == 1 && animator != null)
                animator.SetTrigger(Attack);

            CurrentInfo = newInfo;
            _ui.ApplyData(newInfo);
        }

        public void Kill()
        {
            _ui.SetEnabled(false);
            
            if (animator != null)
                animator.SetTrigger(Death);
            
            DestroyAfterKill().Forget();
        }

        private async UniTaskVoid DestroyAfterKill()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.6f), ignoreTimeScale: false);
            Destroy(this.gameObject);
        }
    }
}