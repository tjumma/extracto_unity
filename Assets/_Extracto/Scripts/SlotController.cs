using System.Collections.Generic;
using UnityEngine;

namespace Extracto
{
    public class SlotController : MonoBehaviour
    {
        [SerializeField] private List<SlotBehaviour> slotBehaviours;
        [SerializeField] private List<UICharacter> characterUIs;

        public Vector3 GetSlotPosition(int slotIndex)
        {
            return slotBehaviours[slotIndex].transform.position;
        }
        
        public UICharacter GetCharacterUI(int slotIndex)
        {
            return characterUIs[slotIndex];
        }
    }
}