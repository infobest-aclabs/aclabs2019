using System;

namespace ProductionCode
{
    public class ValidationHelper
    {
        #region Private constants

        private const string LITER = "l";
        private const string CUBIC_METER = "m3";

        private const string WATT_HOUR = "wh";
        private const string KILO_WATT_HOUR = "kwh";
        private const string MEGA_WATT_HOUR = "mwh";
        private const string GIGA_WATT_HOUR = "gwh";

        private const string JOULE = "j";
        private const string KILO_JOULE = "kj";
        private const string MEGA_JOULE = "mj";
        private const string GIGA_JOULE = "gj";

        private const string GIGA_CALORIE = "gcal";

        private const string MINUTE = "min";
        private const string HOUR = "h";

        #endregion

        /// <summary>
        /// Converts the given value between the 2 given units
        /// </summary>
        /// <param name="from">
        /// Convert from this unit
        /// </param>
        /// <param name="to">
        /// Convert into this unit
        /// </param>
        /// <param name="value">
        /// The value to convert
        /// </param>
        /// <returns>
        /// The converted value
        /// </returns>
        public static double ConvertValue(object from, object to, double value)
        {
            double result = value;
            double multiplier = 1.0;
            if (@from == null
                || to == null)
            {
                return result;
            }
            string sFrom = @from.ToString();
            string sTo = to.ToString();
            if (String.IsNullOrEmpty(sFrom)
                || String.IsNullOrEmpty(sTo))
            {
                return result;
            }

            sFrom = sFrom.ToLower();
            sTo = sTo.ToLower();

            switch (sFrom)
            {
                case LITER:
                {
                    if (sTo == CUBIC_METER)
                    {
                        multiplier = 0.001;
                    }
                    break;
                }
                case CUBIC_METER:
                {
                    if (sTo == LITER)
                    {
                        multiplier = 1000;
                    }
                    break;
                }
                case WATT_HOUR:
                {
                    switch (sTo)
                    {
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.000001;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.000000001;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 3600;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 3.6;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 0.0036;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 0.0000036;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 0.000859845228;
                            break;
                        }
                    }
                    break;
                }
                case KILO_WATT_HOUR:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.000001;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 3600000;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 3600;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 3.6;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 0.0036;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 0.859845228;
                            break;
                        }
                    }
                    break;
                }
                case MEGA_WATT_HOUR:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 1000000;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 3600000000;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 3600000;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 3600;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 3.6;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 859.845228;
                            break;
                        }
                    }
                    break;
                }
                case GIGA_WATT_HOUR:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 1000000000;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 1000000;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 3600000000000;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 3600000000;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 3600000;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 3600;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 859845.228;
                            break;
                        }
                    }
                    break;
                }
                case JOULE:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 0.000277778;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 0.000000277778;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.000000000277778;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.000000000000277778;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 0.000001;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 0.000000001;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 0.000000238846;
                            break;
                        }
                    }
                    break;
                }
                case KILO_JOULE:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 0.277778;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 0.000277778;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.000000277778;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.000000000277778;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 0.000001;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 0.000238846;
                            break;
                        }
                    }
                    break;
                }
                case MEGA_JOULE:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 277.778;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 0.277778;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.000277778;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.0000000277778;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 1000000;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case GIGA_JOULE:
                        {
                            multiplier = 0.001;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 0.238846;
                            break;
                        }
                    }
                    break;
                }
                case GIGA_JOULE:
                {
                    switch (sTo)
                    {
                        case WATT_HOUR:
                        {
                            multiplier = 277778;
                            break;
                        }
                        case KILO_WATT_HOUR:
                        {
                            multiplier = 277.778;
                            break;
                        }
                        case MEGA_WATT_HOUR:
                        {
                            multiplier = 0.277778;
                            break;
                        }
                        case GIGA_WATT_HOUR:
                        {
                            multiplier = 0.0000277778;
                            break;
                        }
                        case JOULE:
                        {
                            multiplier = 1000000000;
                            break;
                        }
                        case KILO_JOULE:
                        {
                            multiplier = 1000000;
                            break;
                        }
                        case MEGA_JOULE:
                        {
                            multiplier = 1000;
                            break;
                        }
                        case GIGA_CALORIE:
                        {
                            multiplier = 238.846;
                            break;
                        }
                    }
                    break;
                }
                case MINUTE:
                {
                    if (sTo == HOUR)
                    {
                        multiplier = 0.016666667;
                    }
                    break;
                }
                case HOUR:
                {
                    if (sTo == MINUTE)
                    {
                        multiplier = 60;
                    }
                    break;
                }
            }

            // decimal is used for better accuracy
            result = (double)((decimal)value * (decimal)multiplier);
            return result;
        }
    }
}
