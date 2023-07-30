using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Extracto
{
    public class CardSelector : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private UnityToReact unityToReact;
        [SerializeField] private List<int> cardCostByType;
        
        public LayerMask cardLayer;
        public LayerMask planeLayer;
        public LayerMask catcherLayer;
        public CardsPile selectedPile;
        public CardsPile handPile;

        private bool _hasCardSelected;
        public CardBehaviour CurrentCard;
        public int _currentCardIndexInHand;

        private Run _run;

        [Inject]
        public void Construct(Run run)
        {
            _run = run;
        }

        void Update()
        {
            if (!_hasCardSelected && Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, cardLayer))
                {
                    Transform objectHit = hit.transform;

                    var card = hit.transform.GetComponent<CardBehaviour>();

                    if (card != null)
                    {
                        Debug.Log("Selected a card");
                        _hasCardSelected = true;
                        CurrentCard = card;
                        _currentCardIndexInHand = handPile.Cards.IndexOf(CurrentCard.gameObject);
                        handPile.Remove(card.gameObject);
                        selectedPile.Add(card.gameObject);
                    }

                    // Do something with the object that was hit by the raycast.
                }
            }

            if (_hasCardSelected)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    //cast UPGRADE
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, catcherLayer))
                    {
                        var slot = hit.transform.GetComponent<SlotBehaviour>();
                        if (slot != null && cardCostByType[CurrentCard.CardType] <= _run.RunData.experience)
                        {
                            selectedPile.Remove(CurrentCard.gameObject);
                            Destroy(CurrentCard.gameObject);

                            unityToReact.InvokeUpgrade(_currentCardIndexInHand, slot.SlotId);
                            
                            _hasCardSelected = false;
                            CurrentCard = null;
                        }
                        else
                        {
                            //or return back
                            selectedPile.Remove(CurrentCard.gameObject);
                            handPile.Add(CurrentCard.gameObject, _currentCardIndexInHand);
                    
                            _hasCardSelected = false;
                            CurrentCard = null;
                        }
                    }
                    else
                    {
                        //or return back
                        selectedPile.Remove(CurrentCard.gameObject);
                        handPile.Add(CurrentCard.gameObject, _currentCardIndexInHand);

                        _hasCardSelected = false;
                        CurrentCard = null;
                    }
                }
                else
                {
                    Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayer))
                    {
                        selectedPile.transform.position = hit.point;
                    }
                    
                    // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    // worldPosition.z = Camera.main.nearClipPlane
                }
            }
        }
    }
}