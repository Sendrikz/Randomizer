using RandomizerLib.Model;
using RandomizerLib.Populator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RandomizerLib
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {

        UserDao userDao = new UserDao();
        UserDtoToUserPopulator userDtoToUser = new UserDtoToUserPopulator();
        UserToUserDtoPopulator userToUserDto = new UserToUserDtoPopulator();

        public User GetUser(string login)
        {
         /*   
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Name = "Olha";
            user.Surname = "Yurieva";
            user.Email = "yuryeva.olga@gmail.com";
            user.Password = "pass";
            user.Login = "sasha";
            user.LastAccess = DateTime.Now;

            RandomizerContext context = new RandomizerContext();
            context.Users.Add(user);

            context.SaveChanges();
            */

            return userDao.GetUserByLogin(login); //string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void RegisterUser(UserDto user)
        {
            User userToAdd = userDtoToUser.populate(user);

            userDao.CreateUser(userToAdd);

            // return userToUserDto.populate(registrated);
        }
    }
}
