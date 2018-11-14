using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 15/10/2018.
/// </summary>

namespace Stomt
{
    //class CustomDataTypesClass
    //{
    //}

    /// <summary>
    /// The container of data information.
    /// </summary>
    public class information
    {
        public object o_data;
        public string s_message;

        /// <summary>
        /// Gets the information about returned data.
        /// </summary>
        /// <param name="o_data">The returned data.</param>
        /// <param name="s_message">The system's message (error, success or other).</param>
        public information(object o_data, string s_message)
        {
            this.o_data = o_data;
            this.s_message = s_message;
        }
    }

    /// <summary>
    /// The container of stomt api request settings.
    /// </summary>
    public class stomt_api_request
    {
        public string s_uri_suffix;
        public HttpContent httpcn_content;
        public http_method cen_method_request;

        /// <summary>
        /// Stores the stomt api request settings.
        /// </summary>
        /// <param name="s_uri_suffix">The uri suffix that follows the stomt api's method request. (browser inline parameters).</param>
        /// <param name="httpcn_content">The http content that stores the json data (json formed parameters).</param>
        /// <param name="cen_method_request">The requested http method (post/get/put/delete)</param>
        public stomt_api_request(string s_uri_suffix, HttpContent httpcn_content, http_method cen_method_request)
        {
            this.s_uri_suffix = s_uri_suffix;
            this.httpcn_content = httpcn_content;
            this.cen_method_request = cen_method_request;
        }
    }

    /// <summary>
    /// The container of stomt parameters.
    /// </summary>
    public class stomt_parameters
    {
        // The variable and the constant for username parameter.
        public const string cs_user_name_parameter = "username";
        public string s_username;

        // The variable and the constant for email parameter.
        public const string cs_email_parameter = "email";
        public string s_email;

        // The variable and the constant for password parameter.
        public const string cs_password_parameter = "password";
        public string s_password;

        // The variable and the constant for display name parameter.
        public const string cs_display_name_parameter = "displayname";
        public string s_display_name;

        // The variable and the constant for message parameter.
        public const string cs_message_parameter = "message";
        public string s_message;

        // The variable and the constant for login method parameter.
        public const string cs_login_method_parameter = "login_method";
        public string s_login_method;

        // The variable and the constant for email/username combo parameter.
        public const string cs_email_username_parameter = "emailusername";
        public string s_email_username;

        // The variable and the constant for name parameter.
        public const string cs_name_parameter = "name";
        public string s_name;

        // The variable and the constant for color parameter.
        public const string cs_color_parameter = "color";
        public string s_color;

        // The variable and the constant for application type parameter.
        public const string cs_application_type_parameter = "type";
        public string s_application_type;

        // The variable and the constant for source parameter.
        public const string cs_source_parameter = "src";
        public string s_source;

        // The variable and the constant for source id parameter.
        public const string cs_source_id_parameter = "src_id";
        public string s_source_id;

        // The variable and the constant for code parameter.
        public const string cs_authorisation_code_parameter = "code";
        public string s_authorisation_code;

        // The variable and the constant for state parameter.
        public const string cs_state_parameter = "state";
        public string s_state;

        // The variable and the constant for oauth token parameter.
        public const string cs_oauth_token_parameter = "oauth_token";
        public string s_oauth_token;

        // The variable and the constant for oauth verifier parameter.
        public const string cs_oauth_verifier_parameter = "oauth_verifier";
        public string s_oauth_verifier;

        // The variable and the constant for client id parameter.
        public const string cs_client_id_parameter = "client_id";
        public string s_client_id;

        // The variable and the constant for redirect uri parameter.
        public const string cs_redirect_uri_parameter = "redirect_uri";
        public string s_redirect_uri;

        // The variable and the constant for property parameter.
        public const string cs_property_parameter = "property";
        public string s_property;

        // The variable and the constant for value parameter.
        public const string cs_value_parameter = "value";
        public string s_value;

        // The variable and the constant for verification code parameter.
        public const string cs_verification_code_parameter = "verification_code";
        public string s_verification_code;

        // The variable and the constant for username or email parameter.
        public const string cs_username_or_email_parameter = "usernameoremail";
        public string s_username_or_email;

        // The variable and the constant for resetcode parameter.
        public const string cs_reset_code_parameter = "resetcode";
        public string s_reset_code;

        // The variable and the constant for new passwored parameter.
        public const string cs_new_password_parameter = "newpassword";
        public string s_new_password;

