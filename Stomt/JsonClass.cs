using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Net.Http;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 16/10/2018.
/// </summary>

namespace Stomt
{
    public class JsonClass
    {
        /// <summary>
        /// Gets json data and transforms them into a usable form. The usable form is a list of key value pairs.
        /// </summary>
        /// <param name="sa_data">The json data to organize in a list of key value pairs.</param>
        /// <param name="i_index">The index to begin this function.</param>
        /// <param name="s_loop_escape">The chain function calling escape value.</param>
        /// <param name="i_new_index">The new index to begin next function.</param>
        /// <returns>The json data organized in a list of key value pairs.</returns>
        public static List<KeyValuePair<string, object>> uf_kvpsol_GetDataFromJson(string[] sa_data, int i_index, string s_loop_escape, out int i_new_index)
        {
            // Define the json's data declaration tags.
            string[] sa_tags = new string[] { "\"", "\":", ",\"", "{", "}", "[", "]" };

            // Create a list of key value pairs to store the organized json data.
            List<KeyValuePair<string, object>> kvpsol_values = new List<KeyValuePair<string, object>>();

            // Continue only if there are valid data.
            if (sa_data != null)
            {
                // Get the length of json data.
                int i_data_length = sa_data.Length;

                // If index is invalid, then reset it to minimum valid one.
                if (i_index < 0)
                {
                    i_index = 0;
                }

                // Checks if loop's escape value is valid.
                bool b_no_loop_escape = string.IsNullOrWhiteSpace(s_loop_escape);

                // Check all available data, step by step.
                for (; i_index < i_data_length; i_index++)
                {
                    // Get the next character as possible parameter.
                    string s_parameter = sa_data[i_index];

                    // If loop escape value or current parameter is the escape value, then stop anything.
                    if ((b_no_loop_escape == false) && (s_parameter == s_loop_escape))
                    {
                        break;
                    }

                    // If json's data declaration tags are missing the parameter's value, then it is a validated parameter value.
                    if (sa_tags.Contains(s_parameter) == false)
                    {
                        // Increase index to next step.
                        int i_index_step = i_index + 1;

                        // Get next parameter following symbol from data.
                        string s_parameter_following_symbol = (i_index_step < i_data_length) ? sa_data[i_index_step] : null;

                        // Get the parameter's values.
                        if (s_parameter_following_symbol == "\":")
                        {
                            // Increase index to next step.
                            i_index_step = i_index_step + 1;

                            // Get next value type from data.
                            string s_value_type = (i_index_step < i_data_length) ? sa_data[i_index_step] : null;

                            // Check the value type and get its data.
                            switch (s_value_type)
                            {
                                case "[": // Array value.
                                    // Create a storage to add the array values findings.
                                    List<KeyValuePair<string, object>> kvpsol_array_values = new List<KeyValuePair<string, object>>();

                                    // Check all available data in this smaller part, step by step.
                                    for (; i_index < i_data_length; i_index++)
                                    {
                                        // Get next value array from data.
                                        string s_value_array = (i_index < i_data_length) ? sa_data[i_index] : null;

                                        // If it is a closing array tag, then close the search in this smaller part of data.
                                        if (s_value_array == "]")
                                        {
                                            break;
                                        }

                                        // Check the elements in the array.
                                        if (s_value_array == "{") // Child element value.
                                        {
                                            // Get the list of the key value pair with the array values.
                                            List<KeyValuePair<string, object>> kvpsol_array_child_values = uf_kvpsol_GetDataFromJson(sa_data, i_index + 1, "}", out i_index);

                                            // Add a key value pair of organized value in the list.
                                            kvpsol_array_values.Add(new KeyValuePair<string, object>(s_parameter, kvpsol_array_child_values));
                                        }
                                        else if ((s_value_array == "\"") || (s_value_array == ",\"")) // Element value.
                                        {
                                            // Increase child index to next step.
                                            int i_child_index = i_index + 1;

                                            // Get next child value from data.
                                            string s_child_value_array = (i_child_index < i_data_length) ? sa_data[i_child_index] : null;

                                            // Add this value if it isn't a json's data declaration tag.
                                            if (sa_tags.Contains(s_child_value_array) == false)
                                            {
                                                // Add a key value pair of organized value in the list.
                                                kvpsol_array_values.Add(new KeyValuePair<string, object>(s_parameter, s_child_value_array));
                                            }
                                        }
                                    }

                                    // Add a key value pair of organized value in the list.
                                    kvpsol_values.Add(new KeyValuePair<string, object>(s_parameter, kvpsol_array_values));
                                    break;
                                case "{": // Child element value.
                                    // Get the list of the key value pair with the child element values.
                                    List<KeyValuePair<string, object>> kvpsol_child_values = uf_kvpsol_GetDataFromJson(sa_data, i_index_step, "}", out i_index);
                                    
                                    // Add a key value pair of organized value in the list.
                                    kvpsol_values.Add(new KeyValuePair<string, object>(s_parameter, kvpsol_child_values));
                                    break;
                                case "\"": // Element value.
                                    // Increase index to next step.
                                    i_index_step = i_index_step + 1;

                                    // Get next value from data.
                                    string s_value = (i_index_step < i_data_length) ? sa_data[i_index_step] : null;

                                    // Add a key value pair of organized value in the list.
                                    kvpsol_values.Add(new KeyValuePair<string, object>(s_parameter, s_value));
                                    break;
                                default: // Generic value.
                                    // Add a key value pair of organized value in the list.
                                    kvpsol_values.Add(new KeyValuePair<string, object>(s_parameter, s_value_type));
                                    break;
                            }
                        }
                    }
                }
            }

            // Set the new index for usage with the next function, if any.
            i_new_index = i_index;

            // Return the json data, organized in a list of key value pairs.
            return kvpsol_values;
        }

