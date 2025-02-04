#region Using
#region System
using System;
#endregion
#endregion

#region Namespace
#region PSS
#region DHPM
#region CryptoWallets
#region DataLayer
namespace PSS.DHPM.CryptoWallets.DataLayer
{
	#region Class
	#region ConversorTipos
	public class ConversorTipos
	{
		#region Functions
		#region Bool
		#region BooleanData
		#region (Object obj)
		public static bool BooleanData(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return false;
			}

			else
			{
				if (bool.TryParse(obj.ToString(), out bool o) == false)
				{
					return false;
				}

				return o;
			}
		}
		#endregion
		#endregion

		#region BoolObj2Bool
		#region (Object obj)
		public static bool BoolObj2Bool(object obj)
		{
			return ConversorTipos.BooleanData(obj);
		}
		#endregion
		#endregion

		#region BoolStr2Bool
		#region (String str)
		public static bool BoolStr2Bool(string str)
		{
			if (str == "" || str == "0")
			{
				return false;
			}

			return System.Convert.ToBoolean(str);
		}
		#endregion
		#endregion
		#endregion

		#region Byte
		#region ByteData
		#region (String str)
		public static byte ByteData(string str)
		{
			if (byte.TryParse(str, out byte i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region Char
		#region CharData
		#region (String str)
		public static char CharData(string str)
		{
			if (char.TryParse(str, out char c) == false)
			{
				return default;
			}

			return c;
		}
		#endregion
		#endregion
		#endregion

		#region DateTime
		#region DataDateTimePicker
		#region (String str)
		public static DateTime DataDateTimePicker(string str)
		{
			if (string.IsNullOrWhiteSpace(str) || str.Equals(DBNull.Value))
			{
				return new DateTime(1900, 1, 1, 0, 0, 0);
			}

			var styles = System.Globalization.DateTimeStyles.None;

			if (DateTime.TryParse(str, CultureES, styles, out DateTime d) == false)
			{
				return new DateTime(1900, 1, 1, 0, 0, 0);
			}

			return d.Date;
		}
		#endregion
		#endregion

		#region DateObj2Date
		#region (Object obj)
		public static DateTime DateObj2Date(object obj)
		{
			return ConversorTipos.DateTimeData(obj);
		}
		#endregion
		#endregion

		#region DateStr2Date
		#region (String str)
		public static DateTime DateStr2Date(string str)
		{
			return ConversorTipos.DataDateTimePicker(str);
		}
		#endregion
		#endregion

		#region DateTimeData
		#region (Object obj)
		public static DateTime DateTimeData(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return DateTimeData("");
			}

			return DateTimeData(obj.ToString());
		}
		#endregion

		#region (String str)
		public static DateTime DateTimeData(string str)
		{
			//var f = new DateTime(1900, 1, 1, 0, 0, 0);

			if (DateTime.TryParse(str, out DateTime f) == false)
			{
				return new DateTime(1900, 1, 1, 0, 0, 0);
			}

			return f;
		}
		#endregion
		#endregion
		#endregion

		#region Decimal
		#region DecimalData
		#region (Object obj)
		public static decimal DecimalData(object obj)
		{
			return DecimalData(DataDecimal(obj));
		}
		#endregion

		#region (String str)
		public static decimal DecimalData(string str)
		{
			if (decimal.TryParse(str, out decimal d) == false)
			{
				return 0;
			}

			return d;
		}
		#endregion
		#endregion

		#region DecimalObj2Decimal
		#region (Object obj)
		public static decimal DecimalObj2Decimal(object obj)
		{
			return ConversorTipos.DecimalData(obj);
		}
		#endregion
		#endregion

		#region DecimalStr2Decimal
		#region (String str)
		public static decimal DecimalStr2Decimal(string str)
		{
			return ConversorTipos.DecimalData(str);
		}
		#endregion
		#endregion
		#endregion

		#region Double
		#region DoubleData
		#region (String str)
		public static double DoubleData(string str)
		{
			if (double.TryParse(str, out double i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region Float
		#region SingleData
		#region (String str)
		public static float SingleData(string str)
		{
			if (float.TryParse(str, out float i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region Int
		#region Int32Data
		#region (Object obj)
		public static int Int32Data(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return 0;
			}

			return Int32Data(obj.ToString());
		}
		#endregion

		#region (String str)
		public static int Int32Data(string str)
		{
			if (int.TryParse(str, out int i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion

		#region IntegerData
		#region (Object obj)
		public static int IntegerData(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return Int32Data("");
			}

			return Int32Data(obj.ToString());
		}
		#endregion

		#region (String str)
		public static int IntegerData(string str)
		{
			if (int.TryParse(str, out int i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion

		#region IntegerObj2Integer
		#region (Object obj)
		public static int IntegerObj2Integer(object obj)
		{
			return ConversorTipos.IntegerData(obj);
		}
		#endregion
		#endregion

		#region IntegerStr2Integer
		#region (String str)
		public static int IntegerStr2Integer(string str)
		{
			return ConversorTipos.IntegerData(str);
		}
		#endregion
		#endregion
		#endregion

		#region Long
		#region Int64Data
		#region (Object obj)
		public static long Int64Data(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return Int64Data("");
			}

			return Int64Data(obj.ToString());
		}
		#endregion

		#region (String str)
		public static long Int64Data(string str)
		{
			if (long.TryParse(str, out long i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region Object
		#region DataDateTimeDate
		#region (String str)
		public static object DataDateTimeDate(string str)
		{
			if (DateTime.TryParse(str, out DateTime d))
			{
				return d.Date;
			}

			else
			{
				return DBNull.Value;
			}
		}
		#endregion
		#endregion
		#endregion

		#region SByte
		#region SByteData
		#region (String str)
		public static sbyte SByteData(string str)
		{
			if (sbyte.TryParse(str, out sbyte i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region Short
		#region Int16Data
		#region (String str)
		public static short Int16Data(string str)
		{
			if (short.TryParse(str, out short i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region String
		#region Bool2Str
		#region (Bool b)
		public static string Bool2Str(bool b)
		{
			return b ? "1" : "0";
		}
		#endregion
		#endregion

		#region BoolObj2Str
		#region (Object obj)
		public static string BoolObj2Str(object obj)
		{
			return ConversorTipos.DataBoolean(obj, false);
		}
		#endregion
		#endregion

		#region DataBoolean
		#region (Object obj, Bool devolverNULL = false)
		public static string DataBoolean(object obj, bool devolverNULL = false)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return devolverNULL ? "" : "0";
			}

			else
			{
				return BooleanData(obj) ? "1" : "0";
			}
		}
		#endregion
		#endregion

		#region DataDateTime
		#region (DateTime dt)
		public static string DataDateTime(DateTime dt)
		{
			return DataDateTime(dt, false);
		}
		#endregion

		#region (DateTime dt, Bool usarMinValue)
		public static string DataDateTime(DateTime dt, bool usarMinValue)
		{
			var s = dt.ToString("dd/MM/yyyy");

			if (dt.Year < 1900)
			{
				s = "01/01/1900";
			}

			if (s == "01/01/1900" && usarMinValue == false)
			{
				s = "";
			}

			return s;
		}
		#endregion

		#region (Object obj)
		public static string DataDateTime(object obj)
		{
			return DataDateTime(obj, false);
		}
		#endregion

		#region (Object obj, Bool usarMinValue)
		public static string DataDateTime(object obj, bool usarMinValue)
		{
			string sMin = "";

			if (usarMinValue)
			{
				sMin = "01/01/1900";
			}

			if (obj == null || obj.Equals(DBNull.Value))
			{
				return sMin;
			}

			else
			{
				if (obj is string && string.IsNullOrWhiteSpace(obj.ToString()))
				{
					return sMin;
				}

				var d = new DateTime(1900, 1, 1, 0, 0, 0);
				var styles = System.Globalization.DateTimeStyles.None;
				// DateTime.TryParse(txt, d)
				DateTime.TryParse(obj.ToString(), CultureES, styles, out d);

				if (d.Year < 1900)
				{
					d = new DateTime(1900, 1, 1, 0, 0, 0);
				}

				var s = d.ToString("dd/MM/yyyy");

				if (s == "01/01/1900" && usarMinValue == false)
				{
					s = "";
				}

				return s;
			}
		}
		#endregion
		#endregion

		#region DataDecimal
		#region (Object obj)
		public static string DataDecimal(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return "";
			}

			else
			{
				decimal d;
				decimal.TryParse(obj.ToString(), out d);
				return d.ToString().TrimEnd(new[] { '.', ',' });
			}
		}
		#endregion
		#endregion

		#region DataInt32
		#region (Object obj)
		public static string DataInt32(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return "";
			}

			else
			{
				int d;
				int.TryParse(obj.ToString(), out d);
				return d.ToString();
			}
		}
		#endregion
		#endregion

		#region DataInt64
		#region (Object obj)
		public static string DataInt64(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return "";
			}

			else
			{
				long d;
				long.TryParse(obj.ToString(), out d);
				return d.ToString();
			}
		}
		#endregion
		#endregion

		#region DataInteger
		#region (Object obj)
		public static string DataInteger(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return "";
			}

			else
			{
				int d;
				int.TryParse(obj.ToString(), out d);
				return d.ToString();
			}
		}
		#endregion
		#endregion

		#region DataTimeSpan
		#region (Object obj)
		public static string DataTimeSpan(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return "00:00";
			}

			else
			{
				if (TimeSpan.TryParse(obj.ToString(), out TimeSpan d) == false)
				{
					return "00:00";
				}

				return d.ToString(@"hh\:mm");
			}
		}
		#endregion

		#region (TimeSpan val)
		public static string DataTimeSpan(TimeSpan val)
		{
			return val.ToString(@"hh\:mm");
		}
		#endregion
		#endregion

		#region Date2Str
		#region (DateTime d)
		public static string Date2Str(DateTime d)
		{
			return d.ToString("dd/MM/yyyy");
		}
		#endregion

		#region (DateTime d, Bool usarMinValue)
		public static string Date2Str(DateTime d, bool usarMinValue)
		{
			return ConversorTipos.DataDateTime(d, usarMinValue);
		}
		#endregion
		#endregion

		#region DateObj2Str
		#region (Object obj)
		public static string DateObj2Str(object obj)
		{
			return ConversorTipos.DataDateTime(obj);
		}
		#endregion
		#endregion

		#region Decimal2Str
		#region (Decimal d)
		public static string Decimal2Str(decimal d)
		{
			return d.ToString("0.##");
		}
		#endregion
		#endregion

		#region DecimalObj2Str
		#region (Object obj)
		public static string DecimalObj2Str(object obj)
		{
			return ConversorTipos.DataDecimal(obj);
		}
		#endregion
		#endregion

		#region Integer2Str
		#region (Decimal d)
		public static string Integer2Str(decimal d)
		{
			return d.ToString();
		}
		#endregion
		#endregion

		#region IntegerObj2Str
		#region (Object obj)
		public static string IntegerObj2Str(object obj)
		{
			return ConversorTipos.DataInteger(obj);
		}
		#endregion
		#endregion

		#region TimeSpan2Str
		#region (TimeSpan ts)
		public static string TimeSpan2Str(TimeSpan ts)
		{
			return ts.ToString(@"hh\:mm");
		}
		#endregion
		#endregion

		#region TimeSpanObj2Str
		#region (Object obj)
		public static string TimeSpanObj2Str(object obj)
		{
			return ConversorTipos.DataTimeSpan(obj);
		}
		#endregion
		#endregion
		#endregion

		#region TimeSpan
		#region TimeSpanData
		#region (Object obj)
		public static TimeSpan TimeSpanData(object obj)
		{
			if (obj == null || obj.Equals(DBNull.Value))
			{
				return new TimeSpan(0, 0, 0);
			}

			else
			{
				//TimeSpan d = new TimeSpan(0, 0, 0);

				if (TimeSpan.TryParse(obj.ToString(), out TimeSpan d) == false)
				{
					return default;
				}

				return d;
			}
		}
		#endregion

		#region (String str)
		public static TimeSpan TimeSpanData(string str)
		{
			//TimeSpan c = new TimeSpan(0, 0, 0);

			if (TimeSpan.TryParse(str, out TimeSpan c) == false)
			{
				return default;
			}

			return c;
		}
		#endregion
		#endregion

		#region TimeSpanObj2TimeSpan
		#region (Object obj)
		public static TimeSpan TimeSpanObj2TimeSpan(object obj)
		{
			return ConversorTipos.TimeSpanData(obj);
		}
		#endregion
		#endregion

		#region TimeSpanStr2TimeSpan
		#region (String str)
		public static TimeSpan TimeSpanStr2TimeSpan(string str)
		{
			return ConversorTipos.TimeSpanData(str);
		}
		#endregion
		#endregion
		#endregion

		#region UInt
		#region UInt32Data
		#region (String str)
		public static uint UInt32Data(string str)
		{
			if (uint.TryParse(str, out uint i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region ULong
		#region UInt64Data
		#region (String str)
		public static ulong UInt64Data(string str)
		{
			if (ulong.TryParse(str, out ulong i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion

		#region UShort
		#region UInt16Data
		#region (String str)
		public static ushort UInt16Data(string str)
		{
			if (ushort.TryParse(str, out ushort i) == false)
			{
				return 0;
			}

			return i;
		}
		#endregion
		#endregion
		#endregion
		#endregion

		#region Properties
		#region System
		#region Globalization
		#region CultureInfo
		#region CultureES
		private static System.Globalization.CultureInfo CultureES
		{
			get
			{
				if (_CultureES == null)
				{
					_CultureES = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");
				}

				return _CultureES;
			}
		}
		#endregion
		#endregion
		#endregion
		#endregion
		#endregion

		#region Variables
		#region System
		#region Globalization
		#region CultureInfo
		private static System.Globalization.CultureInfo _CultureES;
		#endregion
		#endregion
		#endregion
		#endregion
	}
	#endregion
	#endregion
}
#endregion
#endregion
#endregion
#endregion
#endregion