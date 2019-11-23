using RandomizerLib.Builder;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace RandomizerLib
{
    public class UserDao
    {
        RandomizerContext context = new RandomizerContext();

        public User GetUserByLogin(string _login)
        {
            User user = null;

            try
            {
                user = context.Users.Where(s => s.Login == _login).First<User>();

            } catch(InvalidOperationException e)
            {
                throw new System.Exception("There is no user with such login", e);
            } 

            return user;
        }

        public User GetLogined(User user)
        {
            string passwordToCheck = user.Password;
            User findedUser = GetUserByLogin(user.Login);

            if (findedUser.Password.Equals(passwordToCheck))
            {
                UpdateLastAccess(findedUser);
                return findedUser;
            }

            throw new System.Exception("Invalid password");
        }

        public void UpdateLastAccess(User user)
        {
            user.LastAccess = DateTime.Now;
            context.SaveChanges();
        }

        public User CreateUser(User user)
        {
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

        internal ICollection<Request> GetUserHistory(string login)
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
