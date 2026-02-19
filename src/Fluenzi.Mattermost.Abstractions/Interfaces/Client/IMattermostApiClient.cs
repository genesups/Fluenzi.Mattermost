namespace Fluenzi.Mattermost.Interfaces.Client;

public interface IMattermostApiClient :
    IUserApi, ITeamApi, IChannelApi, IPostApi, IFileApi,
    IReactionApi, IEmojiApi, IPreferenceApi, IThreadApi,
    IRoleApi, IGroupApi, IWebhookApi, ICommandApi,
    IBotApi, IOAuthApi, ISystemApi,
    IComplianceApi, IDataRetentionApi, IPluginApi, IJobApi,
    ILdapApi, ISamlApi, IElasticsearchApi,
    IBookmarkApi, IImportExportApi
{
}
