using RandomizerLib.Builder;
using RandomizerLib.Dto;
using RandomizerLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerLib.Populator
{
    public class RequestToRequestDtoPopulator
    {
        public RequestDto populate(Request request)
        {
            return new RequestDtoBuilder()
                .Count(request.Count)
                .From(request.From)
                .To(request.To)
                .Time(request.Time)
                .create();
        }
    }
}
