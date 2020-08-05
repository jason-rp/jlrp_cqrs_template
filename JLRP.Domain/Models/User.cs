using System;

namespace JLRP.Domain.Models
{
    public class User : ModelBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public User(string name, string email, string address, int age, string phoneNumber)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Address = address;
            Age = age;
            PhoneNumber = phoneNumber;
        }
    }
}
