using System;
using System.Collections.Generic;
using System.Text;

namespace serialization_object
{
    public class Classroom
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Classroom()
        {
            initClass();
        }

        private void initClass()
        {
            Students = new List<Student>
            {
                new Student{ StudentId = 1000, RegistrationNumber = "2014672", FirstName = "Jeanette", LastName = "Weber" },
                new Student{ StudentId = 1001, RegistrationNumber = "1717683", FirstName = "Teegan", LastName = "Dotson" },
                new Student{ StudentId = 1002, RegistrationNumber = "0876316", FirstName = "Deanna", LastName = "Osborne" },
                new Student{ StudentId = 1003, RegistrationNumber = "1835010", FirstName = "Nola", LastName = "Mcguire" },
                new Student{ StudentId = 1004, RegistrationNumber = "0218682", FirstName = "Constance", LastName = "Bonner" },
                new Student{ StudentId = 1005, RegistrationNumber = "0234916", FirstName = "Willow", LastName = "Schroeder" },
                new Student{ StudentId = 1006, RegistrationNumber = "0631556", FirstName = "Chloe", LastName = "Dillon" },
                new Student{ StudentId = 1007, RegistrationNumber = "0198947", FirstName = "Gil", LastName = "Warren" },
                new Student{ StudentId = 1008, RegistrationNumber = "1005394", FirstName = "James", LastName = "Reed" },
                new Student{ StudentId = 1009, RegistrationNumber = "0882940", FirstName = "Vladimir", LastName = "Burks" },
                new Student{ StudentId = 1010, RegistrationNumber = "1118220", FirstName = "Olympia", LastName = "Wiley" },
                new Student{ StudentId = 1011, RegistrationNumber = "0584799", FirstName = "Julian", LastName = "Navarro" },
                new Student{ StudentId = 1012, RegistrationNumber = "2070004", FirstName = "Chastity", LastName = "Clemons" },
                new Student{ StudentId = 1013, RegistrationNumber = "1466203", FirstName = "Tad", LastName = "Mays" },
                new Student{ StudentId = 1014, RegistrationNumber = "0120992", FirstName = "Orla", LastName = "Morales" },
                new Student{ StudentId = 1015, RegistrationNumber = "1365546", FirstName = "Keely", LastName = "Valenzuela" },
                new Student{ StudentId = 1016, RegistrationNumber = "2102338", FirstName = "Ivor", LastName = "Hahn" },
                new Student{ StudentId = 1017, RegistrationNumber = "1717302", FirstName = "Ignacia", LastName = "Duffy" },
                new Student{ StudentId = 1018, RegistrationNumber = "1349515", FirstName = "Davis", LastName = "Emerson" },
                new Student{ StudentId = 1019, RegistrationNumber = "1027699", FirstName = "Mohammad", LastName = "Schneider" },
                new Student{ StudentId = 1020, RegistrationNumber = "0784667", FirstName = "Raja", LastName = "Mcfarland" },
                new Student{ StudentId = 1021, RegistrationNumber = "0447914", FirstName = "Carter", LastName = "Oneill" },
                new Student{ StudentId = 1022, RegistrationNumber = "1463918", FirstName = "Daniel", LastName = "Cruz" },
                new Student{ StudentId = 1023, RegistrationNumber = "2158979", FirstName = "Cedric", LastName = "Carver" },
                new Student{ StudentId = 1024, RegistrationNumber = "0754054", FirstName = "Kareem", LastName = "Hicks" },
            };
        }
    }
}
