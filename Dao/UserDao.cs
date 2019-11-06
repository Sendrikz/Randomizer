using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib
{
    public class UserDao
    {
        RandomizerContext context = new RandomizerContext();

        public User GetUserByLogin(string _login)
        {
            return context.Users.Where(s => s.Login == _login).FirstOrDefault<User>();
        }

        public User CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();

            return user;
        
        }
    }
}
