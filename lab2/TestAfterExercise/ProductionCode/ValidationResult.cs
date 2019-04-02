using System.Collections.Generic;

namespace ProductionCode
{
    public class ValidationResult
    {
        public List<string> Errors { get; set; }
        public bool IsError { get; set; }
    }
}
