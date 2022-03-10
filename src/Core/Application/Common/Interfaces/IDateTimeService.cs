using System;

namespace Portfolio.Application.Common.Interfaces
{
    public interface IDateTimeService
    {
        public DateTime Now { get; }
    }
}