        /// <summary>
        /// Creates a nested array form for json usage.
        /// </summary>
        /// <param name="sa_parameters">The nested array's values.</param>
        /// <returns>The json form of the nested array.</returns>
        public static string uf_s_NestedArrayParameter(string[] sa_parameters)
        {
            // Creates a json form of a nested array. Else, it returns an empty character.
            return (DataClass.uf_b_ValidArray(sa_parameters) == true) ? "[" + string.Join("][", sa_parameters) + "]" : "";
        }

        /// <summary>
        /// Creates a nested parameters container for json usage.
        /// </summary>
        /// <param name="kvpssl_container">The list of key value pairs which it will be the container.</param>
        /// <param name="s_main_parameter">The main parameter.</param>
        /// <param name="sa_child_parameters">The array of child parameters.</param>
        /// <param name="sa_values">The array of parameter's values.</param>
        /// <returns>A list of key value pairs with the nested parameters.</returns>
        public static List<KeyValuePair<string, string>> uf_kvpssl_NestedArrayParametersToList(List<KeyValuePair<string, string>> kvpssl_container, string s_main_parameter, string[] sa_child_parameters, string[] sa_values)
        {
            // If container is empty, then make it a new one.
            if (kvpssl_container == null)
            {
                kvpssl_container = new List<KeyValuePair<string, string>>();
            }

            // If array of values isn't valid, then return the container as it is.
            if (DataClass.uf_b_ValidArray(sa_values) == false)
            {
                return kvpssl_container;
            }

            // Create the nested array parameter json form.
            string s_nested_array_parameter = uf_s_NestedArrayParameter(sa_child_parameters);

            // If the nested array parameter isn't valid, then return the container as it is.
            if (string.IsNullOrWhiteSpace(s_nested_array_parameter) == true)
            {
                return kvpssl_container;
            }

            // Create the parameter json form.
            string s_parameter = s_main_parameter + s_nested_array_parameter;

            // Check each value in the values' array.
            for (int i = 0; i < sa_values.Length; i++)
            {
                // Get the next value from the array of values.
                string s_value = sa_values[i];

                // If this value is valid, then add it to container.
                if (string.IsNullOrWhiteSpace(s_value) == false)
                {
                    kvpssl_container.Add(new KeyValuePair<string, string>(s_parameter, s_value));
                }
            }

            // Return the updated container of the key value pair.
            return kvpssl_container;
        }

        /// <summary>
        /// Creates a form url encoded content from a key value pair array.
        /// </summary>
        /// <param name="kvpssa_values">The key value pair array.</param>
        /// <returns>The created form url encoded content.</returns>
        public static FormUrlEncodedContent uf_fuec_PrepareRequestParameters(KeyValuePair<string, string>[] kvpssa_values)
        {
            // Check if the key value pair array is valid.
            if ((kvpssa_values != null) && (kvpssa_values.Length > 0))
            {
                // Create a list to store the valid key value pair entries.
                List<KeyValuePair<string, string>> kvpssl_valid_values = new List<KeyValuePair<string, string>>();

                // Check all values in the key value pair array.
                for (int i = 0; i < kvpssa_values.Length; i++)
                {
                    // Get the next key value pair entry.
                    KeyValuePair<string, string> kvpss_value = kvpssa_values[i];

                    // Check if this key value pair entry is valid.
                    if ((string.IsNullOrWhiteSpace(kvpss_value.Key) == false) && (string.IsNullOrWhiteSpace(kvpss_value.Value) == false))
                    {
                        // Add this key value pair entry in the validated values' list.
                        kvpssl_valid_values.Add(kvpss_value);
                    }
                }

                // If the the validated values' list has values, then return a form url encoded content with these values.
                if (kvpssl_valid_values.Count > 0)
                {
                    return new FormUrlEncodedContent(kvpssl_valid_values);
                }
            }

            // If it isn't valid, then return an empty form url encoded content.
            return null;
        }
    }
}
