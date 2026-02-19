using System.Runtime.CompilerServices;
using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Models.Channels;
using Fluenzi.Mattermost.Models.Commands;
using Fluenzi.Mattermost.Models.Common;
using Fluenzi.Mattermost.Models.Compliance;
using Fluenzi.Mattermost.Models.Emoji;
using Fluenzi.Mattermost.Models.Files;
using Fluenzi.Mattermost.Models.Groups;
using Fluenzi.Mattermost.Models.Integrations;
using Fluenzi.Mattermost.Models.Jobs;
using Fluenzi.Mattermost.Models.Posts;
using Fluenzi.Mattermost.Models.Preferences;
using Fluenzi.Mattermost.Models.Reactions;
using Fluenzi.Mattermost.Models.Roles;
using Fluenzi.Mattermost.Models.System;
using Fluenzi.Mattermost.Models.Teams;
using Fluenzi.Mattermost.Models.Threads;
using Fluenzi.Mattermost.Models.Users;
using Fluenzi.Mattermost.Models.Webhooks;

namespace Fluenzi.Mattermost.Client.Services;

public class MattermostApiClient : IMattermostApiClient
{
    private readonly UserApiClient _users;
    private readonly TeamApiClient _teams;
    private readonly ChannelApiClient _channels;
    private readonly PostApiClient _posts;
    private readonly FileApiClient _files;
    private readonly ReactionApiClient _reactions;
    private readonly EmojiApiClient _emojis;
    private readonly PreferenceApiClient _preferences;
    private readonly ThreadApiClient _threads;
    private readonly RoleApiClient _roles;
    private readonly GroupApiClient _groups;
    private readonly WebhookApiClient _webhooks;
    private readonly CommandApiClient _commands;
    private readonly BotApiClient _bots;
    private readonly OAuthApiClient _oauth;
    private readonly SystemApiClient _system;
    private readonly ComplianceApiClient _compliance;
    private readonly DataRetentionApiClient _dataRetention;
    private readonly PluginApiClient _plugins;
    private readonly JobApiClient _jobs;
    private readonly LdapApiClient _ldap;
    private readonly SamlApiClient _saml;
    private readonly ElasticsearchApiClient _elasticsearch;
    private readonly BookmarkApiClient _bookmarks;
    private readonly ImportExportApiClient _importExport;

    public MattermostApiClient(ApiRequestHandler api)
    {
        _users = new UserApiClient(api);
        _teams = new TeamApiClient(api);
        _channels = new ChannelApiClient(api);
        _posts = new PostApiClient(api);
        _files = new FileApiClient(api);
        _reactions = new ReactionApiClient(api);
        _emojis = new EmojiApiClient(api);
        _preferences = new PreferenceApiClient(api);
        _threads = new ThreadApiClient(api);
        _roles = new RoleApiClient(api);
        _groups = new GroupApiClient(api);
        _webhooks = new WebhookApiClient(api);
        _commands = new CommandApiClient(api);
        _bots = new BotApiClient(api);
        _oauth = new OAuthApiClient(api);
        _system = new SystemApiClient(api);
        _compliance = new ComplianceApiClient(api);
        _dataRetention = new DataRetentionApiClient(api);
        _plugins = new PluginApiClient(api);
        _jobs = new JobApiClient(api);
        _ldap = new LdapApiClient(api);
        _saml = new SamlApiClient(api);
        _elasticsearch = new ElasticsearchApiClient(api);
        _bookmarks = new BookmarkApiClient(api);
        _importExport = new ImportExportApiClient(api);
    }

