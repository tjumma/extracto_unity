using System;

namespace Extracto
{
    public class Player
    {
        public Action<PlayerData> OnPlayerDataUpdated;
        
        public PlayerData PlayerData
        {
            get => _playerData;
            set
            {
                _playerData = value;
                OnPlayerDataUpdated?.Invoke(_playerData);
            }
        }
        
        private PlayerData _playerData;
    }
}