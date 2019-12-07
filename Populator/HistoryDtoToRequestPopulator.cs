using RandomizerLib.Builder;
using RandomizerLib.Dto;
using RandomizerLib.Model;

namespace RandomizerLib.Populator
{
    public class HistoryDtoToRequestPopulator
    {
        public Request Populate(HistoryDto history)
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
