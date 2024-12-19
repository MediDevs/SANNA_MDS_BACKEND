using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.Settings
{
    public interface IJwtSettings
    {
        public string Key { get; }
        public string Issuer { get; }
        public string Audience { get; }
        public double DurationInMinutes { get; }
        public int RememberMeDurationInHours { get; }
    }
}
