using RandomizerLib.Model;
using System.Collections.Generic;

namespace RandomizerLib
{
    public interface UserDao
    {
        User GetUserByLogin(string _login);

        User GetLogined(User user);

        void UpdateLastAccess(User user);

        User CreateUser(User user);

        void SaveHistory(string login, Request request);

        ICollection<Request> GetUserHistory(string login);
    }
}
