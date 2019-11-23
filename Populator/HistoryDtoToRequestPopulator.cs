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
    public class HistoryDtoToRequestPopulator
    {
        public Request populate(HistoryDto history)
        {
            return new RequestBuilder()
                .Count(history.Count)
                .From(history.From)
                .To(history.To)
                .SetUpTime()
                .SetUpGuid()
                .create();
        }
    }
}
