using System;

namespace ProductionCode
{
    public class DeviceReadingValueDto
    {
        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            set
            {
                _isDirty = value;
            }
        }

        private string _readingMask;

        public string ReadingMask
        {
            get { return _readingMask; }
            set
            {
                _readingMask = value;
                IsDirty = true;
            }
        }

        private double? _dueDateValue;

        public double? DueDateValue
        {
            get { return _dueDateValue; }
            set
            {
                //Bug 974 - Bug 220555: rounding on reading form 7
                if (value != null) _dueDateValue = ReadingMask == "7" ? Math.Floor((double) value) : value;
                else _dueDateValue = null;
                IsDirty = true;
            }
        }

        private double? _dueDateValueCache;

        public double? DueDateValueCache
        {
            get { return _dueDateValueCache; }
            set
            {
                _dueDateValueCache = value;
                IsDirty = true;
            }
        }

        private int _trialsCunsumptionRule;

        public int TrialsCunsumptionRule
        {
            get { return _trialsCunsumptionRule; }
            set
            {
                _trialsCunsumptionRule = value;
                IsDirty = true;
            }
        }

    }
}
