using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Copyright © 2018+ Yiannis Panakos.
/// Creation Date: 20/08/2018, Update Date: 14/10/2018.
/// </summary>

namespace Stomt
{
    //class EnumsClass
    //{
    //}

    /// <summary>
    /// Content's type.
    /// </summary>
    public enum content_type { application_json, text_html };

    /// <summary>
    /// Http method requests.
    /// </summary>
    public enum http_method { post_request, get_request, put_request, delete_request };

    /// <summary>
    ///  Stomt's feature.
    /// </summary>
    public enum stomt_feature
    {
        register_an_user, login, logout, oauth_login, check_availability, suggest_usernames, verify_email, forgot_password, reset_password, // Authentication.
        creates_a_stomt, read_a_stomt, delete_a_stomt, // Stomts.
        create_stomt_agreement, delete_stomt_agreement, get_stomt_voters, // Stomt Agreements.
        create_a_comment, read_stomt_comments, edit_a_comment, delete_a_single_comment, // Stomt Comments.
        vote_on_a_comment, revoke_a_vote, // Stomt Comment Votes.
        label_a_stomt, unlabel_a_stomt, label_a_list_of_stomts, remove_label_from_list_of_stomts, // Stomt Labels.
        get_a_specific_feed, // Feeds.
        create_a_target, preflight_request, get_a_target, get_target_stomts, update_a_target, // Targets.
        get_application, create_application, delete_application, // Target Applications.
        get_followers, follow_a_target, unfollow_a_target, get_follows, // Target Following.
        get_invitations, create_invitation, check_for_validity, // Target Invitations.
        search_target_users, // Target Users.
        get_all_categories, // Categories.
        get_notifications, update_notifications, // Notifications.
        upload_image, // Images.
        upload_file, // Files.
        search_target, search_stomts, search_hashtags, // Search.
        retrieve_exported_stomts, retrieve_exported_users // Export.
    };

    /// <summary>
    /// Stomt's authentication.
    /// </summary>
    public enum stomt_authentication { normal, facebook, reddit, twitter };

    /// <summary>
    /// Stomt's property.
    /// </summary>
    public enum stomt_property { username, email, displayname };

    /// <summary>
    /// Stomt's preflight source.
    /// </summary>
    public enum stomt_preflight_source { tw }; // Currently only Twitter.

    /// <summary>
    /// Stomt's application type.
    /// </summary>
    public enum stomt_application_type { custom, Javascript_Widget, Unity, Unreal }; // ToDo: Search more about these ones.

    /// <summary>
    /// Stomt's show type.
    /// </summary>
    public enum stomt_show_type { received, created, top };

    /// <summary>
    /// Stomt's second type.
    /// </summary>
    public enum stomt_second_type { positive, negative };

    /// <summary>
    /// Stomt's options for the "has" parameter at target users.
    /// </summary>
    public enum stomt_user_has { votes, comments, reactions, labels, stomts, data }; // ToDo: Search more about these ones.

    /// <summary>
    /// Stomt's options for the "has" parameter at search stomts.
    /// </summary>
    public enum stomt_search_has { votes, comments, reaction, image, labels, url, file, data }; // ToDo: Search more about these ones.

    /// <summary>
    /// Stomt's options for the "is" parameter.
    /// </summary>
    public enum stomt_is { targetOwner, anonym, follower };

    /// <summary>
    /// Stomt's order by options at target users.
    /// </summary>
    public enum stomt_user_order_by { mostVotes, leastVotes, mostReactions, leastReactions, mostStomt, leastStomt, mostComments, leastComments };

    /// <summary>
    /// Stomt's order by options at search stomts.
    /// </summary>
    public enum stomt_search_order_by { popular, newest, oldest, text, newest_comment, oldest_comment, newest_reaction, oldest_reaction, newest_vote, oldest_vote };

    /// <summary>
    /// Stomt's image format.
    /// </summary>
    public enum stomt_image_format { jpg, png, gif, bmp, tiff };

    /// <summary>
    /// Stomt's file format.
    /// </summary>
    public enum stomt_file_format { txt, log, zip };

    /// <summary>
    /// Stomt's export format.
    /// </summary>
    public enum stomt_export_format { csv, xls, xlsx }; // ToDo: Search more about these ones.

    /// <summary>
    /// Stomt's image context.
    /// </summary>
    public enum stomt_image_context { avatar, cover, stomt };
}