        // The variable and the constant for text parameter.
        public const string cs_text_parameter = "text";
        public string s_text;

        // The variable and the constant for target id parameter.
        public const string cs_target_id_parameter = "target_id";
        public string s_target_id;

        // The variable and the constant for url parameter.
        public const string cs_url_parameter = "url";
        public string s_url;

        // The variable and the constant for image name parameter.
        public const string cs_img_name_parameter = "img_name";
        public string s_img_name;

        // The variable and the constant for file uid parameter.
        public const string cs_file_uid_parameter = "file_uid";
        public string s_file_uid;

        // The variable and the constant for lon and lat parameter.
        public const string cs_lonlat_parameter = "lonlat";
        public string s_lonlat;

        // The variable and the constant for newer than parameter.
        public const string cs_newer_than_parameter = "newer_than";
        public string s_newer_than;

        // The variable and the constant for show type parameter.
        public const string cs_show_type_parameter = "type";
        public string s_show_type;

        // The variable and the constant for second type parameter.
        public const string cs_second_type_parameter = "secondType";
        public string s_second_type;

        // The variable and the constant for q parameter.
        public const string cs_q_parameter = "q";
        public string s_q;

        // The variable and the constant for has parameter.
        public const string cs_has_parameter = "has";
        public string s_has;

        // The variable and the constant for is parameter.
        public const string cs_is_parameter = "is";
        public string s_is;

        // The variable and the constant for groups parameter.
        public const string cs_groups_parameter = "groups";
        public string s_groups;

        // The variable and the constant for order by parameter.
        public const string cs_order_by_parameter = "orderBy";
        public string s_order_by;

        // The variable and the constant for last notification parameter.
        public const string cs_last_notification_parameter = "last_notification";
        public string s_last_notification;

        // The variable and the constant for at parameter.
        public const string cs_at_parameter = "at";
        public string s_at;

        // The variable and the constant for to parameter.
        public const string cs_to_parameter = "to";
        public string s_to;

        // The variable and the constant for from parameter.
        public const string cs_from_parameter = "from";
        public string s_from;

        // The variable and the constant for label parameter.
        public const string cs_label_parameter = "label";
        public string s_label;

        // The variable and the constant for hashtag parameter.
        public const string cs_hashtag_parameter = "hashtag";
        public string s_hashtag;

        // The variable and the constant for lang parameter.
        public const string cs_lang_parameter = "lang";
        public string s_lang;

        // The variable and the constant for older than parameter.
        public const string cs_older_than_parameter = "older_than";
        public string s_older_than;

        // The variable and the constant for access token parameter.
        public const string cs_access_token_parameter = "accesstoken";
        public string s_access_token;

        // The variable and the constant for file type parameter.
        public const string cs_file_type_parameter = "type";
        public string s_file_type;

        // The variable and the constant for stomts parameter.
        public const string cs_stomts_parameter = "stomts";
        public string s_stomts;

        // The variable and the constant for users parameter.
        public const string cs_users_parameter = "users";
        public string s_users;

        // The variable and the constant for as target parameter.
        public const string cs_as_target_parameter = "as_target";
        public string s_as_target;

        // The variable and the constant for target parameter.
        public const string cs_target_parameter = "target";
        public string s_target;

        // The variable and the constant for category id parameter.
        public const string cs_category_id_parameter = "category_id";
        public string s_category_id;

        // The variable and the constant for image parameter.
        public const string cs_image_parameter = "image";
        public string s_image;

        // The variable and the constant for parent id parameter.
        public const string cs_parent_id_parameter = "parent_id";
        public string s_parent_id;

        // The variable and the constant for id parameter.
        public const string cs_id_parameter = "id";
        public string s_id;

        // The constant for files parameter.
        public const string cs_files_parameter = "files";

        // The constant for stomt parameter.
        public const string cs_stomt_parameter = "stomt";

        // The constant for extra data parameter.
        public const string cs_extradata_parameter = "extradata";

        // The constant for images parameter.
        public const string cs_images_parameter = "images";

        // The variable and the constant for labels array parameter.
        public const string cs_labels_array_parameter = "labels";
        public string[] sa_labels;

        // The variable and the constant for stomts array parameter.
        public const string cs_stomts_array_parameter = "stomts";
        public string[] sa_stomts;

        // The variable and the constant for data array parameter.
        public const string cs_image_data_array_parameter = "data";
        public string[] sa_image_data;

        // The variable and the constant for image url array parameter.
        public const string cs_image_url_array_parameter = "url";
        public string[] sa_image_url;

