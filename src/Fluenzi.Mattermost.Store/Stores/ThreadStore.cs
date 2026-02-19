using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Threads;

namespace Fluenzi.Mattermost.Store.Stores;

public class ThreadStore : EntityStore<string, UserThread>, IThreadStore { }
