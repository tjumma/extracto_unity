using UnityEngine;

namespace Extracto
{
    public class Character : MonoBehaviour
    {
        private UICharacter _ui;
        
        public void InitData(CharacterInfo characterInfo, UICharacter ui)
        {
            _ui = ui;
            
            _ui.ApplyData(characterInfo);
        }
        
        public void UpdateData(CharacterInfo characterInfo)
        {
            _ui.ApplyData(characterInfo);
        }
    }
}