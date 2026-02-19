namespace Fluenzi.Mattermost.Enums;

/// <summary>
/// Mattermost server job types.
/// </summary>
public enum JobType
{
    DataRetention,
    MessageExport,
    ElasticsearchPostIndexing,
    ElasticsearchPostAggregation,
    BlevePostIndexing,
    LdapSync,
    Migrations,
    Plugins,
    ExpiryNotify,
    ProductNotices,
    ActiveUsers,
    ImportProcess,
    ImportDelete,
    ExportProcess,
    ExportDelete,
    Cloud,
    ResendInvitationEmail,
    ExtractContent,
    LastAccessiblePost,
    LastAccessibleFile,
    UpgradeNotifyAdmin,
    TrialNotifyAdmin,
    PostPersistentNotifications,
    InstallPluginScript,
    HostedPurchaseScreening,
    S3PathMigration,
    CleanupDesktopTokens,
    RefreshPostStats,
}
