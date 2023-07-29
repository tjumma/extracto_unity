using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Extracto
{
    public class CharacterSpawner : SerializedMonoBehaviour
    {
        [SerializeField] private SlotController slotController;

        public Dictionary<int, GameObject> characterPrefabsByType = new Dictionary<int, GameObject>();

        public Character SpawnCharacterInSlot(CharacterInfo characterInfo, int slotIndex)
        {
            if (characterPrefabsByType.TryGetValue(characterInfo.characterType, out var characterPrefab))
            {
                var slotPosition = slotController.GetSlotPosition(slotIndex);
                var quaternion = Quaternion.Euler(0, characterInfo.alignment == 0 ? 90 : -90, 0);
                var go = Instantiate(characterPrefab, slotPosition, quaternion);

                return go.GetComponent<Character>();
            }

            Debug.Log($"CANT FIND {characterInfo.characterType} TYPE IN PREFABS DICTIONARY");
            return null;
        }
    }
}