        // The variable and the constant for file data array parameter.
        public const string cs_file_data_array_parameter = "data";
        public string[] sa_file_data;

        // The variable and the constant for filename array parameter.
        public const string cs_filename_array_parameter = "filename";
        public string[] sa_filename;

        // The variable and the constant for json parameter.
        public const string cs_json_parameter = "json";
        public object o_json;

        // The variable and the constant for offset parameter.
        public const string cs_offset_parameter = "offset";
        public int i_offset;

        // The variable and the constant for limit parameter.
        public const string cs_limit_parameter = "limit";
        public int i_limit;

        // The variable and the constant for role id parameter.
        public const string cs_role_id_parameter = "role_id";
        public int i_role_id;

        // The variable and the constant for merge parameter.
        public const string cs_merge_parameter = "merge";
        public bool b_merge;

        // The variable and the constant for positive parameter.
        public const string cs_positive_parameter = "positive";
        public bool b_positive;

        // The variable and the constant for anonym parameter.
        public const string cs_anonym_parameter = "anonym";
        public bool b_anonym;

        // The variable and the constant for public parameter.
        public const string cs_as_public_parameter = "public";
        public bool b_public;

        // The variable and the constant for as target owner parameter.
        public const string cs_as_target_owner_parameter = "as_target_owner";
        public bool b_as_target_owner;

        // The variable and the constant for invite as owner parameter.
        public const string cs_invite_as_owner_parameter = "invite_as_owner";
        public bool b_invite_as_owner;

        // The variable and the constant for reaction parameter.
        public const string cs_reaction_parameter = "reaction";
        public bool b_reaction;

        // The variable and the constant for unseen parameter.
        public const string cs_unseen_parameter = "unseen";
        public bool b_unseen;

        // The variable and the constant for seen parameter.
        public const string cs_seen_parameter = "seen";
        public bool b_seen;

        // The variable and the constant for clicked parameter.
        public const string cs_clicked_parameter = "clicked";
        public bool b_clicked;

        // The variable for context parameter.
        public string s_context_parameter = "stomt";

        // The variable for stomt id parameter.
        public string s_stomt_id;

        // The variable for comment id parameter.
        public string s_comment_id;

        // The variable for label id parameter.
        public string s_label_name;

        // The variable for application id parameter.
        public string s_application_id;

        // The variable for type parameter.
        public string s_type;

        // The variable for code parameter.
        public string s_code;

        /// <summary>
        /// The stomt parameters for register an user method.
        /// </summary>
        /// <param name="s_username">The user's username.</param>
        /// <param name="s_email">The user's email.</param>
        /// <param name="s_password">The user's password.</param>
        /// <param name="s_display_name">The user's display name.</param>
        /// <param name="s_message">The system's message.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRegisterAnUserParameters(string s_username, string s_email, string s_password, string s_display_name, string s_message)
        {
            this.s_username = s_username;
            this.s_email = s_email;
            this.s_password = s_password;
            this.s_display_name = s_display_name;
            this.s_message = s_message;

            return this;
        }

        /// <summary>
        /// The stomt parameters for normal login method.
        /// </summary>
        /// <param name="s_email_username">The user's email or username.</param>
        /// <param name="s_password">The user's password.</param>
        /// <param name="b_merge">Transfers anonym action to signed in account.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetNormalLoginParameters(string s_email_username, string s_password, bool b_merge = false)
        {
            this.s_login_method = "normal";
            this.s_email_username = s_email_username;
            this.s_password = s_password;
            this.b_merge = b_merge;

            return this;
        }

        /// <summary>
        /// The stomt parameters for facebook login method.
        /// </summary>
        /// <param name="s_authorisation_code">The facebook's authorisation code.</param>
        /// <param name="s_state">The facebook's state.</param>
        /// <param name="s_access_token">The facebook's access token.</param>
        /// <param name="b_merge">Transfers anonym action to signed in account.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetFacebookLoginParameters(string s_authorisation_code = null, string s_state = null, string s_access_token = null, bool b_merge = false)
        {
            this.s_login_method = "facebook";
            this.s_authorisation_code = s_authorisation_code;
            this.s_state = s_state;
            this.s_access_token = s_access_token;
            this.b_merge = b_merge;

            return this;
        }

