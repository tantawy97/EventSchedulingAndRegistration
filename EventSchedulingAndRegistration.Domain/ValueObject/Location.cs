using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;

namespace EventSchedulingAndRegistration.Domain.ValueObject
{
    public class Location
    {
        public string City { get; set; } = default!;
        public string StreetName { get; set; } = default!;

        private Location(string city, string streetName)
        {
            City = city;
            StreetName = streetName;
        }

        public static Location Of(string city, string streetName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(city);
            ArgumentException.ThrowIfNullOrWhiteSpace(streetName);

            return new Location(city, streetName);
        }
    }
}
