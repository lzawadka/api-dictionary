using System;
using api_dictionary.Application.Common.Interfaces;

namespace api_dictionary.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
