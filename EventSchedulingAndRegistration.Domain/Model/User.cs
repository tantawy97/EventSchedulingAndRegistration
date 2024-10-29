using EventSchedulingAndRegistration.Domain.Abstract;
using EventSchedulingAndRegistration.Domain.ValueObject;
using System.Xml.Linq;


namespace EventSchedulingAndRegistration.Domain.Model
{
    public class User : Entity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public PersonalInformation PersonalInformation { get; set; } = default!;
        private readonly List<EventRegistration> _eventRegistrations = new();
        public IReadOnlyList<EventRegistration> EventRegistrations => _eventRegistrations.AsReadOnly();

        public User Create(string name,string email, PersonalInformation personalInformation)
        {
            var user = new User
            {
                Name = name,
                Email = email,
                PersonalInformation = personalInformation
            };
            return user;

        }
        //public void Update(string name,string email, PersonalInformation personalInformation)
        //{
        //    var user = new User
        //    {
        //        Name = name,
        //        Email = email,
        //        PersonalInformation = personalInformation
        //    };
        //}

    }
}
