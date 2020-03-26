using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ex2
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }

        BusinessDate Today { get; }
    }

}