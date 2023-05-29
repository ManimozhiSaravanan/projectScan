using Microsoft.Build.Framework;

namespace BAApp.Model
{
    public class UserAccountService
    {
        private List<UserAccount> _users;
        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount { UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserAccount { UserName = "admin1" ,Password = "admin1", Role = "User" }
            };
        }
        public UserAccount? GetByUserName (string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
