using RandomizerLib.Dto;
using System;

namespace RandomizerLib.Builder
{
    class RequestDtoBuilder
    {
        private RequestDto requestDto;

        public RequestDtoBuilder()
        {
            requestDto = new RequestDto();
        }

        public RequestDtoBuilder Time(DateTime time)
        {
            requestDto.Time = time;
            return this;
        }

        public RequestDtoBuilder From(int from)
        {
            requestDto.From = from;
            return this;
        }

        public RequestDtoBuilder To(int to)
        {
            requestDto.To = to;
            return this;
        }

        public RequestDtoBuilder Count(int count)
        {
            requestDto.Count = count;
            return this;
        }

        public RequestDto create()
        {
            return requestDto;
        }
    }
}
