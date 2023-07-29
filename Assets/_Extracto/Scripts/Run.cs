using System;

namespace Extracto
{
    public class Run
    {
        public Action<RunData> OnRunDataUpdated;
        
        public RunData RunData
        {
            get => _runData;
            set
            {
                _runData = value;
                OnRunDataUpdated?.Invoke(_runData);
            }
        }
        
        private RunData _runData;
    }
}