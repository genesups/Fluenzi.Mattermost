namespace Fluenzi.Mattermost.Constants;

/// <summary>
/// Mattermost API v4 route templates. Use <see cref="string.Format(string, object[])"/> to fill placeholders.
/// </summary>
public static class ApiRoutes
{
    public const string Base = "/api/v4";

    // Users
    public const string Users = "/api/v4/users";
    public const string UsersMe = "/api/v4/users/me";
    public const string User = "/api/v4/users/{0}";
    public const string UserByUsername = "/api/v4/users/username/{0}";
    public const string UserByEmail = "/api/v4/users/email/{0}";
    public const string UserImage = "/api/v4/users/{0}/image";
    public const string UserStatus = "/api/v4/users/{0}/status";
    public const string UsersStatus = "/api/v4/users/status/ids";
    public const string UsersSearch = "/api/v4/users/search";
    public const string UserSessions = "/api/v4/users/{0}/sessions";
    public const string UserTokens = "/api/v4/users/{0}/tokens";
    public const string UserMfa = "/api/v4/users/{0}/mfa";
    public const string UserPassword = "/api/v4/users/{0}/password";
    public const string UserPatch = "/api/v4/users/{0}/patch";
    public const string UsersLogin = "/api/v4/users/login";
    public const string UsersLogout = "/api/v4/users/logout";

    // Teams
    public const string Teams = "/api/v4/teams";
    public const string Team = "/api/v4/teams/{0}";
    public const string TeamByName = "/api/v4/teams/name/{0}";
    public const string TeamMembers = "/api/v4/teams/{0}/members";
    public const string TeamMember = "/api/v4/teams/{0}/members/{1}";
    public const string TeamStats = "/api/v4/teams/{0}/stats";
    public const string TeamsSearch = "/api/v4/teams/search";
    public const string UserTeams = "/api/v4/users/{0}/teams";
    public const string UserTeamMembers = "/api/v4/users/{0}/teams/members";
    public const string UserTeamUnread = "/api/v4/users/{0}/teams/unread";

    // Channels
    public const string Channels = "/api/v4/channels";
    public const string Channel = "/api/v4/channels/{0}";
    public const string ChannelByName = "/api/v4/teams/{0}/channels/name/{1}";
    public const string ChannelMembers = "/api/v4/channels/{0}/members";
    public const string ChannelMember = "/api/v4/channels/{0}/members/{1}";
    public const string ChannelStats = "/api/v4/channels/{0}/stats";
    public const string ChannelPinned = "/api/v4/channels/{0}/pinned";
    public const string ChannelsSearch = "/api/v4/teams/{0}/channels/search";
    public const string ChannelsDirect = "/api/v4/channels/direct";
    public const string ChannelsGroup = "/api/v4/channels/group";
    public const string UserChannels = "/api/v4/users/{0}/teams/{1}/channels";
    public const string UserChannelMembers = "/api/v4/users/{0}/teams/{1}/channels/members";
    public const string ChannelCategories = "/api/v4/users/{0}/teams/{1}/channels/categories";
    public const string ChannelCategory = "/api/v4/users/{0}/teams/{1}/channels/categories/{2}";
    public const string ChannelViewPost = "/api/v4/channels/members/me/view";

    // Posts
    public const string Posts = "/api/v4/posts";
    public const string Post = "/api/v4/posts/{0}";
    public const string PostThread = "/api/v4/posts/{0}/thread";
    public const string PostPin = "/api/v4/posts/{0}/pin";
    public const string PostUnpin = "/api/v4/posts/{0}/unpin";
    public const string PostPatch = "/api/v4/posts/{0}/patch";
    public const string ChannelPosts = "/api/v4/channels/{0}/posts";
    public const string PostsSearch = "/api/v4/teams/{0}/posts/search";
    public const string PostsFlagged = "/api/v4/users/me/posts/flagged";
    public const string PostActions = "/api/v4/posts/{0}/actions/{1}";
    public const string PostAcknowledge = "/api/v4/users/me/posts/{0}/ack";
    public const string PostUnacknowledge = "/api/v4/users/me/posts/{0}/unack";

    // Files
    public const string Files = "/api/v4/files";
    public const string File = "/api/v4/files/{0}";
    public const string FileInfo = "/api/v4/files/{0}/info";
    public const string FileThumbnail = "/api/v4/files/{0}/thumbnail";
    public const string FilePreview = "/api/v4/files/{0}/preview";
    public const string FileLink = "/api/v4/files/{0}/link";

    // Reactions
    public const string Reactions = "/api/v4/reactions";
    public const string PostReactions = "/api/v4/posts/{0}/reactions";

    // Emoji
    public const string Emojis = "/api/v4/emoji";
    public const string Emoji = "/api/v4/emoji/{0}";
    public const string EmojiByName = "/api/v4/emoji/name/{0}";
    public const string EmojiImage = "/api/v4/emoji/{0}/image";
    public const string EmojisSearch = "/api/v4/emoji/search";
    public const string EmojisAutocomplete = "/api/v4/emoji/autocomplete";

    // Preferences
    public const string Preferences = "/api/v4/users/{0}/preferences";
    public const string PreferencesDelete = "/api/v4/users/{0}/preferences/delete";
    public const string PreferencesByCategory = "/api/v4/users/{0}/preferences/{1}";
    public const string PreferenceByCategoryAndName = "/api/v4/users/{0}/preferences/{1}/name/{2}";

