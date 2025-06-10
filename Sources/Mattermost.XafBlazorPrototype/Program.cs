using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Xpo;
using Mattermost;
using Mattermost.Models;
using Microsoft.Extensions.Configuration;
using Mattermost.XafBlazorPrototype;

var builder = WebApplication.CreateBuilder(args);

// Configure XAF
builder.Services
    .AddXafBlazorApplication<ChatBlazorApplication>(options =>
    {
        options.Modules.Add<ChatModule>();
    })
    .AddXafSecurity(options =>
    {
        options.RoleType = typeof(PermissionPolicyRole);
        options.UserType = typeof(PermissionPolicyUser);
    })
    .AddEntityFrameworkCoreProvider();

builder.Services.AddXpoDefaultDataLayer(options =>
{
    options.ConnectionString = "XpoProvider=InMemoryDataStore";
});

builder.Services.AddScoped<MattermostService>();
builder.Services.AddSingleton<ChatMessageService>();

var app = builder.Build();
app.UseXaf();
app.Run();

// ChatBlazorApplication type
public class ChatBlazorApplication : BlazorApplication { }

