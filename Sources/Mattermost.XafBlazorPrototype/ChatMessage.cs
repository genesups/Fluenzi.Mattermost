using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace Mattermost.XafBlazorPrototype;

[DefaultClassOptions]
public class ChatMessage : BaseObject
{
    public ChatMessage(Session session) : base(session) { }

    private string text = string.Empty;
    public string Text
    {
        get => text;
        set => SetPropertyValue(nameof(Text), ref text, value);
    }

    private string user = string.Empty;
    public string User
    {
        get => user;
        set => SetPropertyValue(nameof(User), ref user, value);
    }

    public DateTime Created { get; set; }
}
