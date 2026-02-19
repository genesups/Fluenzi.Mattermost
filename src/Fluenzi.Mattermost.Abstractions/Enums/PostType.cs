namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// All known Mattermost post types.
/// </summary>
public enum PostType
{
    /// <summary>Regular user post ("")</summary>
    Default,

    /// <summary>Slack-compatible attachment ("slack_attachment")</summary>
    SlackAttachment,

    /// <summary>Generic system message ("system_generic")</summary>
    SystemGeneric,

    /// <summary>Join/leave combined ("system_join_leave")</summary>
    JoinLeave,

    /// <summary>User joined channel ("system_join_channel")</summary>
    Join,

    /// <summary>User left channel ("system_leave_channel")</summary>
    Leave,

    /// <summary>User added to channel ("system_add_to_channel")</summary>
    Add,

    /// <summary>User removed from channel ("system_remove_from_channel")</summary>
    Remove,

    /// <summary>Channel header changed ("system_header_change")</summary>
    HeaderChange,

    /// <summary>Channel display name changed ("system_displayname_change")</summary>
    DisplayNameChange,

    /// <summary>Channel purpose changed ("system_purpose_change")</summary>
    PurposeChange,

    /// <summary>Channel deleted ("system_channel_deleted")</summary>
    ChannelDeleted,

    /// <summary>Channel restored ("system_channel_restored")</summary>
    ChannelRestored,

    /// <summary>Ephemeral system message ("system_ephemeral")</summary>
    EphemeralMessage,

    /// <summary>Channel privacy changed ("system_change_chan_privacy")</summary>
    ChangeChannelPrivacy,

    /// <summary>User added to team ("system_add_to_team")</summary>
    AddToTeam,

    /// <summary>User removed from team ("system_remove_from_team")</summary>
    RemoveFromTeam,

    /// <summary>Guest added to channels ("system_add_guest_to_chan")</summary>
    AddGuestsToChannels,

    /// <summary>Combined user activity ("system_combined_user_activity")</summary>
    CombinedUserActivity,

    /// <summary>Me message ("me")</summary>
    MeMessage,

    /// <summary>Reminder ("system_reminder")</summary>
    Reminder,

    /// <summary>Warn metric status ("system_warn_metric_status")</summary>
    WarnMetricStatus,

    /// <summary>GM converted to channel ("system_gm_to_channel")</summary>
    GmConvertedToChannel,

    /// <summary>Custom groups name ("custom_groups")</summary>
    CustomGroupsName,
}

/// <summary>
/// Extension methods for converting <see cref="PostType"/> to and from API string representations.
/// </summary>
public static class PostTypeExtensions
{
    /// <summary>
    /// Converts the <see cref="PostType"/> to its API string representation.
    /// </summary>
    public static string ToApiString(this PostType postType) => postType switch
    {
        PostType.Default => "",
        PostType.SlackAttachment => "slack_attachment",
        PostType.SystemGeneric => "system_generic",
        PostType.JoinLeave => "system_join_leave",
        PostType.Join => "system_join_channel",
        PostType.Leave => "system_leave_channel",
        PostType.Add => "system_add_to_channel",
        PostType.Remove => "system_remove_from_channel",
        PostType.HeaderChange => "system_header_change",
        PostType.DisplayNameChange => "system_displayname_change",
        PostType.PurposeChange => "system_purpose_change",
        PostType.ChannelDeleted => "system_channel_deleted",
        PostType.ChannelRestored => "system_channel_restored",
        PostType.EphemeralMessage => "system_ephemeral",
        PostType.ChangeChannelPrivacy => "system_change_chan_privacy",
        PostType.AddToTeam => "system_add_to_team",
        PostType.RemoveFromTeam => "system_remove_from_team",
        PostType.AddGuestsToChannels => "system_add_guest_to_chan",
        PostType.CombinedUserActivity => "system_combined_user_activity",
        PostType.MeMessage => "me",
        PostType.Reminder => "system_reminder",
        PostType.WarnMetricStatus => "system_warn_metric_status",
        PostType.GmConvertedToChannel => "system_gm_to_channel",
        PostType.CustomGroupsName => "custom_groups",
        _ => throw new ArgumentOutOfRangeException(nameof(postType), postType, "Unknown post type."),
    };

    /// <summary>
    /// Converts an API string to its <see cref="PostType"/> representation.
    /// </summary>
    public static PostType FromApiString(string apiString) => apiString switch
    {
        "" or null => PostType.Default,
        "slack_attachment" => PostType.SlackAttachment,
        "system_generic" => PostType.SystemGeneric,
        "system_join_leave" => PostType.JoinLeave,
        "system_join_channel" => PostType.Join,
        "system_leave_channel" => PostType.Leave,
        "system_add_to_channel" => PostType.Add,
        "system_remove_from_channel" => PostType.Remove,
        "system_header_change" => PostType.HeaderChange,
        "system_displayname_change" => PostType.DisplayNameChange,
        "system_purpose_change" => PostType.PurposeChange,
        "system_channel_deleted" => PostType.ChannelDeleted,
        "system_channel_restored" => PostType.ChannelRestored,
        "system_ephemeral" => PostType.EphemeralMessage,
        "system_change_chan_privacy" => PostType.ChangeChannelPrivacy,
        "system_add_to_team" => PostType.AddToTeam,
        "system_remove_from_team" => PostType.RemoveFromTeam,
        "system_add_guest_to_chan" => PostType.AddGuestsToChannels,
        "system_combined_user_activity" => PostType.CombinedUserActivity,
        "me" => PostType.MeMessage,
        "system_reminder" => PostType.Reminder,
        "system_warn_metric_status" => PostType.WarnMetricStatus,
        "system_gm_to_channel" => PostType.GmConvertedToChannel,
        "custom_groups" => PostType.CustomGroupsName,
        _ => PostType.Default,
    };
}
