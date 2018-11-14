using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 15/10/2018.
/// </summary>

namespace Stomt
{
    public class ApiClass
    {
        /// <summary>
        /// Sends parameters and other information to an api to get data asynchronously.
        /// </summary>
        /// <param name="httpcl_client">The http client to activate the interaction with api.</param>
        /// <param name="s_uri">The api's uri to send the http method.</param>
        /// <param name="httpc_content">The http content to send to api.</param>
        /// <param name="cen_method_request">The type of http method.</param>
        /// <returns>The http response message of the task.</returns>
        public static async Task<HttpResponseMessage> uf_atsk_httprm_RestApiMethodRequest(HttpClient httpcl_client, string s_uri, HttpContent httpc_content, http_method cen_method_request)
        {
            // Continue only if the http client is valid.
            if (httpcl_client != null)
            {
                //
                switch (cen_method_request)
                {
                    case http_method.post_request: // Post.
                        // Continue only if there is a valid http content.
                        if (httpc_content != null)
                        {
                            return await httpcl_client.PostAsync(s_uri, httpc_content); // Post it asynchronously to api.
                        }
                        break;
                    case http_method.get_request: // Get.
                        return await httpcl_client.GetAsync(s_uri);  // Get it asynchronously from api.
                    case http_method.put_request: // Put.
                        // Continue only if there is a valid http content.
                        if (httpc_content != null)
                        {
                            return await httpcl_client.PutAsync(s_uri, httpc_content);  // Put it asynchronously to api.
                        }
                        break;
                    case http_method.delete_request: // Delete.
                        return await httpcl_client.DeleteAsync(s_uri);  // Delete it asynchronously to api.
                    default:
                        break;
                }
            }

            // Create a failure http response message.
            HttpResponseMessage httprm_default_response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest // This is a bad request.
            };

            // Return the failure http response message to user.
            return httprm_default_response;
        }

