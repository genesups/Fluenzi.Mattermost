using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace Mattermost.XafBlazorPrototype;

public class ChatMessageService
{
    private readonly MattermostService _service;
    private readonly IXpoDataStoreProvider _dataStoreProvider;

    public ChatMessageService(MattermostService service, IXpoDataStoreProvider dataStoreProvider)
    {
        _service = service;
        _dataStoreProvider = dataStoreProvider;
        _service.MessageReceived += OnMessageReceived;
    }

    public IDataStore DataStore => _dataStoreProvider.DataStore;

    private void OnMessageReceived(object? sender, Mattermost.Events.MessageEventArgs e)
    {
        using var uow = new UnitOfWork(_dataStoreProvider.DataStore);
        var msg = new ChatMessage(uow)
        {
            Text = e.Message.Post.Text ?? string.Empty,
            User = e.Message.UserId ?? string.Empty,
            Created = DateTime.UtcNow
        };
        uow.CommitChanges();
    }
}
