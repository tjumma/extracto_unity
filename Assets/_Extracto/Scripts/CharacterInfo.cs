using System;

namespace Extracto
{
    [Serializable]
    public class CharacterInfo
    {
        public int id;
        public int alignment;
        public int characterType;
        public int cooldown;
        public int cooldownTimer;
        public int maxHealth;
        public int health;
        public int attackDamage;
    }
}