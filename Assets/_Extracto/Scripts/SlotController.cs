using System.Collections.Generic;
using UnityEngine;

namespace Extracto
{
    public class SlotController : MonoBehaviour
    {
        [SerializeField] private List<SlotBehaviour> slotBehaviours;

        public Vector3 GetSlotPosition(int slotIndex)
        {
            return slotBehaviours[slotIndex].transform.position;
        }
    }
}