using UnityEngine;

namespace Extracto
{
    public class Character : MonoBehaviour
    {
        private UICharacter _ui;
        
        public void InitData(CharacterInfo characterInfo, UICharacter ui)
        {
            _ui = ui;
            
            _ui.SetEnabled(true);
            _ui.ApplyData(characterInfo);
        }
        
        public void UpdateData(CharacterInfo characterInfo)
        {
            _ui.ApplyData(characterInfo);
        }

        public void Kill()
        {
            _ui.SetEnabled(false);
            Destroy(this.gameObject);
        }
    }
}