using System;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace JCBF.Util {
    /// <summary>
    /// Provides static methods for performing common programming tasks
    /// </summary>
    public sealed class ToolChest {


        /// <summary>
        /// Creates a file name from the current date and time
        /// </summary>
        /// <returns>string in format [month]_[day]_[year]_[hour]_[minute]_[second]_[millisecond]</returns>
        public static string getFileNameFromDate() {
            System.DateTime dt = DateTime.Now;
            string retval = dt.Month.ToString() + "_" + dt.Day.ToString() + "_" + dt.Year.ToString() + "_" + dt.Hour.ToString() +
                "_" + dt.Minute + "_" + dt.Second + "_" + dt.Millisecond;
            return retval;
        }

        /// <summary>
        /// Returns true when a string value of "true" is passes
        /// </summary>
        /// <param name="val">string to parse</param>
        /// <returns>bool value based on string</returns>
        public static bool isChecked(string val) {
            if (val == null)
                return false;
            if (val.ToUpper().Equals("TRUE"))
                return true;
            else
                return false;
        }

        

        ///<summary>
        /// takes an array list of Strings and returns a string with optional qualifiers and seperators
        /// @param list The list to be converted to a string
        /// @param qualifier The string that can be used to wrap each element. If qualifier =  ^ it will be ommited
        /// @param seperator The string that will seperate each element. If seperator =  ^ it will be ommited
        /// @param escapeChar Char to be used to escape any qulifiers that may be part of the element
        ///</summary>
        public static string getStringFromArrayList(ArrayList list, string qualifier, string seperator, string escapeChar) {
            if (list == null)
                throw new System.ArgumentNullException("list", "The Array list can not be null");
            if (string.IsNullOrEmpty(seperator))
                seperator = ",";
            if (string.IsNullOrEmpty(qualifier))
                qualifier = "^";

            StringBuilder buf = new StringBuilder();
            IEnumerator myEnum = list.GetEnumerator();
            int i = 0;
            while (myEnum.MoveNext()) {
                string str = myEnum.Current.ToString();
                if (!qualifier.Equals("^"))
                    buf.Append(qualifier);
                buf.Append(str.Replace(qualifier, qualifier + escapeChar));
                if (!qualifier.Equals("^"))
                    buf.Append(qualifier);
                if (i + 1 != list.Count) {
                    if (!seperator.Equals("^"))
                        buf.Append(seperator);
                }
                i++;
            }

            return buf.ToString();
        }

        ///<summary>
        ///takes an array list of Strings and returns a string with each element wrapped in html tags you like
        ///@param list The list to be converted to a string
        ///@param opentag The Opening html tag
        ///@param closeTag The Closing html tag
        ///</summary>
        public static string getHTMLFromArrayList(ArrayList list, string openTag, string closeTag) {
            if (list == null)
                throw new System.ArgumentNullException("list", "The Array list can not be null");
            StringBuilder buf = new StringBuilder();
            IEnumerator myEnum = list.GetEnumerator();
            while (myEnum.MoveNext()) {
                string str = myEnum.Current.ToString();
                buf.Append(openTag);
                buf.Append(str);
                buf.Append(closeTag);

            }

            return buf.ToString();
        }

        ///<summary>
        /// The getArrayFromString function returns an array of strings based on a delimiter and a qualifier
        /// it is useful for importing comma delimited files. For example, to convert the following line into
        /// an array of strings
        /// <param name="line">The line of text to be parsed. For comma delimited files, line would be one line of each file</param>
        /// <param name="delim">The charactor used as a field seperator</param>
        /// <param name="qualifier">The charactor used as a qualifier to contain the text. Most common qualifier is a double quote.</param>
        ///</summary>
        public static string[] getArrayFromString(string line, char delim, char qualifier) {
            return getArrayFromString(line, delim, qualifier, 10);
        }
        ///<summary>
        /// The getArrayFromString function returns an array of strings based on a delimiter and a qualifier
        /// it is useful for importing comma delimited files. For example, to convert the following line into
        /// an array of strings:
        /// <param name="line">The line of text to be parsed. For comma delimited files, line would be one line of each file</param>
        /// <param name="delim">The charactor used as a field seperator</param>
        /// <param name="qualifier">The charactor used as a qualifier to contain the text. Most common qualifier is a double quote.</param>
        /// <param name="numCols">The expected number of columns per line.</param>
        ///</summary>
        public static string[] getArrayFromString(string line, char delim, char qualifier, int numCols) {
            if (numCols <= 0)
                throw new ArgumentException("numCols must be 1 or greater", "numCols");

            if (line == (string)null)
                throw new ArgumentNullException("line");

            string[] retVal = new string[numCols];
            int counter = 0;
            bool qualOpen = false;
            char[] myArray = line.ToCharArray();
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < myArray.Length; i++) {
                if (myArray[i] == qualifier)
                    qualOpen = (!qualOpen);
                else if ((myArray[i] == delim) && (!qualOpen)) {
                    if (counter < numCols) {
                        retVal[counter] = buffer.ToString();
                        buffer.Length = 0;
                        counter++;
                    }
                }
                else {
                    buffer.Append(myArray[i]);
                }
            }
            // last item
            if (buffer.Length > 0) {
                retVal[numCols - 1] = buffer.ToString();
            }

            return retVal;

        }
        ///<summary>
        /// <param> str The string to be converted to a bool. Possible values can be:<para>
        /// 1,0,Y,YES,N,NO. Not case sensitive.</para></param>
        ///</summary>
        public static bool convertToBoolean(string str) {
            if (str == null)
                return false;
            try {
                int i = Int32.Parse(str);
                return convertToBoolean(i);
            }
            catch (System.Exception) {
                if (str.ToUpper().Equals("Y") || str.ToUpper().Equals("YES") || str.ToUpper().Equals("TRUE"))
                    return true;
                else
                    return false;
            }
        }


        /// <summary>
        /// Converts an integer to bool. Any number greater than 0 returns true otherwise false
        /// </summary>
        /// <param name="someNum">Integer to be converted to a bool.</param>
        /// <returns> An Integer less than 1 will return false otherwise it will return true</returns>
        public static bool convertToBoolean(int someNum) {
            if (someNum < 1) return false;
            else return true;
        }

        /// <summary>
        /// takes a bool value and returns 1 of true or 0 if false
        /// </summary>
        /// <param name="tf"></param>
        /// <returns></returns>
        public static int boolToInt(bool tf) {
            if (tf)
                return 1;
            else
                return 0;
        }


        /// <summary>
        /// For use with command object parameters that allow nulls
        /// </summary>
        /// <param name="str">String to check</param>
        /// <returns>will return the string or System.DBNull.Value if the object is null or empty</returns>
        public static Object procNulls(string str) {
            if (string.IsNullOrWhiteSpace(str)) {
                return System.DBNull.Value;
            }
            else { return str; }
        }


        ///<summary>
        /// The getArrayFromString function returns an array of strings based on a delimiter.
        /// It functions in a similar way as the Split function but trims leading and trailing white space from each string.
        /// <param name="inStr"> string to be split into an array.</param>
        /// <param name="delim"> The delimiter.</param>
        ///</summary>
        ///<returns>Array of strings.</returns>
        public static string[] getArrayFromString(string inStr, string delim) {

            if (string.IsNullOrEmpty(delim))
                throw new ArgumentNullException("delim");

            if(string.IsNullOrEmpty(inStr))
                throw new ArgumentNullException("inStr");

            string[] retVal = inStr.Split(delim.ToCharArray());
            try {
                for (int i = 0; i < retVal.Length; i++) {
                    retVal[i] = retVal[i].Trim();
                }
            }
            catch (System.Exception) {
            }
            return retVal;
        }

        /// <summary>
        /// Checks an array to see if a the specified string exists in it.
        /// </summary>
        /// <param name="arr">The array to be checked</param>
        /// <param name="val">The string to be found in the array.</param>
        /// <returns></returns>
        public static bool isStringInArray(string[] arr, string val) {
            if ((arr != null)) {
                for (int i = 0; i < arr.Length; i++) {
                    if (((arr[i]==null) && (val==null)) || (arr[i]!=null) &&  arr[i].Equals(val)) {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Takes a string and returns a formatted version of the string with the first char of every word capitalized.
        /// For Example I AM SAM would return I Am Sam.
        /// </summary>
        /// <param name="str">String to be formatted</param>
        /// <returns>Formatted String</returns>
        public static string InitCap(string str) {
            if (!string.IsNullOrWhiteSpace(str)) {
                if (str.Length > 1) {
                    char[] sep = { ' ' };
                    string[] strArr = str.Split(sep);
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < strArr.Length; i++) {
                        strArr[i] = strArr[i].Substring(0, 1).ToUpper() + strArr[i].Substring(1).ToLower();
                        builder.Append(strArr[i]);
                        builder.Append(' ');
                    }
                    return builder.ToString().Trim();
                }
                else {
                    return str.ToUpper();
                }
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// checks a string to verify whether or not it is a numeric value
        /// </summary>
        /// <param name="str">value to be checked</param>
        /// <returns>true if all characters in string are numeric</returns>
        public static bool isNumeric(string str) {
            return isNumeric(str, false);
        }

        /// <summary>
        /// checks a string to verify whether or not it is a numeric value
        /// </summary>
        /// <param name="str">value to be checked</param>
        /// <param name="allowDecimal">whether or not to allow decimals</param>
        /// <returns>true if all characters in string are numeric</returns>
        public static bool isNumeric(string str, bool allowDecimal) {
            if ((str == null) || (str.Length <= 0)) {
                return false;
            }
            char[] strA = str.ToCharArray();
            bool retval = true;
            for (int i = 0; i < strA.Length; i++) {
                if ((!Char.IsNumber(strA[i]))) {
                    if (!(allowDecimal && strA[i].Equals('.'))) {
                        retval = false;
                        //break;
                    }
                }
            }
            return retval;
        }

        /// <summary>
        /// removes all HTML from string
        /// </summary>
        /// <param name="HtmlInput"></param>
        /// <returns></returns>
        public static string StripHTMLFromString(string HtmlInput)
        {
            if (string.IsNullOrWhiteSpace(HtmlInput))
            {
                return string.Empty;
            }

            return Regex.Replace(HtmlInput, @"<(.|\n)*?>", String.Empty);

        }

        /// <summary>
        /// Gets the IP Address (Unicast) of the first operational network adaptor on the local machine
        /// </summary>
        /// <returns>an IP Address</returns>
        public static string getLocalIPAddress() {
            string ip = "0.0.0.0";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters) {
                if (adapter.OperationalStatus.Equals(OperationalStatus.Up)) {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    if (adapterProperties.UnicastAddresses.Count > 0) {
                        foreach (IPAddressInformation address in adapterProperties.UnicastAddresses) {

                            if (!address.Address.ToString().Equals("127.0.0.1")) {
                                ip = address.Address.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            return ip;
        }
    }
}
