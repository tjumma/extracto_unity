using UnityEngine;
using UnityEngine.Serialization;

namespace Extracto
{
    public class Character : MonoBehaviour
    {
        private UICharacter _ui;

        public CharacterInfo CurrentInfo;
        public int CurrentSlotIndex;

        private SlotController _slotController;
        
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
            if (newInfo.alignment == 1)
                Debug.Log($"MY SLOT INDEX: {newSlotIndex}");
            
            if (newSlotIndex != CurrentSlotIndex)
            {
                Debug.Log("NEW SLOT INDEX");
                
                _ui.SetEnabled(false);
                
                var newUI = _slotController.GetCharacterUI(newSlotIndex);
                _ui = newUI;

                transform.position = _slotController.GetSlotPosition(newSlotIndex);

                _ui.SetEnabled(true);

                CurrentSlotIndex = newSlotIndex;
            }

            CurrentInfo = newInfo;
            _ui.ApplyData(newInfo);
        }

        public void Kill()
        {
            _ui.SetEnabled(false);
            Destroy(this.gameObject);
        }
    }
}