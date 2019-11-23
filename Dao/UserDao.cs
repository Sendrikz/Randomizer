using RandomizerLib.Exception;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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
    }
}
