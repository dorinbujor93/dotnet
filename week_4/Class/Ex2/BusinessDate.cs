#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ex2
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public BusinessDate(int year, int month, int date)
        {
            Day = date;
            Month = month;
            Year = year;
        }

        public BusinessDate(DateTime time)
        {
            Year = time.Year;
            Month = time.Month;
            Day = time.Day;
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (String.IsNullOrEmpty(format)) format = "DDD";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "D":
                    return Day.ToString();
                case "DD":
                    return Day + " " + Month;
                case "DDD":
                    return Day + " " + Month + " " + Year;
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        public bool Equals(BusinessDate other)
        {
            return Equals(this, other);
        }

        public static BusinessDate ParseFromIso8601String(string isoString)
        {
            string[] components = isoString.Split("-");

            return new BusinessDate(int.Parse(components[0]), int.Parse(components[1]), int.Parse(components[2]));

        }


        public int CompareTo(BusinessDate other)
        {
            var thisTime =  new DateTime(Year, Month , Day);
            var otherTime = new DateTime(other.Year, other.Month, other.Day);

            return DateTime.Compare(thisTime, otherTime);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            string[] components = reader.GetAttribute("BusinessDate").Split("-");

            Year = int.Parse(components[0]);
            Month = int.Parse(components[1]);
            Day = int.Parse(components[2]);

        }
        public static bool operator ==(BusinessDate a, BusinessDate b)
        {
            return BusinessDate.Equals(a, b);
        }

        public static bool operator !=(BusinessDate a, BusinessDate b)
        {
            return !BusinessDate.Equals(a, b);
        }


        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("BusinessDate", this.ToString("DDD", new CultureInfo("en-us")));
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Day, Month, Year);
        }

    }
}
