using NLog;
using RandomizerLib.Builder;
using RandomizerLib.Model;
using RandomizerLib.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace RandomizerLib.Dao
{
    public class EntityFrameworkUserDao : UserDao
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        
        private RandomizerContext context = new RandomizerContext();
        private EncryptionUtil encryption = new EncryptionUtil();

        public User GetUserByLogin(string login)
        {
            User user = null;

            try
            {
                user = context.Users.Where(s => s.Login == login).First<User>();

            }
            catch (InvalidOperationException e)
            {
                string exceptionMessage = "There is no user with such login";
                logger.Error(exceptionMessage + login);
                throw new System.Exception(exceptionMessage, e);
            }

            return user;
        }

        public User GetLogined(User user)
        {
            string passwordToCheck = encryption.Encrypt(user.Password);
            User findedUser = GetUserByLogin(user.Login);

            if (findedUser.Password.Equals(passwordToCheck))
            {
                UpdateLastAccess(findedUser);
                return findedUser;
            }

            logger.Error("Password does not match for user with login: " + user.Login);
            throw new System.Exception("Invalid password");
        }

        public void UpdateLastAccess(User user)
        {
            user.LastAccess = DateTime.Now;
            context.SaveChanges();
        }

        public User CreateUser(User user)
        {
            user.Password = encryption.Encrypt(user.Password);
            context.Users.Add(user);
            context.SaveChanges();

            return user;

        }

        public void SaveHistory(string login, Request request)
        {
            User user = GetUserByLogin(login);
            user.Requests = new Collection<Request>();
            user.Requests.Add(request);

            context.SaveChanges();

        }

        public ICollection<Request> GetUserHistory(string login)
        {
            var req = context.Requests.Join(
                context.Users,
                r => r.ReqUser.Id,
                u => u.Id,
                (r, u) => new
                {
                    To = r.To,
                    From = r.From,
                    Count = r.Count,
                    Time = r.Time,
                    Login = u.Login
                }).Where(all => all.Login == login).ToList();

            ICollection<Request> requests = new Collection<Request>();

            foreach (var r in req)
                requests.Add(new RequestBuilder().To(r.To).From(r.From).Count(r.Count).SetTime(r.Time).create());

            return requests;
        }
    }
}
