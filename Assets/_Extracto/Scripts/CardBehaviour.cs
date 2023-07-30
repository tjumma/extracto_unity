using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Extracto
{
    public class CardBehaviour : MonoBehaviour
    {
        public int CardId;
        public int CardType;
        
        [SerializeField] private List<int> cardCostByType;

        public TextMeshPro cardTypeText;
        public TextMeshPro cardCostText;

        public void ApplyType(int cardType)
        {
            CardType = cardType;
            cardTypeText.text = cardType switch
            {
                0 => "Increase max health",
                1 => "Deal more damage",
                2 => "Attack faster"
            };
            cardCostText.text = cardCostByType[cardType].ToString();
        }
    }
}