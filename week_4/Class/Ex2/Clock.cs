using System;

namespace Ex2
{
    internal class Clock : IClock
    {
        public DateTime Now { get; }
        public DateTime UtcNow { get; }
        public BusinessDate Today { get; }

        public Clock(string time)
        {
            Now = DateTime.Parse(time);
            UtcNow = Now.ToUniversalTime();
            Today = new BusinessDate(Now);
        }
    }
}
