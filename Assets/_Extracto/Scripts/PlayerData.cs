using System;

namespace Extracto
{
    [Serializable]
    public class PlayerData
    {
        public string publicKey;
        public string name;
        public int runsFinished;
        public int bestScore;
        public bool isInRun;
    }
}