        /// <summary>
        /// The stomt parameters for reddit login method.
        /// </summary>
        /// <param name="s_authorisation_code">The reddit's authorisation code.</param>
        /// <param name="s_state">The facebook's state.</param>
        /// <param name="b_merge">Transfers anonym action to signed in account.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRedditLoginParameters(string s_authorisation_code, string s_state, bool b_merge = false)
        {
            this.s_login_method = "reddit";
            this.s_authorisation_code = s_authorisation_code;
            this.s_state = s_state;
            this.b_merge = b_merge;

            return this;
        }

        /// <summary>
        /// The stomt parameters for twitter login method.
        /// </summary>
        /// <param name="s_oauth_token">The twitter's oauth token.</param>
        /// <param name="s_oauth_verifier">The twitter's oauth verifier.</param>
        /// <param name="b_merge">Transfers anonym action to signed in account.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetTwitterLoginParameters(string s_oauth_token, string s_oauth_verifier, bool b_merge = false)
        {
            this.s_login_method = "twitter";
            this.s_oauth_token = s_oauth_token;
            this.s_oauth_verifier = s_oauth_verifier;
            this.b_merge = b_merge;

            return this;
        }

        /// <summary>
        /// The stomt parameters for logout method.
        /// </summary>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetLogoutParameters()
        {
            return this;
        }

        /// <summary>
        /// The stomt parameters for oauth login method.
        /// </summary>
        /// <param name="s_client_id">The application's id.</param>
        /// <param name="s_redirect_uri">The redirect uri.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetoAuthLoginParameters(string s_client_id, string s_redirect_uri)
        {
            this.s_client_id = s_client_id;
            this.s_redirect_uri = s_redirect_uri;

            return this;
        }

        /// <summary>
        /// The stomt parameters for check availability method.
        /// </summary>
        /// <param name="s_property">The property to check (username / email / displayname).</param>
        /// <param name="s_value">The value to check.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCheckAvailabilityParameters(string s_property, string s_value)
        {
            this.s_property = s_property;
            this.s_value = s_value;

            return this;
        }

        /// <summary>
        /// The stomt parameters for suggest username method.
        /// </summary>
        /// <param name="s_display_name">The display name to check.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetSuggestUsernamesParameters(string s_display_name)
        {
            this.s_display_name = s_display_name;

            return this;
        }

        /// <summary>
        /// The stomt parameters for verify email method.
        /// </summary>
        /// <param name="s_verification_code">The email's verification code.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetVerifyEmailParameters(string s_verification_code)
        {
            this.s_verification_code = s_verification_code;

            return this;
        }

        /// <summary>
        /// The stomt parameters for forgot password method.
        /// </summary>
        /// <param name="s_username_or_email">The forgotten username or email.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetForgotPasswordParameters(string s_username_or_email)
        {
            this.s_username_or_email = s_username_or_email;

            return this;
        }

        /// <summary>
        /// The stomt parameters for reset password method.
        /// </summary>
        /// <param name="s_reset_code">The reset code.</param>
        /// <param name="s_new_password">The new password.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetResetPasswordParameters(string s_reset_code, string s_new_password)
        {
            this.s_reset_code = s_reset_code;
            this.s_new_password = s_new_password;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create a stomt method.
        /// </summary>
        /// <param name="s_text">The stomt's text.</param>
        /// <param name="s_target_id">if not specified page of the appid will be used</param>
        /// <param name="b_positive">The user selects between “I wish” (positive=false) and “I like” (positive=true) (default: false).</param>
        /// <param name="s_lang">The stomt's language (en, de, gr, etc).</param>
        /// <param name="s_url">The attached url.</param>
        /// <param name="b_anonym">The user creates a stomt as anoymous.</param>
        /// <param name="s_img_name">The image's name.</param>
        /// <param name="s_file_uid">The file's unique id.</param>
        /// <param name="s_lonlat">The lon & lat of stomt.</param>
        /// <param name="sa_labels">The label names that will be attached to the stomt.</param>
        /// <param name="o_json">Any extra json data.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreatesAStomtParameters(string s_text, string s_target_id = null, bool b_positive = false, string s_lang = null, string s_url = null, bool b_anonym = true, string s_img_name = null,
            string s_file_uid = null, string s_lonlat = null, string[] sa_labels = null, object o_json = null)
        {
            this.s_text = s_text;
            this.s_target_id = s_target_id;
            this.b_positive = b_positive;
            this.s_lang = s_lang;
            this.s_url = s_url;
            this.b_anonym = b_anonym;
            this.s_img_name = s_img_name;
            this.s_file_uid = s_file_uid;
            this.s_lonlat = s_lonlat;
            this.sa_labels = sa_labels;
            this.o_json = o_json;

            return this;
        }

