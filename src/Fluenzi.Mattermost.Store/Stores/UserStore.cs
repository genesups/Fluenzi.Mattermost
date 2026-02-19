using Fluenzi.Mattermost.Interfaces.Store;
using Fluenzi.Mattermost.Models.Users;

namespace Fluenzi.Mattermost.Store.Stores;

public class UserStore : EntityStore<string, User>, IUserStore { }
