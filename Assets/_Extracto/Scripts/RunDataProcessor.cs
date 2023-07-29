using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extracto
{
    public class RunDataProcessor : MonoBehaviour
    {
        [SerializeField] private CharacterSpawner characterSpawner;
        [SerializeField] private SlotController slotController;
        
        private Dictionary<int, Character> charactersById = new Dictionary<int, Character>();

        private RunData _oldRunData;

        public void Process(RunData newRunData)
        {
            Debug.Log("RunDataProcessor Process");

            foreach (var characterInfo in newRunData.slots)
            {
                Debug.Log(characterInfo.characterType);
            }
            
            
            /////////

            // var newIds = newRunData.slots.Select(characterInfo => characterInfo.id).ToList();
            var newIds = new List<int>();

            for (int slotIndex = 0; slotIndex < newRunData.slots.Count; slotIndex++)
            {
                var characterInfo = newRunData.slots[slotIndex];
                
                if (characterInfo != null)
                {
                    newIds.Add(characterInfo.id);
                }
            }
            
            var oldIds = charactersById.Keys.ToList();

            var charactersToKill = new List<int>();
            var charactersToSpawn = new List<int>();
            var charactersToUpdate = new List<int>();

            foreach (var id in oldIds)
            {
                if (!newIds.Contains(id)) 
                    charactersToKill.Add(id);
                else 
                    charactersToUpdate.Add(id);
            }

            foreach (var newId in newIds)
            {
                if (!oldIds.Contains(newId))
                    charactersToSpawn.Add(newId);
            }

            //delete those whose ids are not in newRunData
            foreach (var idToKill in charactersToKill)
            {
                Destroy(charactersById[idToKill].gameObject);
                charactersById.Remove(idToKill);
            }

            //add those whose ids are not in oldRunData
            foreach (var idToSpawn in charactersToSpawn)
            {
                var characterInfo = newRunData.slots[idToSpawn];
                if (characterInfo == null)
                    continue;
                
                var slotIndex = newRunData.slots.IndexOf(characterInfo);
                var characterUI = slotController.GetCharacterUI(slotIndex);
                var newCharacter = characterSpawner.SpawnCharacterInSlot(characterInfo, slotIndex);

                if (newCharacter != null)
                {
                    newCharacter.InitData(characterInfo, characterUI);
                    charactersById.Add(idToSpawn, newCharacter);
                }
            }

            //update those that intersect
            foreach (var idToUpdate in charactersToUpdate)
            {
                var characterInfo = newRunData.slots[idToUpdate];
                if (characterInfo == null)
                    continue;
                charactersById[idToUpdate].UpdateData(characterInfo);
            }
        }
    }
}