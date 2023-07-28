using UnityEngine;
using UnityEngine.UIElements;

namespace Extracto
{
    public class UIConnectWallet : MonoBehaviour
    {
        [SerializeField] private UIDocument document;
        
        private VisualElement _root;
        private VisualElement _connectWalletScreen;

        void Awake()
        {
            _root = document.rootVisualElement;
            _connectWalletScreen = _root.Q<VisualElement>("connect-wallet-screen");
        }

        public void SetEnabled(bool isEnabled)
        {
            _connectWalletScreen.style.display = isEnabled ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}