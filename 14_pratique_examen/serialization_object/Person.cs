using System;

namespace serialization_object
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => LastName + ", " + FirstName; }
        public DateTime Birthday { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}