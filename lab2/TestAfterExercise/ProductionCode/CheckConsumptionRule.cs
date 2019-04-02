using System;
using System.Collections.Generic;

namespace ProductionCode
{
    public class CheckConsumptionRule : IRule
    {
        /// <summary>
        /// Executes the Check consumption
        /// </summary>
        /// <param name="deviceReadingValueDto">
        /// </param>
        /// <param name="args">
        /// Parameters of the validity check
        /// </param>
        /// <remarks>
        /// Required parameter count: 2 + 2
        /// args[0] :  Last year's status
        /// args[1] :  Last year's consumption
        /// args[2] :  Original Measure unit (optional, need in case of mask 9, 10, 11)
        /// args[3] :  New Measure unit (optional, need in case of mask 9, 10, 11)
        /// </remarks>
        public ValidationResult ValidateRule(DeviceReadingValueDto deviceReadingValueDto, params object[] args)
        {
            var deviceMask = deviceReadingValueDto.ReadingMask;
            double currentReading = Convert.ToDouble(deviceReadingValueDto.DueDateValue);
            double lastReading = Convert.ToDouble(args[0]);
            double lastConsumption = Convert.ToDouble(args[1]);
            double allowed;
            double? max = null;
            double limitLow = lastConsumption * 0.5;
            double limitHigh = lastConsumption * 2;
            bool noNeedToCheckConsumptionLimit = false;

            switch (deviceMask)
            {
                //case "4":
                //    {
                //        allowed = CheckConstantsForValidation.CHKVJGRENZWERTM4;
                //        break;
                //    }
                //case "5":
                //    {
                //        allowed = CheckConstantsForValidation.CHKVJGRENZWERTM5;
                //        break;
                //    }
                case AppConstants.HCA_WITHOUT_KEYDATE:
                    {
                        allowed = CheckConstantsForValidation.GRENZWERTM6;
                        break;
                    }
                case AppConstants.HCA_WITH_KEYDATE:
                    {
                        allowed = CheckConstantsForValidation.GRENZWERTM7;
                        break;
                    }

                case AppConstants.WATER_METER:
                case AppConstants.WATER_METER_WITH_DATAMODULE:
                    {
                        allowed = CheckConstantsForValidation.GRENZWERTM8KALT;
                        max = CheckConstantsForValidation.XGRENZWERTM8;
                        noNeedToCheckConsumptionLimit = true;
                        break;
                    }

                //case "9":
                //    {
                //        if (args.Length < 4)
                //        {
                //            throw new InvalidOperationException("Argument count < 4");
                //        }
                //        currentReading = ValidationHelper.ConvertValue(args[2], args[3], currentReading);
                //        allowed = CheckConstantsForValidation.CHKVJGRENZWERTM9;
                //        max = CheckConstantsForValidation.CHKFIXGRENZWERTM9;
                //        break;
                //    }

                case AppConstants.HEAT_METER:
                    {
                        if (args.Length < 4)
                        {
                            throw new InvalidOperationException("Argument count < 4");
                        }
                        currentReading = ValidationHelper.ConvertValue(args[2], args[3], currentReading);
                        allowed = CheckConstantsForValidation.GRENZWERTM10;
                        max = CheckConstantsForValidation.XGRENZWERTM10;
                        noNeedToCheckConsumptionLimit = true;
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            double consumption = Math.Abs(currentReading - lastReading);
            double delta = Math.Abs(lastConsumption - consumption);

            if ((lastConsumption > 0 && delta >= allowed && (!noNeedToCheckConsumptionLimit && !(limitLow <= consumption && consumption <= limitHigh))) || (max.HasValue && consumption > max))
            {
                if (AreTrialsAvailable(deviceReadingValueDto))
                {
                    return new ValidationResult
                    {
                        Errors = new List<string> { "MS3_ManualReadingValues_ValueDifferesTooMuch" },
                        IsError = true
                    };
                }

            }
            return new ValidationResult { Errors = null, IsError = false };
        }



        private bool AreTrialsAvailable(DeviceReadingValueDto deviceReadingValueDto)
        {
            //DueDateValueCache is used for saving the previous value inserted by the user
            //if the user inserts twice the same wrong value, the values should be saved
            if (deviceReadingValueDto.DueDateValue == deviceReadingValueDto.DueDateValueCache)
            {
                deviceReadingValueDto.TrialsCunsumptionRule--;
            }
            else
            {
                deviceReadingValueDto.TrialsCunsumptionRule = 1;
                deviceReadingValueDto.DueDateValueCache = deviceReadingValueDto.DueDateValue;
            }
            return deviceReadingValueDto.TrialsCunsumptionRule > 0;
        }
    }
}
