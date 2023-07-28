using System;

namespace Extracto
{
    public class Player
    {
        public Action<PlayerData> OnPlayerDataUpdated;
        
        public PlayerData PlayerData
        {
            get { return _playerData;  }
            set
            {
                _playerData = value;
                OnPlayerDataUpdated?.Invoke(_playerData);
            }
        }
        
        private PlayerData _playerData;
    }
}