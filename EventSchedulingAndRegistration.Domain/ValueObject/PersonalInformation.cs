using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedulingAndRegistration.Domain.ValueObject
{
    public record PersonalInformation
    {
        public string Address { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        private PersonalInformation(string address, string phoneNumber)
        {
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public static PersonalInformation Of(string address, string phoneNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(address);
            ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);

            return new PersonalInformation(address, phoneNumber);
        }
    }
}
