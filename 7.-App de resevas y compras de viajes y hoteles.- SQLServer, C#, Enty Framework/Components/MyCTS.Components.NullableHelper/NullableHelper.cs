using System;
using System.Collections.Generic;
using System.Text;

namespace MyCTS.Components.NullableHelper
{
    public sealed class Types
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly int IntegerNullValue = -1;
        /// <summary>
        /// 
        /// </summary>
        public static readonly long LongNullValue = -1L;
        /// <summary>
        /// 
        /// </summary>
        public static readonly decimal DecimalNullValue = -1;
        /// <summary>
        /// 
        /// </summary>
        public static readonly double DoubleNullValue = -1;
        /// <summary>
        /// 
        /// </summary>
        public static readonly float FloatNullValue = -1;
        /// <summary>
        /// 
        /// </summary>
        public static readonly DateTime DateNullValue = new DateTime(1753, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        public static readonly string StringNullValue = string.Empty;
        public static readonly string StringValue = "0";
    }

    public sealed class MyCTSConvert
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromInteger(int value)
        {
            if (value == Types.IntegerNullValue)
                return string.Empty;
            return value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromLong(long value)
        {
            if (value == Types.LongNullValue)
                return string.Empty;
            return value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromDateTime(DateTime value)
        {
            if (value == Types.DateNullValue)
                return string.Empty;
            return value.ToString("dd/MM/yyyy");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string FromDateTime(DateTime value, string format)
        {
            if (value == Types.DateNullValue)
                return string.Empty;
            return value.ToString(format);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromDecimal(decimal value)
        {
            if (value == Types.DecimalNullValue)
                return string.Empty;
            return value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromDouble(double value)
        {
            if (value == Types.DoubleNullValue)
                return string.Empty;
            return value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FromFloat(float value)
        {
            if (value == Types.FloatNullValue)
                return string.Empty;
            return value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInteger(string value)
        {
            int tempInt;
            if (int.TryParse(value, out tempInt))
                return tempInt;
            return Types.IntegerNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInteger(int value)
        {
            if (value == Types.IntegerNullValue)
                return 0;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(string value)
        {
            long tempLong;
            if (long.TryParse(value, out tempLong))
                return tempLong;
            return Types.LongNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(string value)
        {
            DateTime tempDate;
            if (DateTime.TryParse(value, out tempDate))
                return tempDate;
            return Types.DateNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(DateTime value)
        {
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double ToDouble(string value)
        {
            Double tempDouble;
            if (double.TryParse(value, out tempDouble))
                return tempDouble;
            return Types.DoubleNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float ToFloat(string value)
        {
            float tempFloat;
            if (float.TryParse(value, out tempFloat))
                return tempFloat;
            return Types.FloatNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(string value)
        {
            Decimal tempDecimal;
            if (decimal.TryParse(value, out tempDecimal))
                return tempDecimal;
            return Types.DecimalNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return value;
            return Types.StringNullValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(int value)
        {
            if (value == Types.IntegerNullValue)
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(long value)
        {
            if (value == Types.LongNullValue)
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(DateTime value)
        {
            if (value == Types.DateNullValue)
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(decimal value)
        {
            if (value == Types.DecimalNullValue)
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(double value)
        {
            if (value == Types.DoubleNullValue)
                return DBNull.Value;
            return value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBValue(float value)
        {
            if (value == Types.FloatNullValue)
                return DBNull.Value;
            return value;
        }
    }


}
