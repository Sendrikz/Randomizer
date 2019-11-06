using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Model
{
    class Request
    {
        public Guid Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public int Count { get; set; }
        public DateTime Time { get; set; }

        public User ReqUser { get; set; }
    }
}