    // Threads
    public const string UserThreads = "/api/v4/users/{0}/teams/{1}/threads";
    public const string UserThread = "/api/v4/users/{0}/teams/{1}/threads/{2}";
    public const string UserThreadRead = "/api/v4/users/{0}/teams/{1}/threads/{2}/read/{3}";
    public const string UserThreadFollowing = "/api/v4/users/{0}/teams/{1}/threads/{2}/following";
    public const string UserThreadsRead = "/api/v4/users/{0}/teams/{1}/threads/read";

    // Webhooks
    public const string IncomingWebhooks = "/api/v4/hooks/incoming";
    public const string IncomingWebhook = "/api/v4/hooks/incoming/{0}";
    public const string OutgoingWebhooks = "/api/v4/hooks/outgoing";
    public const string OutgoingWebhook = "/api/v4/hooks/outgoing/{0}";
    public const string OutgoingWebhookRegen = "/api/v4/hooks/outgoing/{0}/regen_token";

    // Commands
    public const string Commands = "/api/v4/commands";
    public const string Command = "/api/v4/commands/{0}";
    public const string CommandExecute = "/api/v4/commands/execute";

    // Bots
    public const string Bots = "/api/v4/bots";
    public const string Bot = "/api/v4/bots/{0}";
    public const string BotEnable = "/api/v4/bots/{0}/enable";
    public const string BotDisable = "/api/v4/bots/{0}/disable";
    public const string BotAssign = "/api/v4/bots/{0}/assign/{1}";
    public const string BotIcon = "/api/v4/bots/{0}/icon";

    // OAuth
    public const string OAuthApps = "/api/v4/oauth/apps";
    public const string OAuthApp = "/api/v4/oauth/apps/{0}";

    // Roles
    public const string Roles = "/api/v4/roles";
    public const string Role = "/api/v4/roles/{0}";
    public const string RoleByName = "/api/v4/roles/name/{0}";
    public const string RolesByNames = "/api/v4/roles/names";
    public const string RolePatch = "/api/v4/roles/{0}/patch";

    // Groups
    public const string Groups = "/api/v4/groups";
    public const string Group = "/api/v4/groups/{0}";
    public const string GroupMembers = "/api/v4/groups/{0}/members";
    public const string GroupStats = "/api/v4/groups/{0}/stats";
    public const string ChannelGroups = "/api/v4/channels/{0}/groups";
    public const string TeamGroups = "/api/v4/teams/{0}/groups";

    // System
    public const string Config = "/api/v4/config";
    public const string ConfigReload = "/api/v4/config/reload";
    public const string ConfigClient = "/api/v4/config/client";
    public const string License = "/api/v4/license";
    public const string LicenseClient = "/api/v4/license/client";
    public const string Audits = "/api/v4/audits";
    public const string Logs = "/api/v4/logs";
    public const string Analytics = "/api/v4/analytics/old";
    public const string Ping = "/api/v4/system/ping";
    public const string ServerBusy = "/api/v4/server_busy";
    public const string TestEmail = "/api/v4/email/test";
    public const string TestSiteUrl = "/api/v4/site_url/test";
    public const string Database = "/api/v4/database/recycle";
    public const string Caches = "/api/v4/caches/invalidate";

    // Compliance
    public const string ComplianceReports = "/api/v4/compliance/reports";
    public const string ComplianceReport = "/api/v4/compliance/reports/{0}";
    public const string ComplianceReportDownload = "/api/v4/compliance/reports/{0}/download";

    // Data Retention
    public const string DataRetention = "/api/v4/data_retention/policy";
    public const string DataRetentionPolicies = "/api/v4/data_retention/policies";

    // Plugins
    public const string Plugins = "/api/v4/plugins";
    public const string Plugin = "/api/v4/plugins/{0}";
    public const string PluginEnable = "/api/v4/plugins/{0}/enable";
    public const string PluginDisable = "/api/v4/plugins/{0}/disable";
    public const string PluginStatuses = "/api/v4/plugins/statuses";
    public const string PluginMarketplace = "/api/v4/plugins/marketplace";

    // Jobs
    public const string Jobs = "/api/v4/jobs";
    public const string Job = "/api/v4/jobs/{0}";
    public const string JobCancel = "/api/v4/jobs/{0}/cancel";
    public const string JobsByType = "/api/v4/jobs/type/{0}";

    // LDAP
    public const string LdapSync = "/api/v4/ldap/sync";
    public const string LdapTest = "/api/v4/ldap/test";
    public const string LdapGroups = "/api/v4/ldap/groups";

    // SAML
    public const string SamlMetadata = "/api/v4/saml/metadata";
    public const string SamlCertificate = "/api/v4/saml/certificate/{0}";

    // Elasticsearch
    public const string ElasticsearchTest = "/api/v4/elasticsearch/test";
    public const string ElasticsearchPurge = "/api/v4/elasticsearch/purge_indexes";

    // Bookmarks
    public const string ChannelBookmarks = "/api/v4/channels/{0}/bookmarks";
    public const string ChannelBookmark = "/api/v4/channels/{0}/bookmarks/{1}";
    public const string ChannelBookmarkSort = "/api/v4/channels/{0}/bookmarks/sort";

    // Imports/Exports
    public const string Exports = "/api/v4/exports";
    public const string Export = "/api/v4/exports/{0}";

    // WebSocket
    public const string WebSocket = "/api/v4/websocket";
}
