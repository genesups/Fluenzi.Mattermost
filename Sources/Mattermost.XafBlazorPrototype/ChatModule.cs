using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.Persistent.BaseImpl;

namespace Mattermost.XafBlazorPrototype;

public class ChatModule : ModuleBase
{
    public ChatModule()
    {
        AdditionalExportedTypes.Add(typeof(PermissionPolicyUser));
        AdditionalExportedTypes.Add(typeof(PermissionPolicyRole));
        AdditionalExportedTypes.Add(typeof(ChatMessage));
    }

    public override void Setup(XafApplication application)
    {
        base.Setup(application);
    }
}
