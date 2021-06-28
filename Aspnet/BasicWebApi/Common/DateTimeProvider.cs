using System;

namespace BasicWebApi.Common
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() => DateTime.Now;
    }
}