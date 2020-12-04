using demo_json_serialization.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace demo_json_serialization.Services
{
    public class PeopleDataService : IDataService<Person>
    {
        List<Person> data;
        public string Filename { get; set; }

        /// <summary>
        /// Implémentation d'un Singleton avec un type Lazy
        /// Le type Lazy permet de charger la classe seulement au premier
        /// appel d'Instance. Cela permet d'économiser de la mémoire
        /// Remarquez que le constructeur est privé.
        /// </summary>
        private static readonly Lazy<PeopleDataService> lazy = new Lazy<PeopleDataService>(() => new PeopleDataService());
        public static PeopleDataService Instance { get => lazy.Value; }

        private PeopleDataService()
        {
            /// Seulement si c'est une liste fixe!
            /// Autres méthodes si les données viennent de fichier 
            /// ou de base de données
            
            populate();
        }

        private void populate()
        {
            data = new List<Person>
            {
                new Person { FirstName = "Ayanna", LastName = "Vargas", Birthday = DateTime.Parse("1967-12-25"), City = "Pickering", Province = "ON", Email = "purus.in@semvitae.edu", Mobile = "647-142-8014" },
                new Person { FirstName = "Whitney", LastName = "Parks", Birthday = DateTime.Parse("1978-03-24"), City = "Greater Sudbury", Province = "ON", Email = "consectetuer.euismod@adipiscingelit.net", Mobile = "624-767-4994" },
                new Person { FirstName = "Louis", LastName = "Watts", Birthday = DateTime.Parse("1974-07-09"), City = "Fredericton", Province = "NB", Email = "at@gravidamolestie.ca", Mobile = "253-179-3847" },
                new Person { FirstName = "Pamela", LastName = "Knapp", Birthday = DateTime.Parse("1985-03-13"), City = "Mission", Province = "BC", Email = "eget.dictum@Aliquamvulputate.ca", Mobile = "501-312-8343" },
                new Person { FirstName = "Clinton", LastName = "Gallagher", Birthday = DateTime.Parse("1949-11-30"), City = "Scarborough", Province = "ON", Email = "eget@etpede.com", Mobile = "401-455-7531" },
                new Person { FirstName = "Amal", LastName = "Cross", Birthday = DateTime.Parse("1988-06-29"), City = "Parkland County", Province = "AB", Email = "non@idrisus.org", Mobile = "730-688-7173" },
                new Person { FirstName = "Vanna", LastName = "Hyde", Birthday = DateTime.Parse("1967-08-26"), City = "Daly", Province = "MB", Email = "nonummy@augueporttitor.edu", Mobile = "257-875-8962" },
                new Person { FirstName = "Madonna", LastName = "Navarro", Birthday = DateTime.Parse("1971-07-17"), City = "Prince George", Province = "BC", Email = "nascetur.ridiculus.mus@liberomauris.edu", Mobile = "462-515-8993" },
                new Person { FirstName = "Rina", LastName = "Decker", Birthday = DateTime.Parse("1940-12-25"), City = "Hamilton", Province = "ON", Email = "neque.non.quam@risus.co.uk", Mobile = "154-936-9265" },
                new Person { FirstName = "Dustin", LastName = "Cole", Birthday = DateTime.Parse("1990-01-18"), City = "St. Thomas", Province = "ON", Email = "felis@ante.org", Mobile = "349-514-9365" },
                new Person { FirstName = "Kellie", LastName = "Hanson", Birthday = DateTime.Parse("1997-11-30"), City = "Windsor", Province = "ON", Email = "id.ante@lacusEtiambibendum.org", Mobile = "891-670-7963" },
                new Person { FirstName = "Cain", LastName = "Booth", Birthday = DateTime.Parse("1951-11-13"), City = "Rimouski", Province = "QC", Email = "tempus.lorem.fringilla@loremtristiquealiquet.com", Mobile = "467-635-9200" },
                new Person { FirstName = "Todd", LastName = "Christian", Birthday = DateTime.Parse("1940-12-21"), City = "Smoky Lake", Province = "AB", Email = "eget@acsemut.net", Mobile = "956-952-7149" },
                new Person { FirstName = "Hashim", LastName = "Hodge", Birthday = DateTime.Parse("1956-12-20"), City = "Sunset Point", Province = "AB", Email = "in.tempus.eu@pede.net", Mobile = "296-427-2849" },
                new Person { FirstName = "Leah", LastName = "Miller", Birthday = DateTime.Parse("1983-07-11"), City = "Shawinigan", Province = "QC", Email = "imperdiet.non@Vivamussit.com", Mobile = "175-412-9657" },
                new Person { FirstName = "Kenneth", LastName = "Roberts", Birthday = DateTime.Parse("2000-07-02"), City = "Swan Hills", Province = "AB", Email = "orci.quis@Vestibulum.co.uk", Mobile = "990-335-8738" },
                new Person { FirstName = "Carly", LastName = "Christensen", Birthday = DateTime.Parse("1961-05-16"), City = "Legal", Province = "AB", Email = "euismod@sodales.net", Mobile = "463-957-1912" },
                new Person { FirstName = "Malik", LastName = "Compton", Birthday = DateTime.Parse("1997-12-10"), City = "Cap-Rouge", Province = "QC", Email = "eu@lacuspedesagittis.com", Mobile = "165-365-4117" },
                new Person { FirstName = "Victoria", LastName = "King", Birthday = DateTime.Parse("1963-11-26"), City = "Whitchurch-Stouffville", Province = "ON", Email = "cursus.a@parturientmontes.edu", Mobile = "310-470-5590" },
                new Person { FirstName = "James", LastName = "Simon", Birthday = DateTime.Parse("1941-07-11"), City = "Chilliwack", Province = "BC", Email = "bibendum.ullamcorper@arcu.ca", Mobile = "570-950-7912" },
                new Person { FirstName = "Christopher", LastName = "Monroe", Birthday = DateTime.Parse("1944-08-20"), City = "Baie-Comeau", Province = "QC", Email = "iaculis@utodiovel.ca", Mobile = "250-555-4617" },
                new Person { FirstName = "Bradley", LastName = "Ramsey", Birthday = DateTime.Parse("1980-03-07"), City = "Ramara", Province = "ON", Email = "mi@massaSuspendisseeleifend.edu", Mobile = "773-187-5827" },
                new Person { FirstName = "Yoshi", LastName = "West", Birthday = DateTime.Parse("1968-09-26"), City = "Calder", Province = "SK", Email = "sagittis.augue.eu@sedleoCras.ca", Mobile = "571-332-7507" },
                new Person { FirstName = "May", LastName = "Frye", Birthday = DateTime.Parse("1989-11-21"), City = "Whitewater Region Township", Province = "ON", Email = "porttitor.vulputate@atiaculisquis.edu", Mobile = "491-865-6707" },
                new Person { FirstName = "Madeline", LastName = "Mclaughlin", Birthday = DateTime.Parse("1972-07-09"), City = "Edmundston", Province = "NB", Email = "hymenaeos.Mauris@malesuadaaugue.ca", Mobile = "122-178-1426" },
                new Person { FirstName = "Eaton", LastName = "Wilson", Birthday = DateTime.Parse("1946-12-25"), City = "Qualicum Beach", Province = "BC", Email = "malesuada@a.co.uk", Mobile = "460-394-9393" },
                new Person { FirstName = "Scott", LastName = "Simpson", Birthday = DateTime.Parse("1956-03-12"), City = "St. Catharines", Province = "ON", Email = "a.scelerisque@convallisconvallis.ca", Mobile = "739-100-1520" },
                new Person { FirstName = "Jenette", LastName = "Michael", Birthday = DateTime.Parse("1997-11-17"), City = "Fort St. John", Province = "BC", Email = "non@nibhPhasellusnulla.co.uk", Mobile = "386-338-5818" },
                new Person { FirstName = "Idona", LastName = "Humphrey", Birthday = DateTime.Parse("1975-08-01"), City = "Silverton", Province = "BC", Email = "non.leo@magna.co.uk", Mobile = "602-274-7457" },
                new Person { FirstName = "Erin", LastName = "Mcguire", Birthday = DateTime.Parse("1989-04-05"), City = "Coquitlam", Province = "BC", Email = "lorem.sit.amet@nisiAeneaneget.co.uk", Mobile = "840-498-1759" },
                new Person { FirstName = "Cooper", LastName = "Mejia", Birthday = DateTime.Parse("1983-07-27"), City = "Watson Lake", Province = "YT", Email = "dui@dolor.ca", Mobile = "510-433-5623" },
                new Person { FirstName = "Skyler", LastName = "Whitaker", Birthday = DateTime.Parse("1941-07-21"), City = "Kawartha Lakes", Province = "ON", Email = "felis@liberoIntegerin.ca", Mobile = "390-471-7006" },
                new Person { FirstName = "Anastasia", LastName = "Garza", Birthday = DateTime.Parse("1982-03-30"), City = "Collines-de-l'Outaouais", Province = "QC", Email = "sit@gravida.org", Mobile = "800-792-8380" },
                new Person { FirstName = "Tana", LastName = "Walton", Birthday = DateTime.Parse("1951-06-03"), City = "Windsor", Province = "ON", Email = "risus@leo.co.uk", Mobile = "486-141-1305" },
                new Person { FirstName = "Tatum", LastName = "Montoya", Birthday = DateTime.Parse("1942-12-07"), City = "Winnipeg", Province = "MB", Email = "dolor@auctor.net", Mobile = "210-802-1203" },
                new Person { FirstName = "Tanek", LastName = "Jefferson", Birthday = DateTime.Parse("1970-07-17"), City = "Windsor", Province = "ON", Email = "Nullam@Nullam.co.uk", Mobile = "550-230-2146" },
                new Person { FirstName = "Zia", LastName = "Barber", Birthday = DateTime.Parse("1960-11-16"), City = "Osgoode", Province = "ON", Email = "dui.nec@quismassa.co.uk", Mobile = "966-522-0442" },
                new Person { FirstName = "Alvin", LastName = "Ferguson", Birthday = DateTime.Parse("1981-08-02"), City = "Montebello", Province = "QC", Email = "lacus@elitCurabitur.org", Mobile = "129-122-7168" },
                new Person { FirstName = "Rhea", LastName = "Ewing", Birthday = DateTime.Parse("1987-08-02"), City = "Notre-Dame-de-la-Salette", Province = "QC", Email = "Quisque@neque.net", Mobile = "319-112-3705" },
                new Person { FirstName = "Jelani", LastName = "Sims", Birthday = DateTime.Parse("1986-05-12"), City = "Bruderheim", Province = "AB", Email = "feugiat@blanditmattisCras.co.uk", Mobile = "759-388-6783" },
                new Person { FirstName = "Clare", LastName = "Sanders", Birthday = DateTime.Parse("1950-03-13"), City = "Saint-Prime", Province = "QC", Email = "semper.auctor@fermentumvel.edu", Mobile = "535-812-9710" },
                new Person { FirstName = "Cadman", LastName = "Howell", Birthday = DateTime.Parse("1945-05-08"), City = "Sooke", Province = "BC", Email = "natoque.penatibus@turpisNullaaliquet.co.uk", Mobile = "706-722-6762" },
                new Person { FirstName = "Camilla", LastName = "Warren", Birthday = DateTime.Parse("1998-11-17"), City = "Vanier", Province = "ON", Email = "turpis.non@Donec.org", Mobile = "154-892-7595" },
                new Person { FirstName = "Lester", LastName = "Castillo", Birthday = DateTime.Parse("1944-04-19"), City = "Milestone", Province = "SK", Email = "nisi.a.odio@amet.co.uk", Mobile = "827-654-9939" },
                new Person { FirstName = "Denton", LastName = "Ashley", Birthday = DateTime.Parse("1960-03-14"), City = "Rivière-du-Loup", Province = "QC", Email = "vel.turpis@at.co.uk", Mobile = "726-132-7001" },
                new Person { FirstName = "Kennan", LastName = "Hebert", Birthday = DateTime.Parse("1942-11-12"), City = "Township of Minden Hills", Province = "ON", Email = "mi.Duis@dignissim.ca", Mobile = "643-162-1501" },
                new Person { FirstName = "Kelly", LastName = "Alexander", Birthday = DateTime.Parse("1978-04-07"), City = "Wrigley", Province = "NT", Email = "lorem.fringilla@Inscelerisque.com", Mobile = "369-993-0222" },
                new Person { FirstName = "Felicia", LastName = "Wright", Birthday = DateTime.Parse("1961-10-08"), City = "Kingston", Province = "ON", Email = "hymenaeos.Mauris.ut@liberomaurisaliquam.org", Mobile = "350-812-5960" },
                new Person { FirstName = "Fleur", LastName = "Luna", Birthday = DateTime.Parse("1992-02-02"), City = "Thunder Bay", Province = "ON", Email = "urna.Vivamus@inlobortis.net", Mobile = "254-344-8797" },
                new Person { FirstName = "Patience", LastName = "Barnett", Birthday = DateTime.Parse("1959-10-13"), City = "Scarborough", Province = "ON", Email = "sed.turpis.nec@sedpedeCum.net", Mobile = "378-588-7523" },
                new Person { FirstName = "Gil", LastName = "Jacobs", Birthday = DateTime.Parse("1976-05-27"), City = "Nanaimo", Province = "BC", Email = "Integer.vitae.nibh@accumsanlaoreetipsum.ca", Mobile = "793-974-6366" },
                new Person { FirstName = "Brennan", LastName = "Kent", Birthday = DateTime.Parse("1950-04-11"), City = "Greater Sudbury", Province = "ON", Email = "sem.Pellentesque@luctuslobortisClass.co.uk", Mobile = "339-403-1347" },
                new Person { FirstName = "Wang", LastName = "Patel", Birthday = DateTime.Parse("1950-06-21"), City = "Delta", Province = "BC", Email = "ridiculus.mus.Proin@velturpisAliquam.ca", Mobile = "972-152-1647" },
                new Person { FirstName = "Kendall", LastName = "Sosa", Birthday = DateTime.Parse("1950-12-29"), City = "Owen Sound", Province = "ON", Email = "rutrum@egetvolutpatornare.com", Mobile = "667-760-4209" },
                new Person { FirstName = "Chava", LastName = "Contreras", Birthday = DateTime.Parse("1966-03-10"), City = "Thunder Bay", Province = "ON", Email = "et.netus.et@ipsum.edu", Mobile = "710-903-5222" },
                new Person { FirstName = "Norman", LastName = "Lambert", Birthday = DateTime.Parse("1977-07-25"), City = "Beausejour", Province = "MB", Email = "aliquam.enim@Integer.edu", Mobile = "961-981-3934" },
                new Person { FirstName = "Leroy", LastName = "Johnson", Birthday = DateTime.Parse("1984-06-19"), City = "Airdrie", Province = "AB", Email = "Curabitur@Classaptenttaciti.co.uk", Mobile = "380-642-0319" },
                new Person { FirstName = "Holmes", LastName = "Goff", Birthday = DateTime.Parse("1944-02-13"), City = "Greater Sudbury", Province = "ON", Email = "dictum@tellus.org", Mobile = "693-607-7029" },
                new Person { FirstName = "Hayden", LastName = "Blackwell", Birthday = DateTime.Parse("1973-04-14"), City = "Fermont", Province = "QC", Email = "quis.diam@metus.edu", Mobile = "952-355-8964" },
                new Person { FirstName = "Reece", LastName = "Burton", Birthday = DateTime.Parse("1955-12-16"), City = "Carleton", Province = "QC", Email = "dis.parturient@sociis.net", Mobile = "126-931-8145" },
                new Person { FirstName = "Ryder", LastName = "Franklin", Birthday = DateTime.Parse("1994-12-23"), City = "Daly", Province = "MB", Email = "bibendum.ullamcorper@dolorQuisquetincidunt.com", Mobile = "684-528-9015" },
                new Person { FirstName = "Noah", LastName = "Meyer", Birthday = DateTime.Parse("1941-04-09"), City = "Nakusp", Province = "BC", Email = "Sed.dictum@Crasegetnisi.org", Mobile = "178-916-5106" },
                new Person { FirstName = "Zorita", LastName = "Carlson", Birthday = DateTime.Parse("1979-11-28"), City = "Daly", Province = "MB", Email = "diam.lorem.auctor@utmi.net", Mobile = "430-753-9431" },
                new Person { FirstName = "Leroy", LastName = "Haney", Birthday = DateTime.Parse("1998-02-07"), City = "East Gwillimbury", Province = "ON", Email = "lectus.a@metussit.edu", Mobile = "490-990-4981" },
                new Person { FirstName = "Warren", LastName = "Page", Birthday = DateTime.Parse("1984-04-24"), City = "Picture Butte", Province = "AB", Email = "ligula.elit.pretium@necmaurisblandit.net", Mobile = "375-845-8374" },
                new Person { FirstName = "Zia", LastName = "Higgins", Birthday = DateTime.Parse("1971-09-08"), City = "Norfolk County", Province = "ON", Email = "Pellentesque.ultricies@PraesentluctusCurabitur.edu", Mobile = "205-696-4498" },
                new Person { FirstName = "Zachary", LastName = "Maxwell", Birthday = DateTime.Parse("1982-05-09"), City = "Salt Spring Island", Province = "BC", Email = "sit.amet@odiotristique.com", Mobile = "532-155-0355" },
                new Person { FirstName = "Brianna", LastName = "Oneill", Birthday = DateTime.Parse("1943-07-25"), City = "Grande Cache", Province = "AB", Email = "rhoncus.Donec@Classaptenttaciti.com", Mobile = "819-218-3780" },
                new Person { FirstName = "Phyllis", LastName = "Mcgowan", Birthday = DateTime.Parse("1981-06-20"), City = "Valcourt", Province = "QC", Email = "nunc.Quisque@vehiculaPellentesquetincidunt.ca", Mobile = "746-317-6694" },
                new Person { FirstName = "Lucius", LastName = "Blevins", Birthday = DateTime.Parse("1998-05-04"), City = "Chambord", Province = "QC", Email = "egestas.ligula@pulvinararcuet.net", Mobile = "594-392-0304" },
                new Person { FirstName = "Chase", LastName = "Sears", Birthday = DateTime.Parse("1943-10-25"), City = "Minitonas", Province = "MB", Email = "felis.orci@consectetuer.ca", Mobile = "605-414-3547" },
                new Person { FirstName = "Flynn", LastName = "Gardner", Birthday = DateTime.Parse("1944-11-04"), City = "Daly", Province = "MB", Email = "mauris.erat@euismodmauris.edu", Mobile = "944-855-4066" },
                new Person { FirstName = "Sebastian", LastName = "Byers", Birthday = DateTime.Parse("1991-07-12"), City = "Grande Cache", Province = "AB", Email = "et@parturientmontes.net", Mobile = "477-162-3201" },
                new Person { FirstName = "Dale", LastName = "Cantrell", Birthday = DateTime.Parse("1972-06-23"), City = "Amqui", Province = "QC", Email = "nec.mauris.blandit@Ut.co.uk", Mobile = "233-966-2182" },
                new Person { FirstName = "Stacey", LastName = "Clements", Birthday = DateTime.Parse("1970-01-19"), City = "Barrie", Province = "ON", Email = "ut.nisi@atliberoMorbi.com", Mobile = "175-370-4839" },
                new Person { FirstName = "Amy", LastName = "Gay", Birthday = DateTime.Parse("1983-10-25"), City = "Miramichi", Province = "NB", Email = "Nulla.dignissim@pellentesque.com", Mobile = "690-264-9170" },
                new Person { FirstName = "Joel", LastName = "Rollins", Birthday = DateTime.Parse("1985-02-11"), City = "Etobicoke", Province = "ON", Email = "dictum@Proinultrices.edu", Mobile = "706-533-5060" },
                new Person { FirstName = "Wilma", LastName = "Noel", Birthday = DateTime.Parse("1993-08-28"), City = "Norman Wells", Province = "NT", Email = "Curae.Phasellus.ornare@quam.org", Mobile = "615-661-9860" },
                new Person { FirstName = "Quamar", LastName = "Bender", Birthday = DateTime.Parse("1963-08-19"), City = "Whitehorse", Province = "YT", Email = "nec.ante@non.org", Mobile = "279-805-8091" },
                new Person { FirstName = "Kimberly", LastName = "Saunders", Birthday = DateTime.Parse("2000-03-05"), City = "Calder", Province = "SK", Email = "mauris@mauris.net", Mobile = "883-996-7263" },
                new Person { FirstName = "Madeline", LastName = "Roman", Birthday = DateTime.Parse("1973-11-19"), City = "Montreal", Province = "QC", Email = "non@milaciniamattis.net", Mobile = "343-151-5411" },
                new Person { FirstName = "Justina", LastName = "Brady", Birthday = DateTime.Parse("1977-10-02"), City = "Labrecque", Province = "QC", Email = "accumsan@blandit.net", Mobile = "209-918-3349" },
                new Person { FirstName = "Marsden", LastName = "Savage", Birthday = DateTime.Parse("1948-02-14"), City = "Port Hope", Province = "ON", Email = "massa.non@Nullasemper.com", Mobile = "140-464-7242" },
                new Person { FirstName = "Austin", LastName = "Weiss", Birthday = DateTime.Parse("1994-05-09"), City = "Newmarket", Province = "ON", Email = "accumsan.convallis.ante@convallisconvallis.co.uk", Mobile = "887-859-0693" },
                new Person { FirstName = "Stephanie", LastName = "Alexander", Birthday = DateTime.Parse("1975-09-05"), City = "Champlain", Province = "QC", Email = "eu.nulla@gravida.ca", Mobile = "750-521-7193" },
                new Person { FirstName = "Pamela", LastName = "Wise", Birthday = DateTime.Parse("1972-10-31"), City = "Merrickville-Wolford", Province = "ON", Email = "Nullam.suscipit.est@duiquis.ca", Mobile = "125-541-6727" },
                new Person { FirstName = "Austin", LastName = "Lawson", Birthday = DateTime.Parse("1961-09-30"), City = "Macklin", Province = "SK", Email = "tincidunt.neque.vitae@sagittisDuisgravida.org", Mobile = "465-265-1251" },
                new Person { FirstName = "Erasmus", LastName = "Mendez", Birthday = DateTime.Parse("1943-09-12"), City = "Montpellier", Province = "QC", Email = "magna.Cras.convallis@facilisisnon.com", Mobile = "871-998-7893" },
                new Person { FirstName = "Camilla", LastName = "Rodriquez", Birthday = DateTime.Parse("1996-08-27"), City = "Tay", Province = "ON", Email = "sit@eutellus.edu", Mobile = "441-356-8605" },
                new Person { FirstName = "Orla", LastName = "Larson", Birthday = DateTime.Parse("1951-02-19"), City = "Ramara", Province = "ON", Email = "feugiat@lacusQuisque.edu", Mobile = "108-300-4964" },
                new Person { FirstName = "Theodore", LastName = "Green", Birthday = DateTime.Parse("1949-08-11"), City = "Guelph", Province = "ON", Email = "et.malesuada@nonenim.org", Mobile = "362-728-0358" },
                new Person { FirstName = "Hollee", LastName = "Little", Birthday = DateTime.Parse("1989-05-23"), City = "Vanier", Province = "ON", Email = "Praesent.luctus.Curabitur@elit.org", Mobile = "734-499-0531" },
                new Person { FirstName = "Elaine", LastName = "Gonzalez", Birthday = DateTime.Parse("1965-10-28"), City = "Charlottetown", Province = "PE", Email = "dolor.vitae@auguemalesuada.net", Mobile = "658-774-3123" },
                new Person { FirstName = "Winifred", LastName = "England", Birthday = DateTime.Parse("1980-06-30"), City = "Mission", Province = "BC", Email = "et.pede@intempus.edu", Mobile = "944-415-4083" },
                new Person { FirstName = "Vaughan", LastName = "Summers", Birthday = DateTime.Parse("1973-05-29"), City = "Shawinigan", Province = "QC", Email = "suscipit.nonummy.Fusce@necorciDonec.ca", Mobile = "668-418-2708" },
                new Person { FirstName = "Dawn", LastName = "Terry", Birthday = DateTime.Parse("1959-05-28"), City = "Renfrew", Province = "ON", Email = "tortor.at@Maecenasmi.ca", Mobile = "581-801-2829" },
                new Person { FirstName = "Martena", LastName = "Henderson", Birthday = DateTime.Parse("1988-03-25"), City = "Kawartha Lakes", Province = "ON", Email = "rhoncus.Proin@et.org", Mobile = "122-230-8999" },
                new Person { FirstName = "Sheila", LastName = "Nichols", Birthday = DateTime.Parse("1973-12-08"), City = "Ajax", Province = "ON", Email = "diam.Sed@fringillaornare.com", Mobile = "328-524-0475" },
                new Person { FirstName = "Castor", LastName = "Ward", Birthday = DateTime.Parse("1970-09-22"), City = "Bathurst", Province = "NB", Email = "semper@ullamcorper.org", Mobile = "776-290-4796" },
                new Person { FirstName = "Randall", LastName = "Griffith", Birthday = DateTime.Parse("1977-12-27"), City = "Price", Province = "QC", Email = "Donec@vitaeorciPhasellus.ca", Mobile = "408-758-5810" },
            };

        }

        public IEnumerable<Person> GetAll()
        {
            /// Seulement pour des fins de tests
            foreach (Person p in data)
            {
                yield return p;
            }
        }

        public bool Insert(Person record)
        {
            bool result;

            try
            {
                data.Add(record);
                result = true;
            } catch
            {
                result = false;
            }

            return result;
        }

        public bool UpdateOrInsert(Person record)
        {
            bool result;

            try
            {
                if (!data.Contains(record))
                    result = Insert(record);
                else
                {
                    /// La liste contient des références
                    /// donc les mises à jour sont automatiques
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool Delete(Person record)
        {
            bool result;

            try
            {
                if (data.Contains(record))
                {
                    data.Remove(record);
                    result = true;
                } else
                {
                    result = false;
                }
                
                
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public bool Save()
        {
            if (string.IsNullOrEmpty(Filename))
                throw new NullReferenceException($"{nameof(Filename)} property is empty or null");

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;

            using (StreamWriter sw = new StreamWriter(Filename))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, data);
                }
            }    

            return false;
        }
    }
}
