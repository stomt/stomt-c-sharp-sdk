using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 16/10/2018.
/// </summary>

namespace Stomt
{
    public class ConversionClass
    {
        /// <summary>
        /// Converts a boolean value to string for usage in json's content.
        /// </summary>
        /// <param name="b_value">The boolean to convert.</param>
        /// <returns>The string from validation.</returns>
        public static string uf_s_ValidBooleanToString(bool b_value)
        {
            // Converts a valid boolean to string. Else it returns an empty character.
            return (b_value == true) ? uf_s_BooleanToString(b_value) : "";
        }

        /// <summary>
        /// Converts a boolean value to string for usage in json.
        /// </summary>
        /// <param name="b_value">The boolean value to convert it to string.</param>
        /// <returns>The boolean value as string.</returns>
        public static string uf_s_BooleanToString(bool b_value)
        {
            // Converts the given boolean value to string.
            return (b_value == true) ? "1" : "0"; // Else it doesn't work properly.
        }

        /// <summary>
        /// Converts a string array's values to a string with comma separation.
        /// </summary>
        /// <param name="sa_values">The string array.</param>
        /// <returns>The string array as string.</returns>
        public static string uf_s_StringArrayToString(string[] sa_values)
        {
            // Checks if array is valid.
            if (DataClass.uf_b_ValidArray(sa_values) == false)
            {
                return "";
            }

            // Create a list to store the valid strings.
            List<string> sl_values = new List<string>();

            // Check all strings in the array.
            for (int i = 0; i < sa_values.Length; i++)
            {
                // Get next value from the array.
                string s_value = sa_values[i];

                // Adds only the valid strings in the list.
                if (string.IsNullOrWhiteSpace(s_value) == false)
                {
                    sl_values.Add(s_value);
                }
            }

            // Return the string array as string, separated by commas.
            return string.Join(",", sl_values.ToArray());
        }
        
        /// <summary>
        /// Adds prefix to a string value for json usage.
        /// </summary>
        /// <param name="s_value">The string value to add the prefix.</param>
        /// <param name="s_prefix">The value's prefix.</param>
        /// <returns>The value with prefix or empty.</returns>
        public static string uf_s_NonNullableStringWithPrefix(string s_value, string s_prefix)
        {
            // Adds prefix to string value. Else it returns an empty character.
            return (string.IsNullOrWhiteSpace(s_value) == false) ? s_prefix + s_value : "";
        }

        /// <summary>
        /// Adds suffix to a string value for json usage.
        /// </summary>
        /// <param name="s_value">The string value to add the suffix.</param>
        /// <param name="s_suffix">The value's suffix.</param>
        /// <returns>The value with suffix or empty.</returns>
        public static string uf_s_NonNullableStringWithSuffix(string s_value, string s_suffix)
        {
            // Adds suffix to string value. Else it returns an empty character.
            return (string.IsNullOrWhiteSpace(s_value) == false) ? s_value + s_suffix : "";
        }

        /// <summary>
        /// Adds prefix to an integer value for json usage.
        /// </summary>
        /// <param name="i_value">The integer value to add the prefix.</param>
        /// <param name="s_prefix">The value's prefix.</param>
        /// <returns>The value with prefix or empty.</returns>
        public static string uf_s_PositiveIntegerWithPrefix(int i_value, string s_prefix)
        {
            // Adds prefix to integer value. Else it returns an empty character.
            return (i_value > 0) ? s_prefix + i_value : "";
        }

        /// <summary>
        /// Adds prefix to boolean value. Else it returns an empty character.
        /// </summary>
        /// <param name="b_value">The boolean value to add the prefix.</param>
        /// <param name="s_prefix">The value's prefix.</param>
        /// <returns>The value with prefix or empty.</returns>
        public static string uf_s_ValidBooleanWithPrefix(bool b_value, string s_prefix)
        {
            // Adds prefix to boolean value. Else it returns an empty character.
            return (b_value == true) ? s_prefix + b_value.ToString().ToLower() : "";
        }

        /// <summary>
        /// Validates a string value for json usage.
        /// </summary>
        /// <param name="s_value">The string value to check.</param>
        /// <returns>The value to check validated or empty.</returns>
        public static string uf_s_NonNullableString(string s_value)
        {
            // Validates a string value. Else it returns an empty character.
            return (string.IsNullOrWhiteSpace(s_value) == false) ? s_value : "";
        }

        /// <summary>
        /// Validates a string value by a check one for json usage.
        /// </summary>
        /// <param name="s_value">The string value to check.</param>
        /// <param name="s_check">The checking string value.</param>
        /// <returns>The value to check validated or empty.</returns>
        public static string uf_s_NonNullableStringByCheck(string s_value, string s_check)
        {
            // Validates a string value by a check one. Else it returns an empty character.
            return ((string.IsNullOrWhiteSpace(s_check) == false) && (string.IsNullOrWhiteSpace(s_value) == false)) ? s_value : "";
        }

        /// <summary>
        /// Convers a stream of data to base 64 string.
        /// </summary>
        /// <param name="strm_data">The stream of data.</param>
        /// <returns>The converted data to base 64 string form.</returns>
        public static string uf_s_DataToBase64String(Stream strm_data)
        {
            // Checks if data stream is valid.
            if ((strm_data == null) || (strm_data.Length < 1))
            {
                return "";
            }

            // Place the data stream in a binary reader.
            BinaryReader brdr_data = new BinaryReader(strm_data);

            // Checks if binary reader is valid.
            if (brdr_data == null)
            {
                return "";
            }

            // Read all data from the binary reader and store them in an array.
            byte[] ba_data = brdr_data.ReadBytes((int)strm_data.Length);

            // Checks if data is valid.
            if (ba_data == null)
            {
                return "";
            }

            // Return the converted data to base 64 string form.
            return Convert.ToBase64String(ba_data, 0, ba_data.Length);
        }
        
        /// <summary>
        /// Converts a given object to a selected data type.
        /// </summary>
        /// <typeparam name="T">The data type to convert the object.</typeparam>
        /// <param name="o_value">The object to convert.</param>
        /// <returns>The converted object.</returns>
        public static T uf_t_ConvertObjectToGeneric<T>(object o_value)
        {
            // Checks if the object is a valid one of this data type.
            if ((o_value != null) && (o_value is T))
            {
                // Convert object to desired data type.
                return (T)o_value;
            }

            // If it doesn't, then return the default value for this data type.
            return default(T);
        }
    }
}
