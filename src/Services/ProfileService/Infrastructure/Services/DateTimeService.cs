using System;
using Portfolio.Application.Common.Interfaces;

namespace Portfolio.ProfileService.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}