        /// <summary>
        /// Prepares the stomt api request settings.
        /// </summary>
        /// <param name="cen_feature">The requested stomt feature.</param>
        /// <param name="cen_login">The authentication mode to login in stomt's api.</param>
        /// <param name="cdt_parameters">The json's content parameters.</param>
        /// <returns>The stomt api request settings.</returns>
        public static stomt_api_request uf_cdt_StomtApiMethodRequestUriSuffix(stomt_feature cen_feature, stomt_authentication cen_login, stomt_parameters cdt_parameters)
        {
            // Declare the form url encoded content storage for json's content parameters.
            FormUrlEncodedContent fuec_parameters;

            // Check which feature is requested and return its encoded content information.
            switch (cen_feature)
            {
                case stomt_feature.register_an_user: // Register an user.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_user_name_parameter, cdt_parameters.s_username),
                        new KeyValuePair<string, string>(stomt_parameters.cs_email_parameter, cdt_parameters.s_email),
                        new KeyValuePair<string, string>(stomt_parameters.cs_password_parameter, cdt_parameters.s_password),
                        new KeyValuePair<string, string>(stomt_parameters.cs_display_name_parameter, cdt_parameters.s_display_name),
                        new KeyValuePair<string, string>(stomt_parameters.cs_message_parameter, cdt_parameters.s_message)
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication", fuec_parameters, http_method.post_request);
                case stomt_feature.verify_email: // Verify email.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_verification_code_parameter, cdt_parameters.s_verification_code)
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication", fuec_parameters, http_method.put_request);
                case stomt_feature.login:
                    // Declare stomt's json content parameters storage.
                    KeyValuePair<string, string>[] kvpssa_parameters;

                    // Set json's content parameters.
                    switch (cen_login)
                    {
                        case stomt_authentication.facebook: // Facebook.
                            kvpssa_parameters = new KeyValuePair<string, string>[]
                            {
                                new KeyValuePair<string, string>(stomt_parameters.cs_login_method_parameter, cdt_parameters.s_login_method),
                                new KeyValuePair<string, string>(stomt_parameters.cs_authorisation_code_parameter, ConversionClass.uf_s_NonNullableStringByCheck(cdt_parameters.s_authorisation_code, cdt_parameters.s_state)),
                                new KeyValuePair<string, string>(stomt_parameters.cs_state_parameter, ConversionClass.uf_s_NonNullableString(cdt_parameters.s_state)),
                                new KeyValuePair<string, string>(stomt_parameters.cs_access_token_parameter, ConversionClass.uf_s_NonNullableString(cdt_parameters.s_access_token)),
                                new KeyValuePair<string, string>(stomt_parameters.cs_merge_parameter, ConversionClass.uf_s_ValidBooleanToString(cdt_parameters.b_merge))
                            };
                            break;
                        case stomt_authentication.reddit: // Reddit.
                            kvpssa_parameters = new KeyValuePair<string, string>[]
                            {
                                new KeyValuePair<string, string>(stomt_parameters.cs_login_method_parameter, cdt_parameters.s_login_method),
                                new KeyValuePair<string, string>(stomt_parameters.cs_authorisation_code_parameter, cdt_parameters.s_authorisation_code),
                                new KeyValuePair<string, string>(stomt_parameters.cs_state_parameter, cdt_parameters.s_state),
                                new KeyValuePair<string, string>(stomt_parameters.cs_merge_parameter, ConversionClass.uf_s_ValidBooleanToString(cdt_parameters.b_merge))
                            };
                            break;
                        case stomt_authentication.twitter: // Twitter.
                            kvpssa_parameters = new KeyValuePair<string, string>[]
                            {
                                new KeyValuePair<string, string>(stomt_parameters.cs_login_method_parameter, cdt_parameters.s_login_method),
                                new KeyValuePair<string, string>(stomt_parameters.cs_oauth_token_parameter, cdt_parameters.s_oauth_token),
                                new KeyValuePair<string, string>(stomt_parameters.cs_oauth_verifier_parameter, cdt_parameters.s_oauth_verifier),
                                new KeyValuePair<string, string>(stomt_parameters.cs_merge_parameter, ConversionClass.uf_s_ValidBooleanToString(cdt_parameters.b_merge))
                            };
                            break;
                        case stomt_authentication.normal: // Normal.
                        default:
                            kvpssa_parameters = new KeyValuePair<string, string>[]
                            {
                                new KeyValuePair<string, string>(stomt_parameters.cs_login_method_parameter, cdt_parameters.s_login_method),
                                new KeyValuePair<string, string>(stomt_parameters.cs_email_username_parameter, cdt_parameters.s_email_username),
                                new KeyValuePair<string, string>(stomt_parameters.cs_password_parameter, cdt_parameters.s_password),
                                new KeyValuePair<string, string>(stomt_parameters.cs_merge_parameter, ConversionClass.uf_s_ValidBooleanToString(cdt_parameters.b_merge))
                            };
                            break;
                    }

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/session", JsonClass.uf_fuec_PrepareRequestParameters(kvpssa_parameters), http_method.post_request);
                case stomt_feature.logout: // Logout.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/session", null, http_method.delete_request);
                case stomt_feature.oauth_login: // OAuth login.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/authorize" +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_client_id, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_client_id_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_redirect_uri, Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_redirect_uri_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.check_availability: // Check availability.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/checkAvailability" +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_property, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_property_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_value, Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_value_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.suggest_usernames: // Suggest usernames.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_SuggestUsernamesUriSuffix(cdt_parameters.s_display_name), null, http_method.get_request);
                case stomt_feature.forgot_password: // Forgot password.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_username_or_email_parameter, cdt_parameters.s_username_or_email)
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/forgotpassword", fuec_parameters, http_method.post_request);
                case stomt_feature.reset_password: // Reset password.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_reset_code_parameter, cdt_parameters.s_reset_code),
                        new KeyValuePair<string, string>(stomt_parameters.cs_new_password_parameter, cdt_parameters.s_new_password)
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/authentication/resetpassword", fuec_parameters, http_method.post_request);
                case stomt_feature.creates_a_stomt: // Creates a stomt.
                    // Set json's content parameters.
                    List<KeyValuePair<string, string>> kvpssl_stomt_container = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_text_parameter, cdt_parameters.s_text),
                        new KeyValuePair<string, string>(stomt_parameters.cs_target_id_parameter, cdt_parameters.s_target_id),
                        new KeyValuePair<string, string>(stomt_parameters.cs_positive_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_positive)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_lang_parameter, cdt_parameters.s_lang),
                        new KeyValuePair<string, string>(stomt_parameters.cs_url_parameter, cdt_parameters.s_url),
                        new KeyValuePair<string, string>(stomt_parameters.cs_anonym_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_anonym)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_img_name_parameter, cdt_parameters.s_img_name),
                        new KeyValuePair<string, string>(stomt_parameters.cs_file_uid_parameter, cdt_parameters.s_file_uid),
                        new KeyValuePair<string, string>(stomt_parameters.cs_lonlat_parameter, cdt_parameters.s_lonlat),
                        new KeyValuePair<string, string>(stomt_parameters.cs_files_parameter + JsonClass.uf_s_NestedArrayParameter(new string[] { stomt_parameters.cs_stomt_parameter, stomt_parameters.cs_file_uid_parameter }),
                            cdt_parameters.s_file_uid) // has a child element of string.
                    };

                    // Add to parameters the following nested array.
                    kvpssl_stomt_container = JsonClass.uf_kvpssl_NestedArrayParametersToList(kvpssl_stomt_container, stomt_parameters.cs_extradata_parameter,
                        new string[] { stomt_parameters.cs_labels_array_parameter, null }, cdt_parameters.sa_labels);

                    // Add to parameters the following json content.
                    if (cdt_parameters.o_json != null)
                    {
                        kvpssl_stomt_container.Add(new KeyValuePair<string, string>(stomt_parameters.cs_extradata_parameter, cdt_parameters.o_json.ToString())); // has a child element of json.
                    }

                    // Convert the key value pair container to json's content parameters storage.
                    fuec_parameters = new FormUrlEncodedContent(kvpssl_stomt_container);

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/stomts", fuec_parameters, http_method.post_request);
                case stomt_feature.read_a_stomt: // Read a stomt.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_ReadDeleteStomtsUriSuffix(cdt_parameters.s_stomt_id), null, http_method.get_request);
                case stomt_feature.delete_a_stomt: // Delete a stomt.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_ReadDeleteStomtsUriSuffix(cdt_parameters.s_stomt_id), null, http_method.delete_request);
                case stomt_feature.create_stomt_agreement: // Create stomt agreement.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_positive_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_positive)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_anonym_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_anonym)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_StomtAgreementAndVotersUriSuffix(cdt_parameters.s_stomt_id), fuec_parameters, http_method.post_request);
                case stomt_feature.delete_stomt_agreement: // Delete stomt agreement.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_StomtAgreementAndVotersUriSuffix(cdt_parameters.s_stomt_id), null, http_method.delete_request);
                case stomt_feature.get_stomt_voters: // Get stomt voters.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_StomtAgreementAndVotersUriSuffix(cdt_parameters.s_stomt_id), null, http_method.get_request);
                case stomt_feature.create_a_comment: // Create a comment.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_parent_id_parameter, cdt_parameters.s_parent_id), // can be null.
                        new KeyValuePair<string, string>(stomt_parameters.cs_text_parameter, cdt_parameters.s_text),
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_target_parameter, cdt_parameters.s_as_target),
                        new KeyValuePair<string, string>(stomt_parameters.cs_reaction_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_reaction)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_CreateReadCommentUriSuffix(cdt_parameters.s_stomt_id), fuec_parameters, http_method.post_request);
                case stomt_feature.read_stomt_comments: // Read stomt comments.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_CreateReadCommentUriSuffix(cdt_parameters.s_stomt_id), null, http_method.get_request);
                case stomt_feature.edit_a_comment: // Edit a comment.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_anonym_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_anonym)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_text_parameter, cdt_parameters.s_text),
                        new KeyValuePair<string, string>(stomt_parameters.cs_reaction_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_reaction)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_EditDeleteCommentUriSuffix(cdt_parameters.s_stomt_id, cdt_parameters.s_comment_id), fuec_parameters, http_method.put_request);
                case stomt_feature.delete_a_single_comment: // Delete a single comment.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_EditDeleteCommentUriSuffix(cdt_parameters.s_stomt_id, cdt_parameters.s_comment_id), null, http_method.delete_request);
                case stomt_feature.vote_on_a_comment: // Vote on a comment.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_positive_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_positive)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_VoteUriSuffix(cdt_parameters.s_stomt_id, cdt_parameters.s_comment_id), fuec_parameters, http_method.post_request);
                case stomt_feature.revoke_a_vote: // Revoke a vote.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_VoteUriSuffix(cdt_parameters.s_stomt_id, cdt_parameters.s_comment_id), null, http_method.delete_request);
                case stomt_feature.label_a_stomt: // Label a stomt.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_name_parameter, cdt_parameters.s_name),
                        new KeyValuePair<string, string>(stomt_parameters.cs_color_parameter, cdt_parameters.s_color),
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_public_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_public)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_target_owner_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_as_target_owner)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_LabelAStomtUriSuffix(cdt_parameters.s_stomt_id), fuec_parameters, http_method.post_request);
                case stomt_feature.unlabel_a_stomt: // Unlabel a stomt.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_UnlabelAStomtUriSuffix(cdt_parameters.s_stomt_id, cdt_parameters.s_label, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_as_target_owner)), null, http_method.delete_request);
                case stomt_feature.label_a_list_of_stomts: // Label a list of stomts.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_stomts_array_parameter, ConversionClass.uf_s_StringArrayToString(cdt_parameters.sa_stomts)), // array.
                        new KeyValuePair<string, string>(stomt_parameters.cs_color_parameter, cdt_parameters.s_color),
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_public_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_public)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_target_owner_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_as_target_owner)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_ListOfStomtsUriSuffix(cdt_parameters.s_label_name), fuec_parameters, http_method.post_request);
                case stomt_feature.remove_label_from_list_of_stomts: // Remove label from list of stomts.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_target_owner_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_as_target_owner)) // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_RemoveLabelFromListOfStomtsUriSuffix(cdt_parameters.s_label_name, cdt_parameters.sa_stomts), fuec_parameters, http_method.delete_request);
                case stomt_feature.get_a_specific_feed: // Get a specific feed.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_GetASpecificFeedUriSuffix(cdt_parameters.s_type, cdt_parameters.s_newer_than), null, http_method.get_request);
                case stomt_feature.create_a_target: // Create a target.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_display_name_parameter, cdt_parameters.s_display_name),
                        new KeyValuePair<string, string>(stomt_parameters.cs_category_id_parameter, cdt_parameters.s_category_id),
                        new KeyValuePair<string, string>(stomt_parameters.cs_user_name_parameter, cdt_parameters.s_username),
                        new KeyValuePair<string, string>(stomt_parameters.cs_image_parameter, cdt_parameters.s_image),
                        new KeyValuePair<string, string>(stomt_parameters.cs_parent_id_parameter, cdt_parameters.s_parent_id),
                        new KeyValuePair<string, string>(stomt_parameters.cs_as_target_owner_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_as_target_owner)), // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/targets", fuec_parameters, http_method.post_request);
                case stomt_feature.preflight_request: // Preflight request.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_source_parameter, cdt_parameters.s_source),
                        new KeyValuePair<string, string>(stomt_parameters.cs_source_id_parameter, cdt_parameters.s_source_id),
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/targets/preflight", fuec_parameters, http_method.post_request);
                case stomt_feature.get_a_target: // Get a target.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_GetUpdateTargetUriSuffix(cdt_parameters.s_target_id), null, http_method.get_request);
                case stomt_feature.update_a_target: // Update a target.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_display_name_parameter, cdt_parameters.s_display_name),
                        new KeyValuePair<string, string>(stomt_parameters.cs_password_parameter, cdt_parameters.s_password),
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_GetUpdateTargetUriSuffix(cdt_parameters.s_target_id), fuec_parameters, http_method.put_request);
                case stomt_feature.get_target_stomts: // Get target stomts.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_GetTargetStomtsUriSuffix(cdt_parameters.s_target_id, cdt_parameters.s_show_type, cdt_parameters.s_second_type, cdt_parameters.s_newer_than), null, http_method.get_request);
                case stomt_feature.get_application: // Get application.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_TargetApplicationUriSuffix(cdt_parameters.s_target_id), null, http_method.get_request);
                case stomt_feature.create_application: // Create application.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_application_type_parameter, cdt_parameters.s_application_type),
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_TargetApplicationUriSuffix(cdt_parameters.s_target_id), fuec_parameters, http_method.post_request);
                case stomt_feature.delete_application: // Delete application.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_DeleteApplicationUriSuffix(cdt_parameters.s_target_id, cdt_parameters.s_application_id), null, http_method.delete_request);
                case stomt_feature.get_followers: // Get followers.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_TargetFollowingUriSuffix(cdt_parameters.s_target_id), null, http_method.get_request);
                case stomt_feature.follow_a_target: // Follow a target.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[] { }); // Empty.

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_TargetFollowingUriSuffix(cdt_parameters.s_target_id), fuec_parameters, http_method.post_request);
                case stomt_feature.unfollow_a_target: // Unfollow a target.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_TargetFollowingUriSuffix(cdt_parameters.s_target_id), null, http_method.delete_request);
                case stomt_feature.get_follows: // Get follows.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_GetFollowsUriSuffix(cdt_parameters.s_target_id), null, http_method.get_request);
                case stomt_feature.get_invitations: // Get invitations.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_InvitationUriSuffix(cdt_parameters.s_target_id), null, http_method.get_request);
                case stomt_feature.create_invitation: // Create invitation.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_invite_as_owner_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_invite_as_owner)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_role_id_parameter, cdt_parameters.i_role_id.ToString()) // integer.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_InvitationUriSuffix(cdt_parameters.s_target_id), fuec_parameters, http_method.post_request);
                case stomt_feature.check_for_validity: // Check for validity.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_CheckForValidityUriSuffix(cdt_parameters.s_target_id, cdt_parameters.s_code), null, http_method.get_request);
                case stomt_feature.search_target_users: // Search target users.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/targets/users" +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_q, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_q_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_has, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_has_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_is, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_is_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_groups, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_groups_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_PositiveIntegerWithPrefix(cdt_parameters.i_offset, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_offset_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_PositiveIntegerWithPrefix(cdt_parameters.i_limit, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_limit_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_order_by, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_order_by_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.get_all_categories: // Get all categories.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/categories", null, http_method.get_request);
                case stomt_feature.get_notifications: // Get notifications.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/notifications" +
                        ConversionClass.uf_s_ValidBooleanWithPrefix(cdt_parameters.b_unseen, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_unseen_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_last_notification, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_last_notification_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_PositiveIntegerWithPrefix(cdt_parameters.i_offset, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_offset_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_PositiveIntegerWithPrefix(cdt_parameters.i_limit, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_limit_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.update_notifications: // Update notifications.
                    // Set json's content parameters.
                    fuec_parameters = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_id_parameter, cdt_parameters.s_id),
                        new KeyValuePair<string, string>(stomt_parameters.cs_seen_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_seen)), // boolean.
                        new KeyValuePair<string, string>(stomt_parameters.cs_clicked_parameter, ConversionClass.uf_s_BooleanToString(cdt_parameters.b_clicked)), // boolean.
                    });

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/notifications", fuec_parameters, http_method.put_request);
                case stomt_feature.upload_image: // Upload image.
                    // Set json's content parameters.
                    List<KeyValuePair<string, string>> kvpssl_images_container = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>(stomt_parameters.cs_id_parameter, cdt_parameters.s_id)
                    };

                    // Add to parameters the following nested arrays.
                    kvpssl_images_container = JsonClass.uf_kvpssl_NestedArrayParametersToList(kvpssl_images_container, stomt_parameters.cs_images_parameter,
                        new string[] { cdt_parameters.s_context_parameter, null, stomt_parameters.cs_image_data_array_parameter }, cdt_parameters.sa_image_data);
                    kvpssl_images_container = JsonClass.uf_kvpssl_NestedArrayParametersToList(kvpssl_images_container, stomt_parameters.cs_images_parameter,
                        new string[] { cdt_parameters.s_context_parameter, null, stomt_parameters.cs_image_url_array_parameter }, cdt_parameters.sa_image_url);

                    // Convert the key value pair container to json's content parameters storage.
                    fuec_parameters = new FormUrlEncodedContent(kvpssl_images_container);

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/images", fuec_parameters, http_method.post_request);
                case stomt_feature.upload_file: // Upload file.
                    List<KeyValuePair<string, string>> kvpssl_files_container = new List<KeyValuePair<string, string>>();

                    // Add to parameters the following nested array.
                    kvpssl_files_container = JsonClass.uf_kvpssl_NestedArrayParametersToList(kvpssl_files_container, stomt_parameters.cs_files_parameter,
                        new string[] { cdt_parameters.s_context_parameter, null, stomt_parameters.cs_file_data_array_parameter }, cdt_parameters.sa_file_data);

                    // Add to parameters the following dynamic nested array.
                    if (DataClass.uf_b_ValidArray(cdt_parameters.sa_filename) == true)
                    {
                        for (int i = 0; i < cdt_parameters.sa_file_data.Length; i++)
                        {
                            if (cdt_parameters.sa_filename.Length < cdt_parameters.sa_file_data.Length)
                            {
                                kvpssl_files_container.Add(new KeyValuePair<string, string>(stomt_parameters.cs_files_parameter +
                                    JsonClass.uf_s_NestedArrayParameter(new string[] { cdt_parameters.s_context_parameter, i.ToString(), stomt_parameters.cs_file_data_array_parameter }),
                                        cdt_parameters.sa_filename[i]));
                            }
                        }
                    }

                    // Convert the key value pair container to json's content parameters storage.
                    fuec_parameters = new FormUrlEncodedContent(kvpssl_files_container);

                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/files", fuec_parameters, http_method.post_request);
                case stomt_feature.search_target: // Search target.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_SearchTargetUriSuffix(cdt_parameters.s_q), null, http_method.get_request);
                case stomt_feature.search_stomts: // Search stomts.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/search/stomts" +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_q, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_q_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_at, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_at_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_to, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_limit_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_from, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_from_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_has, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_has_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_is, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_is_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_label, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_label_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_hashtag, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_hashtag_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_lang, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_lang_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_newer_than, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_newer_than_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_older_than, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_older_than_parameter + Constant.publ_cs_parameter_suffix) +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_order_by, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_order_by_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.search_hashtags: // Search hashtags.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request("/search/hashtags" +
                        ConversionClass.uf_s_NonNullableStringWithPrefix(cdt_parameters.s_q, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_q_parameter + Constant.publ_cs_parameter_suffix),
                        null, http_method.get_request);
                case stomt_feature.retrieve_exported_stomts: // Retrieve exported stomts.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_RetrieveExportedUStomtsUriSuffix(cdt_parameters.s_access_token, cdt_parameters.s_file_type, cdt_parameters.s_stomts), null, http_method.get_request);
                case stomt_feature.retrieve_exported_users: // Retrieve exported users.
                    // Return the request information for the stomt api interaction.
                    return new stomt_api_request(uf_s_RetrieveExportedUsersUriSuffix(cdt_parameters.s_access_token, cdt_parameters.s_file_type, cdt_parameters.s_users, cdt_parameters.s_target), null, http_method.get_request);
                default:
                    // Return the default empty request information for the stomt api interaction.
                    return new stomt_api_request("", null, http_method.post_request);
            }
        }

        /// <summary>
        /// Creates the uri suffix for suggest username method.
        /// </summary>
        /// <param name="s_display_name">The display name to check.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_SuggestUsernamesUriSuffix(string s_display_name)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_display_name) == false) ?
                "/authentication/suggestedUsernames" + Constant.publ_cs_parameter_prefix + stomt_parameters.cs_display_name_parameter + Constant.publ_cs_parameter_suffix + s_display_name :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for read stomt and delete stomt.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_ReadDeleteStomtsUriSuffix(string s_stomt_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_stomt_id) == false) ?
                "/stomts/" + s_stomt_id :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for create stomt agreement, delete stomt agreement and get stomt voters.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_StomtAgreementAndVotersUriSuffix(string s_stomt_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_stomt_id) == false) ?
                "/stomts/" + s_stomt_id + "/agreements" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for create a comment and read stomt comments.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_CreateReadCommentUriSuffix(string s_stomt_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_stomt_id) == false) ?
                "/stomts/" + s_stomt_id + "/comments" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for edit a comment and delete a single comment.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The comment's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_EditDeleteCommentUriSuffix(string s_stomt_id, string s_comment_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_stomt_id) == false) && (string.IsNullOrWhiteSpace(s_comment_id) == false)) ?
                "/stomts/" + s_stomt_id + "/comments/" + s_comment_id :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for vote on a comment and revoke a vote.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The comment's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_VoteUriSuffix(string s_stomt_id, string s_comment_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_stomt_id) == false) && (string.IsNullOrWhiteSpace(s_comment_id) == false)) ?
                "/stomts/" + s_stomt_id + "/comments/" + s_comment_id + "/votes" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for label a stomt.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_LabelAStomtUriSuffix(string s_stomt_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_stomt_id) == false) ?
                "/stomts/" + s_stomt_id + "/labels" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for unlabel a stomt.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_label">The label to be removed.</param>
        /// <param name="b_as_target_owner">The label removal as private or target-label.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_UnlabelAStomtUriSuffix(string s_stomt_id, string s_label_name, string s_as_target_owner)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_stomt_id) == false) && (string.IsNullOrWhiteSpace(s_label_name) == false)) ?
                "/stomts/" + s_stomt_id + "/labels/" + s_label_name + 
                    ConversionClass.uf_s_NonNullableStringWithPrefix(s_as_target_owner, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_as_target_owner_parameter + Constant.publ_cs_parameter_suffix) :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for label a list of stomts.
        /// </summary>
        /// <param name="s_label_name">The label's name.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_ListOfStomtsUriSuffix(string s_label_name)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_label_name) == false) ? "/stomts/labels/" + s_label_name : "";
        }

        /// <summary>
        /// Creates the uri suffix for remove label from list of stomts.
        /// </summary>
        /// <param name="s_label_name">The label to be removed.</param>
        /// <param name="sa_stomts">The list of stomt slugs.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_RemoveLabelFromListOfStomtsUriSuffix(string s_label_name, string[] sa_stomts)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_label_name) == false) ?
                "/stomts/labels/" + s_label_name + 
                    ConversionClass.uf_s_NonNullableStringWithPrefix(ConversionClass.uf_s_StringArrayToString(sa_stomts), Constant.publ_cs_parameter_prefix + stomt_parameters.cs_stomts_array_parameter + Constant.publ_cs_parameter_suffix) : "";
        }

        /// <summary>
        /// Creates the uri suffix for get a specific feed.
        /// </summary>
        /// <param name="s_type">The received feed in form of a stomt-collection.</param>
        /// <param name="s_newer_than">The stomts newer than the unix-timestamp. Only these will be returned.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_GetASpecificFeedUriSuffix(string s_type, string s_newer_than)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_type) == false) ?
                "/feeds/" + s_type + ConversionClass.uf_s_NonNullableStringWithPrefix(s_newer_than, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_newer_than_parameter + Constant.publ_cs_parameter_suffix) :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for get a target and update a target.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_GetUpdateTargetUriSuffix(string s_target_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                "/targets/" + s_target_id :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for get target stomts.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="s_show_type">The results' type to show (received or created stomts).</param>
        /// <param name="s_second_type">The feedback type (all or only positive/negative).</param>
        /// <param name="s_newer_than">The stomts newer than the unix-timestamp. Only these will be returned.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_GetTargetStomtsUriSuffix(string s_target_id, string s_show_type, string s_second_type, string s_newer_than)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                 "/targets/" + s_target_id + "/stomts/" + ConversionClass.uf_s_NonNullableStringWithSuffix(s_show_type, "/") +
                 ConversionClass.uf_s_NonNullableStringWithSuffix(s_second_type, "") +
                 ConversionClass.uf_s_NonNullableStringWithPrefix(s_newer_than, Constant.publ_cs_parameter_prefix + stomt_parameters.cs_newer_than_parameter + Constant.publ_cs_parameter_suffix) :
                 "";
        }

        /// <summary>
        /// Creates the uri suffix for get application and create application.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_TargetApplicationUriSuffix(string s_target_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                "/targets/" + s_target_id + "/applications" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for delete application.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target the application belongs to.</param>
        /// <param name="s_application_id">The unique id of the application.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_DeleteApplicationUriSuffix(string s_target_id, string s_application_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_target_id) == false) && (string.IsNullOrWhiteSpace(s_application_id) == false)) ?
                "/targets/" + s_target_id + "/applications/" + s_application_id :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for get followers, follow a target and unfollow a target.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_TargetFollowingUriSuffix(string s_target_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                "/targets/" + s_target_id + "/followers" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for get follows
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_GetFollowsUriSuffix(string s_target_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                "/targets/" + s_target_id + "/follows" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for get invitations and create invitation.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_InvitationUriSuffix(string s_target_id)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_target_id) == false) ?
                "/targets/" + s_target_id + "/invitations" :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for check for validity.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="s_code">The code of the invitation.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_CheckForValidityUriSuffix(string s_target_id, string s_code)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_target_id) == false) && (string.IsNullOrWhiteSpace(s_code) == false)) ?
                "/targets/" + s_target_id + "/invitations/" + s_code :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for search target.
        /// </summary>
        /// <param name="s_q">The term to search for.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_SearchTargetUriSuffix(string s_q)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return (string.IsNullOrWhiteSpace(s_q) == false) ?
                "/search" + Constant.publ_cs_parameter_prefix + stomt_parameters.cs_q_parameter + Constant.publ_cs_parameter_suffix + s_q :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for retrieve exported stomts.
        /// </summary>
        /// <param name="s_access_token">The access token of the current user session.</param>
        /// <param name="s_file_type">The requested file format (csv, xls, xlsx, etc)</param>
        /// <param name="s_stomts">The comma separated list of stomt slugs</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_RetrieveExportedUStomtsUriSuffix(string s_access_token, string s_file_type, string s_stomts)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form.
            return ((string.IsNullOrWhiteSpace(s_access_token) == false) && (string.IsNullOrWhiteSpace(s_file_type) == false) && (string.IsNullOrWhiteSpace(s_stomts) == false)) ?
                "/exports/stomts" + Constant.publ_cs_parameter_prefix + stomt_parameters.cs_access_token_parameter + Constant.publ_cs_parameter_suffix + s_access_token +
                    Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_file_type_parameter + Constant.publ_cs_parameter_suffix + s_file_type +
                    Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_stomts_parameter + Constant.publ_cs_parameter_suffix + s_stomts :
                "";
        }

        /// <summary>
        /// Creates the uri suffix for retrieve exported users.
        /// </summary>
        /// <param name="s_access_token">The access token of the current user session.</param>
        /// <param name="s_file_type">The requested file format (csv, xls, xlsx, etc)</param>
        /// <param name="s_users">The comma separated list of user ids.</param>
        /// <param name="s_target">The id of the target the user data should be calculated from.</param>
        /// <returns>The uri suffix for usage in http method.</returns>
        private static string uf_s_RetrieveExportedUsersUriSuffix(string s_access_token, string s_file_type, string s_users, string s_target)
        {
            // Constructs the uri suffix by validating parameters and building the uri's valid form. 
            return ((string.IsNullOrWhiteSpace(s_access_token) == false) && (string.IsNullOrWhiteSpace(s_file_type) == false) && (string.IsNullOrWhiteSpace(s_users) == false) && (string.IsNullOrWhiteSpace(s_target) == false)) ?
                "/exports/users" + Constant.publ_cs_parameter_prefix + stomt_parameters.cs_access_token_parameter + Constant.publ_cs_parameter_suffix + s_access_token +
                    Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_file_type_parameter + Constant.publ_cs_parameter_suffix + s_file_type +
                    Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_users_parameter + Constant.publ_cs_parameter_suffix + s_users +
                    Constant.publ_cs_required_parameter_prefix + stomt_parameters.cs_target_parameter + Constant.publ_cs_parameter_suffix + s_target :
                "";
        }
    }
}
