# Mattermost XAF Blazor Prototype

This folder contains a prototype DevExpress XAF Blazor application that demonstrates how to use `Mattermost.NET` with XPO.

The goal of the prototype is to authenticate users using their Mattermost credentials and display their recent messages in a chat-like list view.

The project references DevExpress XAF packages and the `Mattermost` library from this repository. It is intended for educational purposes and is not a production-ready solution.

## Prerequisites

- .NET 8 SDK or newer
- DevExpress NuGet feed configured (required for XAF packages)
- A valid Mattermost account with either username/password or a personal access token

## Running the prototype

1. Configure the DevExpress NuGet feed and obtain the required DevExpress packages.
2. Provide the Mattermost server URL and user credentials in `appsettings.json`.
3. Build and run the application using the `dotnet` CLI:
   ```bash
   dotnet run --project Mattermost.XafBlazorPrototype.csproj
   ```

## Limitations

This example is intentionally simplified:

- It stores messages in memory only.
- The chat layout is minimal and meant purely for demonstration.
- Error handling and security features are omitted for brevity.

