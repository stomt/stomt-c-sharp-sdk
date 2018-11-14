using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 12/10/2018.
/// </summary>

namespace Stomt
{
    public class DataClass
    {
        /// <summary>
        /// Checks if a given array is valid.
        /// </summary>
        /// <typeparam name="T">The data type of array.</typeparam>
        /// <param name="ta_values">The array of values.</param>
        /// <returns>The validation of array.</returns>
        public static bool uf_b_ValidArray<T>(T[] ta_values)
        {
            // An array is valid if it isn't empty.
            return (ta_values != null) && (ta_values.Length > 0);
        }

        /// <summary>
        /// Checks if a given list is valid.
        /// </summary>
        /// <typeparam name="T">The data type of list.</typeparam>
        /// <param name="tl_values">The list of values.</param>
        /// <returns>The validation of list</returns>
        public static bool uf_b_ValidList<T>(List<T> tl_values)
        {
            // A list is valid if it isn't empty.
            return (tl_values != null) && (tl_values.Count > 0);
        }

        /// <summary>
        /// Searches a given key in a list and gets the value.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="kvpstl_values">The list to search the key value.</param>
        /// <param name="s_key">The key value to search in the list.</param>
        /// <returns>The value that the key belongs.</returns>
        public static T uf_t_GetValueFromKeyValuePairListWithStringKey<T>(List<KeyValuePair<string, T>> kvpstl_values, string s_key)
        {
            // Check if list of values and requested key are valid.
            if ((uf_b_ValidList(kvpstl_values) == true) && (string.IsNullOrWhiteSpace(s_key) == false))
            {
                // Search all key value pairs for the requested key.
                for (int i = 0; i < kvpstl_values.Count; i++)
                {
                    // Get the current key value pair.
                    KeyValuePair<string, T> kvpso_current_value = kvpstl_values[i];

                    // If the requested key is found, then return its value.
                    if (kvpso_current_value.Key == s_key)
                    {
                        return kvpso_current_value.Value;
                    }
                }
            }

            // If every fails, then return the default value.
            return default(T);
        }

        /// <summary>
        /// Searches a given key in a list and gets the converted value.
        /// </summary>
        /// <typeparam name="T">The conversion data type.</typeparam>
        /// <param name="kvpstl_values">The list to search the key value.</param>
        /// <param name="s_key">The key value to search in the list.</param>
        /// <returns>The converted value that the key belongs.</returns>
        public static T uf_t_GetConvertedValueFromKeyValuePairListWithStringKey<T>(List<KeyValuePair<string, object>> kvpsol_values, string s_key)
        {
            // Get the value from the given List, checked by requested key and convert it to r 
            return ConversionClass.uf_t_ConvertObjectToGeneric<T>(uf_t_GetValueFromKeyValuePairListWithStringKey(kvpsol_values, s_key));
        }
    }
}
