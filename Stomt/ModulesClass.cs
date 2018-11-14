using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 15/10/2018.
/// </summary>

namespace Stomt
{
    public class ModulesClass
    {
        // The http client which it will be used for the interaction with the api.
        public static HttpClient publ_httpc_client = new HttpClient();

        /// <summary>
        /// Sets Http Client's settings. You must run this first, else functions doesn't work.
        /// </summary>
        /// <param name="b_production_mode">The production mode (true = production, false = test)</param>
        /// <param name="s_application_id">Your application's id from stomt.</param>
        /// <returns>The process' success result.</returns>
        public static string uf_s_SetHttpClientSettings(bool b_production_mode, string s_application_id)
        {
            // If application id is empty, then return the no application id error message.
            if (string.IsNullOrWhiteSpace(s_application_id) == true)
            {
                return Constant.publ_cs_generic_no_application_id_message;
            }

            // Set stomt's api uri location and the application's id that it will be used to interact with it.
            publ_httpc_client.BaseAddress = new Uri(uf_s_GetStomtApiUri(b_production_mode));
            publ_httpc_client.DefaultRequestHeaders.Add("appid", s_application_id);

            // Reset accept section of request headers and add a declaration of json type requests.
            publ_httpc_client.DefaultRequestHeaders.Accept.Clear();
            publ_httpc_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Return the success message.
            return Constant.publ_cs_generic_success_message;
        }

        /// <summary>
        /// Gets the access token to keep alive login session to Stomt.
        /// </summary>
        /// <param name="s_username">The account's username.</param>
        /// <param name="s_password">The account's password.</param>
        /// <returns>The account's login access token and system's message.</returns>
        public static async Task<information> uf_atsk_cdt_Login(string s_username, string s_password)
        {
            // Get login data from stomt's api asyncrhonously.
            object o_login_values = await uf_atsk_o_GetDataFromRequest(stomt_feature.login, stomt_authentication.normal,
                new stomt_parameters().uf_cdt_SetNormalLoginParameters(s_username, s_password));

            // Convert the data from an object form to a more easy handled one.
            List<KeyValuePair<string, object>> kvpsol_login_values = ConversionClass.uf_t_ConvertObjectToGeneric<List<KeyValuePair<string, object>>>(o_login_values);

            // Gets a smaller portion of these data to allow the easier finding of the wanted values.
            List<KeyValuePair<string, object>> kvpsol_data_values = DataClass.uf_t_GetConvertedValueFromKeyValuePairListWithStringKey<List<KeyValuePair<string, object>>>(kvpsol_login_values, "data");

            // If no data is found, then something happened and display the error
            if (DataClass.uf_b_ValidList(kvpsol_data_values) == false)
            {
                // Return the error about the lack of data. 
                return new information(Constant.publ_cs_generic_error, DataClass.uf_t_GetConvertedValueFromKeyValuePairListWithStringKey<string>(kvpsol_login_values, "error"));
            }

            // Get the accees token from data's smaller portion.
            string s_access_token = DataClass.uf_t_GetConvertedValueFromKeyValuePairListWithStringKey<string>(kvpsol_data_values, "accesstoken");

            // Check if access token is valid.
            if (string.IsNullOrWhiteSpace(s_access_token) == false)
            {
                // Check if there is already an access token header to avoid duplicates.
                if (publ_httpc_client.DefaultRequestHeaders.Contains("accesstoken") == true)
                {
                    // Removes the old value.
                    publ_httpc_client.DefaultRequestHeaders.Remove("accesstoken");
                }

                // Adds the new access token to header.
                publ_httpc_client.DefaultRequestHeaders.Add("accesstoken", s_access_token);

                // Then return the access token and the success message.
                return new information(s_access_token, Constant.publ_cs_generic_success_message);
            }

            // If the access token is invalid, then return a no data error.
            return new information(Constant.publ_cs_generic_error, Constant.publ_cs_generic_no_data_message);
        }

        /// <summary>
        /// Gets the data from a returned request to a json api.
        /// </summary>
        /// <param name="cen_feature">The requested stomt feature.</param>
        /// <param name="cen_login">The authentication mode to login in stomt's api.</param>
        /// <param name="cdt_parameters">The json's content parameters.</param>
        /// <returns>The data returned from the request to api.</returns>
        public static async Task<object> uf_atsk_o_GetDataFromRequest(stomt_feature cen_feature, stomt_authentication cen_login, stomt_parameters cdt_parameters)
        {
            // Create the request to send to remote api.
            stomt_api_request cdt_request = ApiClass.uf_cdt_StomtApiMethodRequestUriSuffix(cen_feature, cen_login, cdt_parameters);
            
            // Request the data from the remote api asyncrhonously.
            HttpResponseMessage httprm_response = await ApiClass.uf_atsk_httprm_RestApiMethodRequest(publ_httpc_client, cdt_request.s_uri_suffix, cdt_request.httpcn_content, cdt_request.cen_method_request);

            // If http response is empty, then return an empty data and stop the process.
            if (httprm_response == null)
            {
                return null;
            }

            // Get the data from the api's response asyncrhonously.
            string s_response_content = await httprm_response.Content.ReadAsStringAsync();

            // If the retrieved data is a file, then don't do anything else and return the data instead.
            if ((cen_feature == stomt_feature.retrieve_exported_stomts) || (cen_feature == stomt_feature.retrieve_exported_users))
            {
                return s_response_content;
            }

            // Corrects the multiple backslash in url from uri data send.
            s_response_content = s_response_content.Replace("\\", ""); // url form fixing.

            // Corrects the multiple backslash in the rest of data from uri data send.
            string[] sa_data = Regex.Split(s_response_content, "([][{}])|(\\\":)|(,\\\")|(\\\")").
                Where(s_value => s_value != string.Empty).ToArray(); // The multiple backslash characters is the result of the escape characters of backslash (\) and double quotes (").

            // Returns the data from the json response, organized in key value pairs of key and value.
            return JsonClass.uf_kvpsol_GetDataFromJson(sa_data, 0, null, out int i_new_index);
        }

        /// <summary>
        /// Gets Stomt api's uri for requested mode.
        /// </summary>
        /// <param name="b_production_mode">The requested mode (true: production, false: test)</param>
        /// <returns>The requested Stomt api's uri for requested mode.</returns>
        public static string uf_s_GetStomtApiUri(bool b_production_mode)
        {
            // Get the requested Stomt api's uri for requested mode. 
            return (b_production_mode == true) ? "https://rest.stomt.com/" : "https://test.rest.stomt.com/";
        }
    }
}
