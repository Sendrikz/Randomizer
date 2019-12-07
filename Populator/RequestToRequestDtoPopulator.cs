using RandomizerLib.Builder;
using RandomizerLib.Dto;
using RandomizerLib.Model;

namespace RandomizerLib.Populator
{
    public class RequestToRequestDtoPopulator
    {
        public RequestDto Populate(Request request)
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