        /// <summary>
        /// The stomt parameters for read a stomt method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetReadAStomtParameters(string s_stomt_id)
        {
            this.s_stomt_id = s_stomt_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for delete a stomt method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetDeleteAStomtParameters(string s_stomt_id)
        {
            this.s_stomt_id = s_stomt_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create agreement method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="b_positive">The agreement on stomt (true = disagreement, false = agreement).</param>
        /// <param name="b_anonym">The user's hidden status from other (default: false)</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreateStomtAgreementParameters(string s_stomt_id, bool b_positive, bool b_anonym)
        {
            this.s_stomt_id = s_stomt_id;
            this.b_positive = b_positive;
            this.b_anonym = b_anonym;

            return this;
        }

        /// <summary>
        /// The stomt parameters for delete stomt agreement method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetDeleteStomtAgreementParameters(string s_stomt_id)
        {
            this.s_stomt_id = s_stomt_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get stomt voters method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetStomtVotersParameters(string s_stomt_id)
        {
            this.s_stomt_id = s_stomt_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create a comment method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_text">The comment's text.</param>
        /// <param name="s_as_target">The premium accounts can comment in the name of projects they own.</param>
        /// <param name="b_reaction">The top level comments by the target owner can be marked as reaction.</param>
        /// <param name="s_parent_id">The hashid of the parent comment (It can be null).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreateACommentParameters(string s_stomt_id, string s_text, string s_as_target, bool b_reaction, string s_parent_id = null)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_parent_id = s_parent_id;
            this.s_text = s_text;
            this.s_as_target = s_as_target;
            this.b_reaction = b_reaction;

            return this;
        }

        /// <summary>
        /// The stomt parameters for read stomt comments method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetReadStomtCommentsParameters(string s_stomt_id)
        {
            this.s_stomt_id = s_stomt_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for edit a comment method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The hashid of a comment.</param>
        /// <param name="b_anonym">The user comments as anonymous.</param>
        /// <param name="s_text">The comment's text.</param>
        /// <param name="b_reaction">The top level comments by the target owner can be marked as reaction.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetEditACommentParameters(string s_stomt_id, string s_comment_id, bool b_anonym, string s_text, bool b_reaction)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_comment_id = s_comment_id;
            this.b_anonym = b_anonym;
            this.s_text = s_text;
            this.b_reaction = b_reaction;

            return this;
        }

        /// <summary>
        /// The stomt parameters for delete a single comment method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The comment's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetDeleteASingleCommentParameters(string s_stomt_id, string s_comment_id)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_comment_id = s_comment_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for vote on a comment method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The comment's id.</param>
        /// <param name="b_positive">The agreement on comment (true = disagreement, false = agreement).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetVoteOnACommentParameters(string s_stomt_id, string s_comment_id, bool b_positive)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_comment_id = s_comment_id;
            this.b_positive = b_positive;

            return this;
        }

        /// <summary>
        /// The stomt parameters for revoke a vote method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_comment_id">The comment's id.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRevokeAVoteParameters(string s_stomt_id, string s_comment_id)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_comment_id = s_comment_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for label a stomt method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_name">The label's name.</param>
        /// <param name="s_color">The label's color (default: #5EBEFF).</param>
        /// <param name="b_public">The label's access level (private/public, default: false).</param>
        /// <param name="b_as_target_owner">The label's owner (private/public, default: false).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetLabelAStomtParameters(string s_stomt_id, string s_name, string s_color = "#5EBEFF", bool b_public = false, bool b_as_target_owner = false)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_name = s_name;
            this.s_color = s_color;
            this.b_public = b_public;
            this.b_as_target_owner = b_as_target_owner;

            return this;
        }               

        /// <summary>
        /// The stomt parameters for unlabel a stomt method.
        /// </summary>
        /// <param name="s_stomt_id">The stomt's id.</param>
        /// <param name="s_label">The label to be removed.</param>
        /// <param name="b_as_target_owner">The label removal as private or target-label.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUnlabelAStomtParameters(string s_stomt_id, string s_label, bool b_as_target_owner = true)
        {
            this.s_stomt_id = s_stomt_id;
            this.s_label = s_label;
            this.b_as_target_owner = b_as_target_owner;

            return this;
        }

        /// <summary>
        /// The stomt parameters for label a list of stomts method.
        /// </summary>
        /// <param name="s_label_name">The label's name.</param>
        /// <param name="sa_stomts">The list of stomt slugs.</param>
        /// <param name="s_color">The label's color (default: #5EBEFF).</param>
        /// <param name="b_public">The label's access level (private/public, default: false).</param>
        /// <param name="b_as_target_owner">The label's owner (private/public, default: false).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetLabelAListOfStomtsParameters(string s_label_name, string[] sa_stomts, string s_color = "#5EBEFF", bool b_public = false, bool b_as_target_owner = false)
        {
            this.s_label_name = s_label_name;
            this.sa_stomts = sa_stomts;
            this.s_color = s_color;
            this.b_public = b_public;
            this.b_as_target_owner = b_as_target_owner;

            return this;
        }

        /// <summary>
        /// The stomt parameters for remove label from list of stomts method.
        /// </summary>
        /// <param name="s_label_name">The label to be removed.</param>
        /// <param name="sa_stomts">The list of stomt slugs.</param>
        /// <param name="b_as_target_owner">The label removal as private or target-label.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRemoveLabelFromListOfStomtsParameters(string s_label_name, string[] sa_stomts, bool b_as_target_owner = true)
        {
            this.s_label_name = s_label_name;
            this.sa_stomts = sa_stomts;
            this.b_as_target_owner = b_as_target_owner;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get a specific feed method.
        /// </summary>
        /// <param name="s_type">The received feed in form of a stomt-collection.</param>
        /// <param name="s_newer_than">The stomts newer than the unix-timestamp. Only these will be returned.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetASpecificFeedParameters(string s_type, string s_newer_than = null)
        {
            this.s_type = s_type;
            this.s_newer_than = s_newer_than;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create a target method.
        /// </summary>
        /// <param name="s_display_name">The target's display name.</param>
        /// <param name="s_category_id">The target's existing category id.</param>
        /// <param name="s_username">The target's username.</param>
        /// <param name="s_image">The name of an uploaded image.</param>
        /// <param name="s_parent_id">The id of an other target.</param>
        /// <param name="b_as_target_owner">The owmer of the page (adds your account as owner)/</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreateATargetParameters(string s_display_name, string s_category_id, string s_username = null, string s_image = null, string s_parent_id = null, bool b_as_target_owner = true)
        {
            this.s_display_name = s_display_name;
            this.s_category_id = s_category_id;
            this.s_username = s_username;
            this.s_image = s_image;
            this.s_parent_id = s_parent_id;
            this.b_as_target_owner = b_as_target_owner;

            return this;
        }

        /// <summary>
        /// The stomt parameters for preflight request method.
        /// </summary>
        /// <param name="s_source">The providers shorthandle (e.g. "tw")</param>
        /// <param name="s_source_id">The username at the providers platform: e.g. twitter.com/stomt -> "stomt".</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetPreflightRequestParameters(string s_source, string s_source_id)
        {
            this.s_source = s_source;
            this.s_source_id = s_source_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get a target method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetATargetParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get target stomts method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="s_show_type">The results' type to show (received or created stomts).</param>
        /// <param name="s_second_type">The feedback type (all or only positive/negative).</param>
        /// <param name="s_newer_than">The stomts newer than the unix-timestamp. Only these will be returned.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetTargetStomtsParameters(string s_target_id, string s_show_type = null, string s_second_type = null, string s_newer_than = null)
        {
            this.s_target_id = s_target_id;
            this.s_show_type = s_show_type;
            this.s_second_type = s_second_type;
            this.s_newer_than = s_newer_than;

            return this;
        }

        /// <summary>
        /// The stomt parameters for update a target method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="s_display_name">The target's display name.</param>
        /// <param name="s_password">The target's password (only for the own account).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUpdateATargetParameters(string s_target_id, string s_display_name, string s_password)
        {
            this.s_target_id = s_target_id;
            this.s_display_name = s_display_name;
            this.s_password = s_password;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get application method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetApplicationParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create application method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target the application should be created for.</param>
        /// <param name="s_application_type">The  application's type (default: 'custom') options: 'Javascript-Widget', 'Unity', 'Unreal', etc).</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreateApplicationParameters(string s_target_id, string s_application_type = "custom")
        {
            this.s_target_id = s_target_id;
            this.s_application_type = s_application_type;

            return this;
        }

        /// <summary>
        /// The stomt parameters for delete application method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target the application belongs to.</param>
        /// <param name="s_application_id">The unique id of the application.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetDeleteApplicationParameters(string s_target_id, string s_application_id)
        {
            this.s_target_id = s_target_id;
            this.s_application_id = s_application_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get followers method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetFollowersParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get follows method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetFollowsParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for follow a target method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetFollowATargetParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for unfollow a target method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUnfollowATargetParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get invitations method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetInvitationsParameters(string s_target_id)
        {
            this.s_target_id = s_target_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for create invitations method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="b_invite_as_owner">The invited user will be owner of the page (default: true).</param>
        /// <param name="i_role_id">The role to the new owner.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCreateInvitationsParameters(string s_target_id, bool b_invite_as_owner = true, int i_role_id = 0)
        {
            this.s_target_id = s_target_id;
            this.b_invite_as_owner = b_invite_as_owner;
            this.i_role_id = i_role_id;

            return this;
        }

        /// <summary>
        /// The stomt parameters for check for validity method.
        /// </summary>
        /// <param name="s_target_id">The unique slug of the target.</param>
        /// <param name="s_code">The code of the invitation.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetCheckForValidityParameters(string s_target_id, string s_code)
        {
            this.s_target_id = s_target_id;
            this.s_code = s_code;

            return this;
        }

        /// <summary>
        /// The stomt parameters for search target users method.
        /// </summary>
        /// <param name="s_q">The term to search for in user name.</param>
        /// <param name="s_has">The filter for users matching the criteria, the keywords can be negated by prefixing them with a “!”. Following keywords are available: votes, comments, reactions, labels, stomts, data.</param>
        /// <param name="s_is">The filter for user types. Following keywords are available: targetOwner, anonym, follower.</param>
        /// <param name="s_groups">The filter for users that belong to groups.</param>
        /// <param name="i_offset">The pagination offset.</param>
        /// <param name="i_limit">The pagination limit.</param>
        /// <param name="s_order_by">The order of the users. </param>
        /// <returns>The container of stomt's parameters. Available order types are: mostVotes, leastVotes, mostReactions, leastReactions, mostStomts, leastStomts, mostComments, leastComments.</returns>
        public stomt_parameters uf_cdt_SetSearchTargetUsersParameters(string s_q = null, string s_has = null, string s_is = null, string s_groups = null, int i_offset = 0, int i_limit = 0, string s_order_by = null)
        {
            this.s_q = s_q;
            this.s_has = s_has;
            this.s_is = s_is;
            this.s_groups = s_groups;
            this.i_offset = i_offset;
            this.i_limit = i_limit;
            this.s_order_by = s_order_by;

            return this;
        }

        /// <summary>
        /// The stomt parameters for get all categories method.
        /// </summary>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetAllCategoriesParameters()
        {
            return this;
        }

        /// <summary>
        /// The stomt parameters for get notifications method.
        /// </summary>
        /// <param name="b_unseen">The unseen notifications' flag retrieval.</param>
        /// <param name="s_last_notification">The timestamp to get only notifications created after it.</param>
        /// <param name="i_offset">The number of notification for pagination.</param>
        /// <param name="i_limit">The number of notifications at once.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetGetNotificationsParameters(bool b_unseen = false, string s_last_notification = null, int i_offset = 0, int i_limit = 7)
        {
            this.b_unseen = b_unseen;
            this.s_last_notification = s_last_notification;
            this.i_offset = i_offset;
            this.i_limit = i_limit;

            return this;
        }

        /// <summary>
        /// The stomt parameters for update notifications method.
        /// </summary>
        /// <param name="s_id">The user's id.</param>
        /// <param name="b_seen">The notification has been shown to the user.</param>
        /// <param name="b_clicked">The notification has been clicked by the user.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUpdateNotificationsParameters(string s_id, bool b_seen = false, bool b_clicked = false)
        {
            this.s_id = s_id;
            this.b_seen = b_seen;
            this.b_clicked = b_clicked;

            return this;
        }

        /// <summary>
        /// The stomt parameters for upload image method.
        /// </summary>
        /// <param name="s_id">The target-id to upload image for owned target</param>
        /// <param name="s_context">The image's relative context (avatar/cover/stomt).</param>
        /// <param name="sa_image_data">The Base64 encoded image.</param>
        /// <param name="sa_image_url">The external image url - enables image-upload via URL.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUploadImageParameters(string s_id, string s_context = "stomt", string[] sa_image_data = null, string[] sa_image_url = null)
        {
            this.s_id = s_id;
            this.s_context_parameter = s_context;
            this.sa_image_data = sa_image_data;
            this.sa_image_url = sa_image_url;

            return this;
        }

        /// <summary>
        /// The stomt parameters for upload file method.
        /// </summary>
        /// <param name="sa_file_data">The Base64 encoded file.</param>
        /// <param name="s_context">The file's relative context (typically "stomt").</param>
        /// <param name="sa_filename">The custom file name e.g. user_actions.log.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetUploadFileParameters(string[] sa_file_data, string s_context = "stomt", string[] sa_filename = null)
        {
            this.s_context_parameter = s_context;
            this.sa_file_data = sa_file_data;
            this.sa_filename = sa_filename;

            return this;
        }

        /// <summary>
        /// The stomt parameters for search target method.
        /// </summary>
        /// <param name="s_q">The term to search for.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetSearchTargetParameters(string s_q)
        {
            this.s_q = s_q;

            return this;
        }

        /// <summary>
        /// The stomt parameters for search stomts method.
        /// </summary>
        /// <param name="s_q">The term to search for in the stomt text.</param>
        /// <param name="s_at">The stomts that belong in some way to the given target.</param>
        /// <param name="s_to">The filter for stomts the targets have received directly.</param>
        /// <param name="s_from">The filter for stomts created by these users.</param>
        /// <param name="s_has">The filter for stomts matching the criteria, the keywords can be negated by prefixing them with a “!”. Following keywords are available: votes, comments, reactiom, image, labels, url, file, data.</param>
        /// <param name="s_is">The filter for likes (like) or wishes (wish).</param>
        /// <param name="s_label">The filter for stomts that contain all given labels, labels can be negated.</param>
        /// <param name="s_hashtag">The filter for stomts that contain all given hashtags, hashtags can be negated.</param>
        /// <param name="s_lang">The filter for stomts matching specific languages (ISO 639-1), languages can be prefixed with “!” to exclude stomts in this language.</param>
        /// <param name="s_newer_than">The filter for stomts created after the specified date.</param>
        /// <param name="s_older_than">The filter for stomts created before the speciefied date.</param>
        /// <param name="s_order_by">The results' sort. Possible orders are available: popular, newest, oldest, text, newest_comment, oldest_comment, newest_reaction, oldest_reaction, newest_vote, oldest_vote.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetSearchStomtsParameters(string s_q = null, string s_at = null, string s_to = null, string s_from = null, string s_has = null, string s_is = null, string s_label = null, string s_hashtag = null,
            string s_lang = null, string s_newer_than = null, string s_older_than = null, string s_order_by = null)
        {
            this.s_q = s_q;
            this.s_at = s_at;
            this.s_to = s_to;
            this.s_from = s_from;
            this.s_has = s_has;
            this.s_is = s_is;
            this.s_label = s_label;
            this.s_hashtag = s_hashtag;
            this.s_lang = s_lang;
            this.s_newer_than = s_newer_than;
            this.s_older_than = s_older_than;
            this.s_order_by = s_order_by;

            return this;
        }

        /// <summary>
        /// The stomt parameters for search hashtags method.
        /// </summary>
        /// <param name="s_q">The hashtags similar to query.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetSearchHashtagsParameters(string s_q)
        {
            this.s_q = s_q;

            return this;
        }

        /// <summary>
        /// The stomt parameters for retrieve exported stomts method.
        /// </summary>
        /// <param name="s_access_token">The access token of the current user session.</param>
        /// <param name="s_file_type">The requested file format (csv, xls, xlsx, etc)</param>
        /// <param name="s_stomts">The comma separated list of stomt slugs</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRetrieveExportedStomtsParameters(string s_access_token, string s_file_type, string s_stomts)
        {
            this.s_access_token = s_access_token;
            this.s_file_type = s_file_type;
            this.s_stomts = s_stomts;

            return this;
        }

        /// <summary>
        /// The stomt parameters for retrieve exported users method.
        /// </summary>
        /// <param name="s_access_token">The access token of the current user session.</param>
        /// <param name="s_file_type">The requested file format (csv, xls, xlsx, etc)</param>
        /// <param name="s_users">The comma separated list of user ids.</param>
        /// <param name="s_target">The id of the target the user data should be calculated from.</param>
        /// <returns>The container of stomt's parameters.</returns>
        public stomt_parameters uf_cdt_SetRetrieveExportedUsersParameters(string s_access_token, string s_file_type, string s_users, string s_target)
        {
            this.s_access_token = s_access_token;
            this.s_file_type = s_file_type;
            this.s_users = s_users;
            this.s_target = s_target;

            return this;
        }
    }
}
