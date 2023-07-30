using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extracto
{
    public class RunDataProcessor : MonoBehaviour
    {
        [SerializeField] private CardsPile deck;
        [SerializeField] private CardsPile hand;
        
        public GameObject cardPrefab;
        [SerializeField] public CardSelector cardSelector;
    
        [SerializeField] private CharacterSpawner characterSpawner;
        [SerializeField] private SlotController slotController;
        
        private Dictionary<int, Character> charactersById = new Dictionary<int, Character>();
        private Dictionary<int, CardBehaviour> cardsById = new Dictionary<int, CardBehaviour>();

        private RunData _oldRunData;


        void ProcessCards(RunData newRunData)
        {
            var newIds = new List<int>();

            for (int cardSlotIndex = 0; cardSlotIndex < newRunData.cards.Count; cardSlotIndex++)
            {
                var cardInfo = newRunData.cards[cardSlotIndex];
                newIds.Add(cardInfo.id);
            }
            
            var oldIds = cardsById.Keys.ToList();
            
            var cardsToSpawn = new List<int>();

            foreach (var newId in newIds)
            {
                if (!oldIds.Contains(newId))
                    cardsToSpawn.Add(newId);
            }

            foreach (var cardToSpawnId in cardsToSpawn)
            {
                var newCard = Instantiate(cardPrefab).GetComponent<CardBehaviour>();
                var cardInfo = newRunData.cards.Find(x => x.id == cardToSpawnId);
                newCard.CardId = cardToSpawnId;
                newCard.ApplyType(cardInfo.cardType);
                hand.Add(newCard.gameObject, newRunData.cards.IndexOf(cardInfo));
                cardsById.Add(cardToSpawnId, newCard);
            }
        }

        public void Process(RunData newRunData)
        {
            ProcessCards(newRunData);

            Debug.Log("RunDataProcessor Process");


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
                var character = charactersById[idToKill];
                character.Kill();
                charactersById.Remove(idToKill);
            }
            
            //update those that intersect
            foreach (var idToUpdate in charactersToUpdate)
            {
                var characterInfo = newRunData.slots.Find(x => x.id == idToUpdate);
                var newSlotIndex = newRunData.slots.IndexOf(characterInfo);
                charactersById[idToUpdate].UpdateData(characterInfo, newSlotIndex);
            }

            //add those whose ids are not in oldRunData
            foreach (var idToSpawn in charactersToSpawn)
            {
                var characterInfo = newRunData.slots.Find(x => x.id == idToSpawn);
                if (characterInfo == null)
                    continue;
                
                var slotIndex = newRunData.slots.IndexOf(characterInfo);
                var characterUI = slotController.GetCharacterUI(slotIndex);
                var newCharacter = characterSpawner.SpawnCharacterInSlot(characterInfo, slotIndex);

                if (newCharacter != null)
                {
                    newCharacter.InitData(characterInfo, characterUI, slotController, slotIndex);
                    charactersById.Add(idToSpawn, newCharacter);
                }
            }
        }

        public void OnGameExit()
        {
            foreach (var idCharacter in charactersById)
            {
                idCharacter.Value.Kill();
            }

            charactersById = new Dictionary<int, Character>();
            
            foreach (var idCard in cardsById)
            {
                var card = idCard.Value;
                if (card != null)
                {
                    hand.Remove(card.gameObject);
                    Destroy(card.gameObject);
                }
            }

            cardsById = new Dictionary<int, CardBehaviour>();
        }
    }
}