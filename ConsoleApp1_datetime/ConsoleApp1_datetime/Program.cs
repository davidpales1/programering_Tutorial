using System;
using System.Globalization;

namespace ConsoleApp1_datetime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DateTime dt1 = new DateTime();
            dt1 = DateTime.Now;
            DateTime dt2 = new DateTime();

            TimeSpan diff = dt2 - dt1;
            dt2 = dt2.AddDays(5);
            TimeSpan diff2 = dt2 - dt2;
            TimeSpan diff3 = dt2.Subtract(dt2);
            DateTime dt3 = new DateTime(2022, 01, 11);
            DateTime dt4 = new DateTime();
            dt4 = Convert.ToDateTime("2020-01-11");
            bool isValidDate = DateTime.TryParse("2020-01-11", out DateTime dt5);
            bool isParseExact = DateTime.TryParseExact("2020-01-11", "yyyy-MM-dd",  CultureInfo.CurrentCulture
                , DateTimeStyles.None ,out DateTime dt6);
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            // Provide default formatting if arg is not an Int64.
            if (arg.GetType() != typeof(Int64))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Provide default formatting for unsupported format strings.
            string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
            if (!(ufmt == "H" || ufmt == "I"))
                try
                {
                    return HandleOtherFormats(fmt, arg);
                }
                catch (FormatException e)
                {
                    throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
                }

            // Convert argument to a string.
            string result = arg.ToString();

            // If account number is less than 12 characters, pad with leading zeroes.
            if (result.Length < ACCT_LENGTH)
                result = result.PadLeft(ACCT_LENGTH, '0');
            // If account number is more than 12 characters, truncate to 12 characters.
            if (result.Length > ACCT_LENGTH)
                result = result.Substring(0, ACCT_LENGTH);

            if (ufmt == "I")                    // Integer-only format.
                return result;
            // Add hyphens for H format specifier.
            else                                         // Hyphenated format.
                return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
        }
    }
}
