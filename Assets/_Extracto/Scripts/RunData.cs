using System;
using System.Collections.Generic;

namespace Extracto
{
    [Serializable]
    public class RunData
    {
        public int score;
        public int experience;
        public List<CharacterInfo> slots;
        public List<CardInfo> cards;
    }
}