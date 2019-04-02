namespace ProductionCode
{
    public interface IRule
    {
        ValidationResult ValidateRule(DeviceReadingValueDto deviceReadingValueDto, params object[] args);
    }
}
