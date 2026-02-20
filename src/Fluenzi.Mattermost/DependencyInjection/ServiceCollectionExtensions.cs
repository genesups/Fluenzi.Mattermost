using Fluenzi.Mattermost.Client.Auth;
using Fluenzi.Mattermost.Client.Internal;
using Fluenzi.Mattermost.Client.Services;
using Fluenzi.Mattermost.Interfaces.Auth;
using Fluenzi.Mattermost.Interfaces.Client;
using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Interfaces.WebSocket;
using Fluenzi.Mattermost.Store;
using Fluenzi.Mattermost.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Fluenzi.Mattermost.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFluenziMattermost(
        this IServiceCollection services,
        Action<MattermostOptions> configure)
    {
        var options = new MattermostOptions();        
        configure(options);

        services.AddSingleton(options);
        services.AddSingleton(options.WebSocket);

        // HttpClient
        services.AddHttpClient("FluenziMattermost", client =>
        {
           if (!string.IsNullOrWhiteSpace(options.ServerUrl))
           {
               client.BaseAddress = new Uri(options.ServerUrl);
           }
            client.Timeout = options.DefaultTimeout;
        });

        // Auth
        services.AddSingleton<CredentialAuthProvider>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            return new CredentialAuthProvider(factory.CreateClient("FluenziMattermost"));
        });
        services.AddSingleton<IAuthProvider>(sp => sp.GetRequiredService<CredentialAuthProvider>());

        // API
        services.AddSingleton<ApiRequestHandler>(sp =>
        {
            var factory = sp.GetRequiredService<IHttpClientFactory>();
            var auth = sp.GetRequiredService<IAuthProvider>();
            return new ApiRequestHandler(factory.CreateClient("FluenziMattermost"), auth);
        });

        services.AddSingleton<MattermostApiClient>();
        services.AddSingleton<IMattermostApiClient>(sp => sp.GetRequiredService<MattermostApiClient>());

        // Individual API clients (for direct injection if needed)
        services.AddSingleton<IUserApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ITeamApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IChannelApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IPostApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IFileApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IReactionApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IEmojiApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IPreferenceApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IThreadApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IRoleApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IGroupApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IWebhookApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ICommandApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IBotApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IOAuthApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ISystemApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IComplianceApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IDataRetentionApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IPluginApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IJobApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ILdapApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ISamlApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IElasticsearchApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IBookmarkApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IImportExportApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ISchemeApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IClusterApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IBrandApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IOpenGraphApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IBleveApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IUploadApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<ISharedChannelApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IIPFilterApi>(sp => sp.GetRequiredService<IMattermostApiClient>());
        services.AddSingleton<IOutgoingOAuthApi>(sp => sp.GetRequiredService<IMattermostApiClient>());

        // WebSocket
        services.AddSingleton<MattermostWebSocketClient>();
        services.AddSingleton<IMattermostWebSocket>(sp => sp.GetRequiredService<MattermostWebSocketClient>());
        services.AddSingleton<IWebSocketEventStream>(sp => sp.GetRequiredService<MattermostWebSocketClient>());

        // Store
        services.AddSingleton<MattermostStore>();
        services.AddSingleton<IMattermostStore>(sp => sp.GetRequiredService<MattermostStore>());
        services.AddSingleton<IUserStore>(sp => sp.GetRequiredService<IMattermostStore>().Users);
        services.AddSingleton<ITeamStore>(sp => sp.GetRequiredService<IMattermostStore>().Teams);
        services.AddSingleton<IChannelStore>(sp => sp.GetRequiredService<IMattermostStore>().Channels);
        services.AddSingleton<IPostStore>(sp => sp.GetRequiredService<IMattermostStore>().Posts);
        services.AddSingleton<IThreadStore>(sp => sp.GetRequiredService<IMattermostStore>().Threads);
        services.AddSingleton<IPreferenceStore>(sp => sp.GetRequiredService<IMattermostStore>().Preferences);
        services.AddSingleton<IEmojiStore>(sp => sp.GetRequiredService<IMattermostStore>().Emojis);
        services.AddSingleton<IReactionStore>(sp => sp.GetRequiredService<IMattermostStore>().Reactions);
        services.AddSingleton<IStatusStore>(sp => sp.GetRequiredService<IMattermostStore>().Statuses);
        services.AddSingleton<ITypingStore>(sp => sp.GetRequiredService<IMattermostStore>().Typing);

        // StoreReducer
        services.AddSingleton<StoreReducer>();

        // Session facade
        services.AddSingleton<MattermostSession>();

        return services;
    }
}
