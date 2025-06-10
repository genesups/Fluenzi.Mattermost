using Mattermost;
using Mattermost.Models;
using Microsoft.Extensions.Configuration;

namespace Mattermost.XafBlazorPrototype;

public class MattermostService
{
    private readonly MattermostClient _client;
    private readonly IConfiguration _configuration;

    public MattermostService(IConfiguration configuration)
    {
        _configuration = configuration;
        string server = configuration["Mattermost:Server"] ?? string.Empty;
        _client = new MattermostClient(server);
    }

    public async Task<User> LoginAsync()
    {
        string? token = _configuration["Mattermost:Token"];
        if (!string.IsNullOrEmpty(token))
        {
            return await _client.LoginAsync(token);
        }
        string username = _configuration["Mattermost:Username"] ?? string.Empty;
        string password = _configuration["Mattermost:Password"] ?? string.Empty;
        return await _client.LoginAsync(username, password);
    }

    public Task StartReceivingAsync() => _client.StartReceivingAsync();
    public Task StopReceivingAsync() => _client.StopReceivingAsync();

    public event EventHandler<MessageEventArgs>? MessageReceived
    {
        add => _client.OnMessageReceived += value;
        remove => _client.OnMessageReceived -= value;
    }
}
