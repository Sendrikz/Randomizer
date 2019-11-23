using RandomizerLib.Model;
using System;

namespace RandomizerLib.Builder
{
    public class RequestBuilder
    {
        private Request request;
        private UserDao userDao;

        public RequestBuilder()
        {
            request = new Request();
            userDao = new UserDao();
        }

        public RequestBuilder SetUpGuid()
        {
            request.Id = Guid.NewGuid();
            return this;
        }

        public RequestBuilder SetUpTime()
        {
            request.Time = DateTime.Now;
            return this;
        }

        public RequestBuilder SetTime(DateTime time)
        {
            request.Time = time;
            return this;
        }

        public RequestBuilder From(int from)
        {
            request.From = from;
            return this;
        }

        public RequestBuilder To(int to)
        {
            request.To = to;
            return this;
        }

        public RequestBuilder Count(int count)
        {
            request.Count = count;
            return this;
        }

        public RequestBuilder User(string login)
        {
            request.ReqUser = userDao.GetUserByLogin(login);
            return this;
        }

        public Request create()
        {
            return request;
        }
    }
}
