using DG.Tweening;
using EPOOutline;
using UnityEngine;

namespace Extracto
{
    public class EpoTweenTest : MonoBehaviour
    {
        [SerializeField] private Outlinable outlinable;
        
        void Start()
        {
            Debug.Log("Start");
            
            outlinable.FrontParameters.DOColor(new Color(0, 0, 1, 0), 5.0f);
            outlinable.FrontParameters.DODilateShift(0.0f, 5.0f);
            outlinable.FrontParameters.DOBlurShift(0.0f, 3.0f);
            outlinable.OutlineParameters.DOColor(new Color(1, 1, 1, 1), 5.0f);
        }
    }
}