    // IUserApi
    public Task<User> GetMeAsync(CancellationToken ct = default) => _users.GetMeAsync(ct);
    public Task<User> GetUserAsync(string userId, CancellationToken ct = default) => _users.GetUserAsync(userId, ct);
    public Task<User> GetUserByUsernameAsync(string username, CancellationToken ct = default) => _users.GetUserByUsernameAsync(username, ct);
    public Task<User> GetUserByEmailAsync(string email, CancellationToken ct = default) => _users.GetUserByEmailAsync(email, ct);
    public Task<PagedResult<User>> GetUsersAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _users.GetUsersAsync(page, perPage, ct);
    public IAsyncEnumerable<User> GetAllUsersAsync(CancellationToken ct = default) => _users.GetAllUsersAsync(ct);
    public Task<IReadOnlyList<User>> GetUsersByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default) => _users.GetUsersByIdsAsync(userIds, ct);
    public Task<IReadOnlyList<User>> GetUsersByUsernamesAsync(IEnumerable<string> usernames, CancellationToken ct = default) => _users.GetUsersByUsernamesAsync(usernames, ct);
    public Task<IReadOnlyList<User>> SearchUsersAsync(string term, CancellationToken ct = default) => _users.SearchUsersAsync(term, ct);
    public Task<User> UpdateUserAsync(string userId, User user, CancellationToken ct = default) => _users.UpdateUserAsync(userId, user, ct);
    public Task<User> PatchUserAsync(string userId, Dictionary<string, object> patch, CancellationToken ct = default) => _users.PatchUserAsync(userId, patch, ct);
    public Task<UserStatus> GetUserStatusAsync(string userId, CancellationToken ct = default) => _users.GetUserStatusAsync(userId, ct);
    public Task<IReadOnlyList<UserStatus>> GetUsersStatusByIdsAsync(IEnumerable<string> userIds, CancellationToken ct = default) => _users.GetUsersStatusByIdsAsync(userIds, ct);
    public Task<UserStatus> UpdateUserStatusAsync(string userId, UserStatus status, CancellationToken ct = default) => _users.UpdateUserStatusAsync(userId, status, ct);
    public Task<byte[]?> GetProfileImageAsync(string userId, CancellationToken ct = default) => _users.GetProfileImageAsync(userId, ct);
    public Task SetProfileImageAsync(string userId, Stream image, CancellationToken ct = default) => _users.SetProfileImageAsync(userId, image, ct);
    public Task<IReadOnlyList<UserAccessToken>> GetUserAccessTokensAsync(string userId, int page = 0, int perPage = 60, CancellationToken ct = default) => _users.GetUserAccessTokensAsync(userId, page, perPage, ct);
    public Task<UserAccessToken> CreateUserAccessTokenAsync(string userId, string description, CancellationToken ct = default) => _users.CreateUserAccessTokenAsync(userId, description, ct);
    public Task RevokeUserAccessTokenAsync(string tokenId, CancellationToken ct = default) => _users.RevokeUserAccessTokenAsync(tokenId, ct);
    public Task<IReadOnlyList<Session>> GetUserSessionsAsync(string userId, CancellationToken ct = default) => _users.GetUserSessionsAsync(userId, ct);
    public Task RevokeSessionAsync(string userId, string sessionId, CancellationToken ct = default) => _users.RevokeSessionAsync(userId, sessionId, ct);
    public Task DeactivateUserAsync(string userId, CancellationToken ct = default) => _users.DeactivateUserAsync(userId, ct);
    public Task<UserCustomStatus?> GetUserCustomStatusAsync(string userId, CancellationToken ct = default) => _users.GetUserCustomStatusAsync(userId, ct);
    public Task UpdateUserCustomStatusAsync(string userId, UserCustomStatus status, CancellationToken ct = default) => _users.UpdateUserCustomStatusAsync(userId, status, ct);
    public Task RemoveUserCustomStatusAsync(string userId, CancellationToken ct = default) => _users.RemoveUserCustomStatusAsync(userId, ct);

    // ITeamApi
    public Task<Team> GetTeamAsync(string teamId, CancellationToken ct = default) => _teams.GetTeamAsync(teamId, ct);
    public Task<Team> GetTeamByNameAsync(string name, CancellationToken ct = default) => _teams.GetTeamByNameAsync(name, ct);
    public Task<IReadOnlyList<Team>> GetMyTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _teams.GetMyTeamsAsync(page, perPage, ct);
    public Task<PagedResult<Team>> GetTeamsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _teams.GetTeamsAsync(page, perPage, ct);
    public IAsyncEnumerable<Team> GetAllTeamsAsync(CancellationToken ct = default) => _teams.GetAllTeamsAsync(ct);
    public Task<IReadOnlyList<Team>> SearchTeamsAsync(string term, CancellationToken ct = default) => _teams.SearchTeamsAsync(term, ct);
    public Task<Team> CreateTeamAsync(Team team, CancellationToken ct = default) => _teams.CreateTeamAsync(team, ct);
    public Task<Team> UpdateTeamAsync(string teamId, Team team, CancellationToken ct = default) => _teams.UpdateTeamAsync(teamId, team, ct);
    public Task DeleteTeamAsync(string teamId, bool permanent = false, CancellationToken ct = default) => _teams.DeleteTeamAsync(teamId, permanent, ct);
    public Task<TeamMember> AddTeamMemberAsync(string teamId, string userId, CancellationToken ct = default) => _teams.AddTeamMemberAsync(teamId, userId, ct);
    public Task RemoveTeamMemberAsync(string teamId, string userId, CancellationToken ct = default) => _teams.RemoveTeamMemberAsync(teamId, userId, ct);
    public Task<PagedResult<TeamMember>> GetTeamMembersAsync(string teamId, int page = 0, int perPage = 60, CancellationToken ct = default) => _teams.GetTeamMembersAsync(teamId, page, perPage, ct);
    public Task<TeamMember> GetTeamMemberAsync(string teamId, string userId, CancellationToken ct = default) => _teams.GetTeamMemberAsync(teamId, userId, ct);
    public Task<IReadOnlyList<TeamMember>> GetTeamMembersForUserAsync(string userId, CancellationToken ct = default) => _teams.GetTeamMembersForUserAsync(userId, ct);
    public Task<TeamStats> GetTeamStatsAsync(string teamId, CancellationToken ct = default) => _teams.GetTeamStatsAsync(teamId, ct);
    public Task<IReadOnlyList<TeamUnread>> GetTeamUnreadsForUserAsync(string userId, CancellationToken ct = default) => _teams.GetTeamUnreadsForUserAsync(userId, ct);
    public Task UpdateTeamMemberRolesAsync(string teamId, string userId, string roles, CancellationToken ct = default) => _teams.UpdateTeamMemberRolesAsync(teamId, userId, roles, ct);

    // IChannelApi
    public Task<Channel> GetChannelAsync(string channelId, CancellationToken ct = default) => _channels.GetChannelAsync(channelId, ct);
    public Task<Channel> GetChannelByNameAsync(string teamId, string channelName, bool includeDeleted = false, CancellationToken ct = default) => _channels.GetChannelByNameAsync(teamId, channelName, includeDeleted, ct);
    public Task<IReadOnlyList<Channel>> GetChannelsForUserAsync(string userId, string teamId, int page = 0, int perPage = 200, CancellationToken ct = default) => _channels.GetChannelsForUserAsync(userId, teamId, page, perPage, ct);
    public Task<IReadOnlyList<Channel>> GetPublicChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default) => _channels.GetPublicChannelsForTeamAsync(teamId, page, perPage, ct);
    public Task<IReadOnlyList<Channel>> GetPrivateChannelsForTeamAsync(string teamId, int page = 0, int perPage = 200, CancellationToken ct = default) => _channels.GetPrivateChannelsForTeamAsync(teamId, page, perPage, ct);
    public Task<IReadOnlyList<Channel>> SearchChannelsAsync(string teamId, string term, CancellationToken ct = default) => _channels.SearchChannelsAsync(teamId, term, ct);
    public Task<Channel> CreateChannelAsync(Channel channel, CancellationToken ct = default) => _channels.CreateChannelAsync(channel, ct);
    public Task<Channel> UpdateChannelAsync(string channelId, Channel channel, CancellationToken ct = default) => _channels.UpdateChannelAsync(channelId, channel, ct);
    public Task<Channel> PatchChannelAsync(string channelId, Dictionary<string, object> patch, CancellationToken ct = default) => _channels.PatchChannelAsync(channelId, patch, ct);
    public Task DeleteChannelAsync(string channelId, CancellationToken ct = default) => _channels.DeleteChannelAsync(channelId, ct);
    public Task RestoreChannelAsync(string channelId, CancellationToken ct = default) => _channels.RestoreChannelAsync(channelId, ct);
    public Task<Channel> CreateDirectChannelAsync(string userId1, string userId2, CancellationToken ct = default) => _channels.CreateDirectChannelAsync(userId1, userId2, ct);
    public Task<Channel> CreateGroupChannelAsync(IEnumerable<string> userIds, CancellationToken ct = default) => _channels.CreateGroupChannelAsync(userIds, ct);
    public Task<ChannelMember> AddChannelMemberAsync(string channelId, string userId, CancellationToken ct = default) => _channels.AddChannelMemberAsync(channelId, userId, ct);
    public Task RemoveChannelMemberAsync(string channelId, string userId, CancellationToken ct = default) => _channels.RemoveChannelMemberAsync(channelId, userId, ct);
    public Task<PagedResult<ChannelMember>> GetChannelMembersAsync(string channelId, int page = 0, int perPage = 60, CancellationToken ct = default) => _channels.GetChannelMembersAsync(channelId, page, perPage, ct);
    public Task<ChannelMember> GetChannelMemberAsync(string channelId, string userId, CancellationToken ct = default) => _channels.GetChannelMemberAsync(channelId, userId, ct);
    public Task<IReadOnlyList<ChannelMember>> GetChannelMembersForUserAsync(string userId, string teamId, CancellationToken ct = default) => _channels.GetChannelMembersForUserAsync(userId, teamId, ct);
    public Task<ChannelStats> GetChannelStatsAsync(string channelId, CancellationToken ct = default) => _channels.GetChannelStatsAsync(channelId, ct);
    public Task<IReadOnlyList<Post>> GetPinnedPostsAsync(string channelId, CancellationToken ct = default) => _channels.GetPinnedPostsAsync(channelId, ct);
    public Task UpdateChannelMemberNotifyPropsAsync(string channelId, string userId, ChannelNotifyProps props, CancellationToken ct = default) => _channels.UpdateChannelMemberNotifyPropsAsync(channelId, userId, props, ct);
    public Task UpdateChannelMemberRolesAsync(string channelId, string userId, string roles, CancellationToken ct = default) => _channels.UpdateChannelMemberRolesAsync(channelId, userId, roles, ct);
    public Task ViewChannelAsync(string userId, string channelId, string? prevChannelId = null, CancellationToken ct = default) => _channels.ViewChannelAsync(userId, channelId, prevChannelId, ct);
    public Task<IReadOnlyList<ChannelCategory>> GetSidebarCategoriesAsync(string userId, string teamId, CancellationToken ct = default) => _channels.GetSidebarCategoriesAsync(userId, teamId, ct);
    public Task<ChannelCategory> UpdateSidebarCategoryAsync(string userId, string teamId, string categoryId, ChannelCategory category, CancellationToken ct = default) => _channels.UpdateSidebarCategoryAsync(userId, teamId, categoryId, category, ct);

    // IPostApi
    public Task<Post> CreatePostAsync(Post post, CancellationToken ct = default) => _posts.CreatePostAsync(post, ct);
    public Task<Post> GetPostAsync(string postId, CancellationToken ct = default) => _posts.GetPostAsync(postId, ct);
    public Task<Post> UpdatePostAsync(string postId, Post post, CancellationToken ct = default) => _posts.UpdatePostAsync(postId, post, ct);
    public Task<Post> PatchPostAsync(string postId, Dictionary<string, object> patch, CancellationToken ct = default) => _posts.PatchPostAsync(postId, patch, ct);
    public Task DeletePostAsync(string postId, CancellationToken ct = default) => _posts.DeletePostAsync(postId, ct);
    public Task<PostList> GetChannelPostsAsync(string channelId, int page = 0, int perPage = 60, string? before = null, string? after = null, bool includeDeleted = false, long? since = null, CancellationToken ct = default) => _posts.GetChannelPostsAsync(channelId, page, perPage, before, after, includeDeleted, since, ct);
    public Task<PostList> GetPostThreadAsync(string postId, string? fromPost = null, bool fromCreateAt = false, int perPage = 60, CancellationToken ct = default) => _posts.GetPostThreadAsync(postId, fromPost, fromCreateAt, perPage, ct);
    public Task PinPostAsync(string postId, CancellationToken ct = default) => _posts.PinPostAsync(postId, ct);
    public Task UnpinPostAsync(string postId, CancellationToken ct = default) => _posts.UnpinPostAsync(postId, ct);
    public Task<PostList> SearchPostsAsync(string teamId, string terms, bool isOrSearch = false, CancellationToken ct = default) => _posts.SearchPostsAsync(teamId, terms, isOrSearch, ct);
    public Task<PostList> GetFlaggedPostsAsync(string userId, int page = 0, int perPage = 60, string? channelId = null, string? teamId = null, CancellationToken ct = default) => _posts.GetFlaggedPostsAsync(userId, page, perPage, channelId, teamId, ct);
    public Task<Post> DoPostActionAsync(string postId, string actionId, CancellationToken ct = default) => _posts.DoPostActionAsync(postId, actionId, ct);
    public Task AcknowledgePostAsync(string postId, CancellationToken ct = default) => _posts.AcknowledgePostAsync(postId, ct);
    public Task UnacknowledgePostAsync(string postId, CancellationToken ct = default) => _posts.UnacknowledgePostAsync(postId, ct);

    // IFileApi
    public Task<FileUploadResponse> UploadFileAsync(string channelId, string fileName, Stream content, Action<int>? onProgress = null, CancellationToken ct = default) => _files.UploadFileAsync(channelId, fileName, content, onProgress, ct);
    public Task<byte[]> GetFileAsync(string fileId, CancellationToken ct = default) => _files.GetFileAsync(fileId, ct);
    public Task<Stream> GetFileStreamAsync(string fileId, CancellationToken ct = default) => _files.GetFileStreamAsync(fileId, ct);
    public Task<Models.Files.FileInfo> GetFileInfoAsync(string fileId, CancellationToken ct = default) => _files.GetFileInfoAsync(fileId, ct);
    public Task<byte[]> GetFileThumbnailAsync(string fileId, CancellationToken ct = default) => _files.GetFileThumbnailAsync(fileId, ct);
    public Task<byte[]> GetFilePreviewAsync(string fileId, CancellationToken ct = default) => _files.GetFilePreviewAsync(fileId, ct);
    public Task<string> GetFileLinkAsync(string fileId, CancellationToken ct = default) => _files.GetFileLinkAsync(fileId, ct);

    // IReactionApi
    public Task<Reaction> SaveReactionAsync(Reaction reaction, CancellationToken ct = default) => _reactions.SaveReactionAsync(reaction, ct);
    public Task DeleteReactionAsync(string userId, string postId, string emojiName, CancellationToken ct = default) => _reactions.DeleteReactionAsync(userId, postId, emojiName, ct);
    public Task<IReadOnlyList<Reaction>> GetReactionsAsync(string postId, CancellationToken ct = default) => _reactions.GetReactionsAsync(postId, ct);

    // IEmojiApi
    public Task<PagedResult<CustomEmoji>> GetCustomEmojisAsync(int page = 0, int perPage = 60, string? sort = null, CancellationToken ct = default) => _emojis.GetCustomEmojisAsync(page, perPage, sort, ct);
    public Task<CustomEmoji> CreateCustomEmojiAsync(string name, Stream image, CancellationToken ct = default) => _emojis.CreateCustomEmojiAsync(name, image, ct);
    public Task DeleteCustomEmojiAsync(string emojiId, CancellationToken ct = default) => _emojis.DeleteCustomEmojiAsync(emojiId, ct);
    public Task<CustomEmoji> GetCustomEmojiAsync(string emojiId, CancellationToken ct = default) => _emojis.GetCustomEmojiAsync(emojiId, ct);
    public Task<CustomEmoji> GetCustomEmojiByNameAsync(string name, CancellationToken ct = default) => _emojis.GetCustomEmojiByNameAsync(name, ct);
    public Task<byte[]> GetCustomEmojiImageAsync(string emojiId, CancellationToken ct = default) => _emojis.GetCustomEmojiImageAsync(emojiId, ct);
    public Task<IReadOnlyList<CustomEmoji>> SearchCustomEmojisAsync(string term, CancellationToken ct = default) => _emojis.SearchCustomEmojisAsync(term, ct);
    public Task<IReadOnlyList<CustomEmoji>> AutocompleteCustomEmojisAsync(string name, CancellationToken ct = default) => _emojis.AutocompleteCustomEmojisAsync(name, ct);

    // IPreferenceApi
    public Task<IReadOnlyList<Preference>> GetPreferencesAsync(string userId, CancellationToken ct = default) => _preferences.GetPreferencesAsync(userId, ct);
    public Task SavePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default) => _preferences.SavePreferencesAsync(userId, preferences, ct);
    public Task DeletePreferencesAsync(string userId, IEnumerable<Preference> preferences, CancellationToken ct = default) => _preferences.DeletePreferencesAsync(userId, preferences, ct);
    public Task<IReadOnlyList<Preference>> GetPreferencesByCategoryAsync(string userId, string category, CancellationToken ct = default) => _preferences.GetPreferencesByCategoryAsync(userId, category, ct);
    public Task<Preference> GetPreferenceAsync(string userId, string category, string name, CancellationToken ct = default) => _preferences.GetPreferenceAsync(userId, category, name, ct);

    // IThreadApi
    public Task<ThreadResponse> GetUserThreadsAsync(string userId, string teamId, int page = 0, int perPage = 25, bool extended = false, bool deleted = false, long? since = null, CancellationToken ct = default) => _threads.GetUserThreadsAsync(userId, teamId, page, perPage, extended, deleted, since, ct);
    public Task<UserThread> GetUserThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default) => _threads.GetUserThreadAsync(userId, teamId, threadId, ct);
    public Task FollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default) => _threads.FollowThreadAsync(userId, teamId, threadId, ct);
    public Task UnfollowThreadAsync(string userId, string teamId, string threadId, CancellationToken ct = default) => _threads.UnfollowThreadAsync(userId, teamId, threadId, ct);
    public Task MarkThreadAsReadAsync(string userId, string teamId, string threadId, long timestamp, CancellationToken ct = default) => _threads.MarkThreadAsReadAsync(userId, teamId, threadId, timestamp, ct);
    public Task MarkAllThreadsAsReadAsync(string userId, string teamId, CancellationToken ct = default) => _threads.MarkAllThreadsAsReadAsync(userId, teamId, ct);

    // IRoleApi
    public Task<Role> GetRoleAsync(string roleId, CancellationToken ct = default) => _roles.GetRoleAsync(roleId, ct);
    public Task<Role> GetRoleByNameAsync(string name, CancellationToken ct = default) => _roles.GetRoleByNameAsync(name, ct);
    public Task<IReadOnlyList<Role>> GetRolesByNamesAsync(IEnumerable<string> names, CancellationToken ct = default) => _roles.GetRolesByNamesAsync(names, ct);
    public Task<Role> PatchRoleAsync(string roleId, Dictionary<string, object> patch, CancellationToken ct = default) => _roles.PatchRoleAsync(roleId, patch, ct);

    // IGroupApi
    public Task<PagedResult<Group>> GetGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _groups.GetGroupsAsync(page, perPage, ct);
    public Task<Group> GetGroupAsync(string groupId, CancellationToken ct = default) => _groups.GetGroupAsync(groupId, ct);
    public Task<PagedResult<GroupMember>> GetGroupMembersAsync(string groupId, int page = 0, int perPage = 60, CancellationToken ct = default) => _groups.GetGroupMembersAsync(groupId, page, perPage, ct);
    public Task<GroupStats> GetGroupStatsAsync(string groupId, CancellationToken ct = default) => _groups.GetGroupStatsAsync(groupId, ct);
    public Task<IReadOnlyList<Group>> GetGroupsByChannelAsync(string channelId, CancellationToken ct = default) => _groups.GetGroupsByChannelAsync(channelId, ct);
    public Task<IReadOnlyList<Group>> GetGroupsByTeamAsync(string teamId, CancellationToken ct = default) => _groups.GetGroupsByTeamAsync(teamId, ct);

    // IWebhookApi
    public Task<IncomingWebhook> CreateIncomingWebhookAsync(IncomingWebhook webhook, CancellationToken ct = default) => _webhooks.CreateIncomingWebhookAsync(webhook, ct);
    public Task<PagedResult<IncomingWebhook>> GetIncomingWebhooksAsync(string? teamId = null, int page = 0, int perPage = 60, CancellationToken ct = default) => _webhooks.GetIncomingWebhooksAsync(teamId, page, perPage, ct);
    public Task<IncomingWebhook> GetIncomingWebhookAsync(string hookId, CancellationToken ct = default) => _webhooks.GetIncomingWebhookAsync(hookId, ct);
    public Task<IncomingWebhook> UpdateIncomingWebhookAsync(string hookId, IncomingWebhook webhook, CancellationToken ct = default) => _webhooks.UpdateIncomingWebhookAsync(hookId, webhook, ct);
    public Task DeleteIncomingWebhookAsync(string hookId, CancellationToken ct = default) => _webhooks.DeleteIncomingWebhookAsync(hookId, ct);
    public Task<OutgoingWebhook> CreateOutgoingWebhookAsync(OutgoingWebhook webhook, CancellationToken ct = default) => _webhooks.CreateOutgoingWebhookAsync(webhook, ct);
    public Task<PagedResult<OutgoingWebhook>> GetOutgoingWebhooksAsync(string? teamId = null, string? channelId = null, int page = 0, int perPage = 60, CancellationToken ct = default) => _webhooks.GetOutgoingWebhooksAsync(teamId, channelId, page, perPage, ct);
    public Task<OutgoingWebhook> GetOutgoingWebhookAsync(string hookId, CancellationToken ct = default) => _webhooks.GetOutgoingWebhookAsync(hookId, ct);
    public Task<OutgoingWebhook> UpdateOutgoingWebhookAsync(string hookId, OutgoingWebhook webhook, CancellationToken ct = default) => _webhooks.UpdateOutgoingWebhookAsync(hookId, webhook, ct);
    public Task DeleteOutgoingWebhookAsync(string hookId, CancellationToken ct = default) => _webhooks.DeleteOutgoingWebhookAsync(hookId, ct);
    public Task<OutgoingWebhook> RegenOutgoingWebhookTokenAsync(string hookId, CancellationToken ct = default) => _webhooks.RegenOutgoingWebhookTokenAsync(hookId, ct);

    // ICommandApi
    public Task<CommandResponse> ExecuteCommandAsync(string channelId, string command, CancellationToken ct = default) => _commands.ExecuteCommandAsync(channelId, command, ct);
    public Task<IReadOnlyList<SlashCommand>> ListCommandsAsync(string teamId, bool customOnly = false, CancellationToken ct = default) => _commands.ListCommandsAsync(teamId, customOnly, ct);
    public Task<SlashCommand> CreateCommandAsync(SlashCommand command, CancellationToken ct = default) => _commands.CreateCommandAsync(command, ct);
    public Task<SlashCommand> UpdateCommandAsync(string commandId, SlashCommand command, CancellationToken ct = default) => _commands.UpdateCommandAsync(commandId, command, ct);
    public Task DeleteCommandAsync(string commandId, CancellationToken ct = default) => _commands.DeleteCommandAsync(commandId, ct);

    // IBotApi
    public Task<Bot> CreateBotAsync(Bot bot, CancellationToken ct = default) => _bots.CreateBotAsync(bot, ct);
    public Task<Bot> GetBotAsync(string botUserId, CancellationToken ct = default) => _bots.GetBotAsync(botUserId, ct);
    public Task<PagedResult<Bot>> GetBotsAsync(int page = 0, int perPage = 60, bool includeDeleted = false, CancellationToken ct = default) => _bots.GetBotsAsync(page, perPage, includeDeleted, ct);
    public Task<Bot> PatchBotAsync(string botUserId, BotPatch patch, CancellationToken ct = default) => _bots.PatchBotAsync(botUserId, patch, ct);
    public Task<Bot> DisableBotAsync(string botUserId, CancellationToken ct = default) => _bots.DisableBotAsync(botUserId, ct);
    public Task<Bot> EnableBotAsync(string botUserId, CancellationToken ct = default) => _bots.EnableBotAsync(botUserId, ct);
    public Task<Bot> AssignBotAsync(string botUserId, string newOwnerId, CancellationToken ct = default) => _bots.AssignBotAsync(botUserId, newOwnerId, ct);
    public Task<byte[]> GetBotIconAsync(string botUserId, CancellationToken ct = default) => _bots.GetBotIconAsync(botUserId, ct);
    public Task SetBotIconAsync(string botUserId, Stream icon, CancellationToken ct = default) => _bots.SetBotIconAsync(botUserId, icon, ct);
    public Task DeleteBotIconAsync(string botUserId, CancellationToken ct = default) => _bots.DeleteBotIconAsync(botUserId, ct);

    // IOAuthApi
    public Task<PagedResult<OAuthApp>> GetOAuthAppsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _oauth.GetOAuthAppsAsync(page, perPage, ct);
    public Task<OAuthApp> CreateOAuthAppAsync(OAuthApp app, CancellationToken ct = default) => _oauth.CreateOAuthAppAsync(app, ct);
    public Task<OAuthApp> GetOAuthAppAsync(string appId, CancellationToken ct = default) => _oauth.GetOAuthAppAsync(appId, ct);
    public Task<OAuthApp> UpdateOAuthAppAsync(string appId, OAuthApp app, CancellationToken ct = default) => _oauth.UpdateOAuthAppAsync(appId, app, ct);
    public Task DeleteOAuthAppAsync(string appId, CancellationToken ct = default) => _oauth.DeleteOAuthAppAsync(appId, ct);
    public Task<OAuthApp> RegenerateOAuthAppSecretAsync(string appId, CancellationToken ct = default) => _oauth.RegenerateOAuthAppSecretAsync(appId, ct);

    // ISystemApi
    public Task<Dictionary<string, object>> GetConfigAsync(CancellationToken ct = default) => _system.GetConfigAsync(ct);
    public Task<Dictionary<string, object>> UpdateConfigAsync(Dictionary<string, object> config, CancellationToken ct = default) => _system.UpdateConfigAsync(config, ct);
    public Task ReloadConfigAsync(CancellationToken ct = default) => _system.ReloadConfigAsync(ct);
    public Task<Dictionary<string, string>> GetClientConfigAsync(CancellationToken ct = default) => _system.GetClientConfigAsync(ct);
    public Task<bool> PingAsync(CancellationToken ct = default) => _system.PingAsync(ct);
    public Task<ServerLicense?> GetLicenseAsync(CancellationToken ct = default) => _system.GetLicenseAsync(ct);
    public Task<Dictionary<string, string>> GetClientLicenseAsync(CancellationToken ct = default) => _system.GetClientLicenseAsync(ct);
    public Task<Dictionary<string, object>> GetAnalyticsAsync(string? name = null, string? teamId = null, CancellationToken ct = default) => _system.GetAnalyticsAsync(name, teamId, ct);
    public Task<IReadOnlyList<string>> GetLogsAsync(int page = 0, int perPage = 10000, CancellationToken ct = default) => _system.GetLogsAsync(page, perPage, ct);
    public Task<IReadOnlyList<AuditEntry>> GetAuditsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _system.GetAuditsAsync(page, perPage, ct);
    public Task InvalidateCachesAsync(CancellationToken ct = default) => _system.InvalidateCachesAsync(ct);
    public Task RecycleDatabaseConnectionsAsync(CancellationToken ct = default) => _system.RecycleDatabaseConnectionsAsync(ct);
    public Task TestEmailAsync(CancellationToken ct = default) => _system.TestEmailAsync(ct);
    public Task TestSiteUrlAsync(string siteUrl, CancellationToken ct = default) => _system.TestSiteUrlAsync(siteUrl, ct);
    public Task<ServerInfo> GetServerInfoAsync(CancellationToken ct = default) => _system.GetServerInfoAsync(ct);

    // IComplianceApi
    public Task<ComplianceReport> CreateComplianceReportAsync(ComplianceReport report, CancellationToken ct = default) => _compliance.CreateComplianceReportAsync(report, ct);
    public Task<PagedResult<ComplianceReport>> GetComplianceReportsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _compliance.GetComplianceReportsAsync(page, perPage, ct);
    public Task<ComplianceReport> GetComplianceReportAsync(string reportId, CancellationToken ct = default) => _compliance.GetComplianceReportAsync(reportId, ct);
    public Task<byte[]> DownloadComplianceReportAsync(string reportId, CancellationToken ct = default) => _compliance.DownloadComplianceReportAsync(reportId, ct);

    // IDataRetentionApi
    public Task<DataRetentionPolicy> GetDataRetentionPolicyAsync(CancellationToken ct = default) => _dataRetention.GetDataRetentionPolicyAsync(ct);
    public Task<PagedResult<DataRetentionPolicy>> GetDataRetentionPoliciesAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _dataRetention.GetDataRetentionPoliciesAsync(page, perPage, ct);

    // IPluginApi
    public Task<IReadOnlyList<PluginManifest>> GetPluginsAsync(CancellationToken ct = default) => _plugins.GetPluginsAsync(ct);
    public Task<PluginManifest> InstallPluginAsync(Stream plugin, bool force = false, CancellationToken ct = default) => _plugins.InstallPluginAsync(plugin, force, ct);
    public Task RemovePluginAsync(string pluginId, CancellationToken ct = default) => _plugins.RemovePluginAsync(pluginId, ct);
    public Task EnablePluginAsync(string pluginId, CancellationToken ct = default) => _plugins.EnablePluginAsync(pluginId, ct);
    public Task DisablePluginAsync(string pluginId, CancellationToken ct = default) => _plugins.DisablePluginAsync(pluginId, ct);
    public Task<IReadOnlyList<PluginStatus>> GetPluginStatusesAsync(CancellationToken ct = default) => _plugins.GetPluginStatusesAsync(ct);
    public Task<IReadOnlyList<PluginManifest>> GetMarketplacePluginsAsync(CancellationToken ct = default) => _plugins.GetMarketplacePluginsAsync(ct);

    // IJobApi
    public Task<PagedResult<Job>> GetJobsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _jobs.GetJobsAsync(page, perPage, ct);
    public Task<Job> GetJobAsync(string jobId, CancellationToken ct = default) => _jobs.GetJobAsync(jobId, ct);
    public Task<Job> CreateJobAsync(Job job, CancellationToken ct = default) => _jobs.CreateJobAsync(job, ct);
    public Task CancelJobAsync(string jobId, CancellationToken ct = default) => _jobs.CancelJobAsync(jobId, ct);
    public Task<PagedResult<Job>> GetJobsByTypeAsync(string type, int page = 0, int perPage = 60, CancellationToken ct = default) => _jobs.GetJobsByTypeAsync(type, page, perPage, ct);

    // ILdapApi
    public Task SyncLdapAsync(CancellationToken ct = default) => _ldap.SyncLdapAsync(ct);
    public Task TestLdapAsync(CancellationToken ct = default) => _ldap.TestLdapAsync(ct);
    public Task<IReadOnlyList<Group>> GetLdapGroupsAsync(int page = 0, int perPage = 60, CancellationToken ct = default) => _ldap.GetLdapGroupsAsync(page, perPage, ct);

    // ISamlApi
    public Task<string> GetSamlMetadataAsync(CancellationToken ct = default) => _saml.GetSamlMetadataAsync(ct);
    public Task UploadSamlCertificateAsync(string certType, Stream certificate, CancellationToken ct = default) => _saml.UploadSamlCertificateAsync(certType, certificate, ct);
    public Task DeleteSamlCertificateAsync(string certType, CancellationToken ct = default) => _saml.DeleteSamlCertificateAsync(certType, ct);

    // IElasticsearchApi
    public Task TestElasticsearchAsync(CancellationToken ct = default) => _elasticsearch.TestElasticsearchAsync(ct);
    public Task PurgeElasticsearchIndexesAsync(CancellationToken ct = default) => _elasticsearch.PurgeElasticsearchIndexesAsync(ct);

    // IBookmarkApi
    public Task<IReadOnlyList<ChannelBookmark>> GetChannelBookmarksAsync(string channelId, CancellationToken ct = default) => _bookmarks.GetChannelBookmarksAsync(channelId, ct);
    public Task<ChannelBookmark> CreateChannelBookmarkAsync(string channelId, ChannelBookmark bookmark, CancellationToken ct = default) => _bookmarks.CreateChannelBookmarkAsync(channelId, bookmark, ct);
    public Task<ChannelBookmark> UpdateChannelBookmarkAsync(string channelId, string bookmarkId, ChannelBookmark bookmark, CancellationToken ct = default) => _bookmarks.UpdateChannelBookmarkAsync(channelId, bookmarkId, bookmark, ct);
    public Task DeleteChannelBookmarkAsync(string channelId, string bookmarkId, CancellationToken ct = default) => _bookmarks.DeleteChannelBookmarkAsync(channelId, bookmarkId, ct);
    public Task UpdateChannelBookmarkSortOrderAsync(string channelId, IEnumerable<string> bookmarkIds, CancellationToken ct = default) => _bookmarks.UpdateChannelBookmarkSortOrderAsync(channelId, bookmarkIds, ct);

    // IImportExportApi
    public Task<IReadOnlyList<Dictionary<string, object>>> GetExportsAsync(CancellationToken ct = default) => _importExport.GetExportsAsync(ct);
    public Task CreateExportAsync(CancellationToken ct = default) => _importExport.CreateExportAsync(ct);
    public Task<byte[]> DownloadExportAsync(string exportName, CancellationToken ct = default) => _importExport.DownloadExportAsync(exportName, ct);
    public Task DeleteExportAsync(string exportName, CancellationToken ct = default) => _importExport.DeleteExportAsync(exportName, ct);
}
