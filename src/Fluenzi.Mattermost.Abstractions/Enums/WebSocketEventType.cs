namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// All known Mattermost WebSocket event types.
/// </summary>
public enum WebSocketEventType
{
    Unknown = 0,

    // Connection
    Hello,
    Response,

    // Posts
    Posted,
    PostEdited,
    PostDeleted,
    PostUnread,
    EphemeralMessage,
    PostAcknowledgementAdded,
    PostAcknowledgementRemoved,

    // Reactions
    ReactionAdded,
    ReactionRemoved,

    // Channels
    ChannelCreated,
    ChannelUpdated,
    ChannelDeleted,
    ChannelConverted,
    ChannelViewed,
    ChannelMemberUpdated,
    ChannelSchemeUpdated,
    ChannelRestored,
    DirectAdded,
    GroupAdded,
    MultipleChannelsViewed,

    // Users
    NewUser,
    UserAdded,
    UserUpdated,
    UserRemoved,
    UserRoleUpdated,
    MemberRoleUpdated,
    UserActivationStatusChange,

    // Typing
    Typing,

    // Status & Presence
    StatusChange,
    PresenceIndicator,

    // Teams
    AddedToTeam,
    LeaveTeam,
    UpdateTeam,
    DeleteTeam,
    RestoreTeam,
    UpdateTeamScheme,

    // Threads
    ThreadUpdated,
    ThreadFollowChanged,
    ThreadReadChanged,

    // Preferences
    PreferencesChanged,
    PreferencesDeleted,

    // Emoji
    EmojiAdded,

    // Sidebar
    SidebarCategoryCreated,
    SidebarCategoryUpdated,
    SidebarCategoryDeleted,
    SidebarCategoryOrderUpdated,

    // Roles
    RoleUpdated,

    // Plugins
    PluginStatusesChanged,
    PluginEnabled,
    PluginDisabled,

    // System
    LicenseChanged,
    ConfigChanged,

    // Dialogs
    OpenDialog,
    CloseDialog,

    // Drafts
    DraftCreated,
    DraftUpdated,
    DraftDeleted,

    // Calls (plugin)
    CallStarted,
    CallEnded,
    CallUserJoined,
    CallUserLeft,
    CallScreenOn,
    CallScreenOff,
    CallChannelState,

    // Groups
    ReceivedGroup,
    ReceivedGroupAssociatedToTeam,
    ReceivedGroupNotAssociatedToTeam,
    ReceivedGroupAssociatedToChannel,
    ReceivedGroupNotAssociatedToChannel,
    GroupMemberAdd,
    GroupMemberDelete,

    // Cloud
    CloudPaymentStatusUpdated,
    CloudSubscriptionChanged,

    // Bookmarks
    ChannelBookmarkCreated,
    ChannelBookmarkUpdated,
    ChannelBookmarkDeleted,
    ChannelBookmarkSorted,

    // Scheduled Posts
    ScheduledPostCreated,
    ScheduledPostUpdated,
    ScheduledPostDeleted,

    // Guest
    GuestRequested,

    // Post Translation
    PostTranslationUpdated,

    // Misc
    ShowToast,
    WebRTC,
}
