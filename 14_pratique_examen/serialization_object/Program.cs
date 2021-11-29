using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace serialization_object
{
    class Program
    {
        static Person p = new Person
        {
            FirstName = "Mick",
            LastName = "Jagger",
            City = "Shawinigan",
            Birthday = DateTime.Parse("1980-01-01")
        };        

        /// <summary>
        /// Méthode permettant de convertir un modèle en json
        /// </summary>
        /// <param name="format"></param>
        public static void simple_object_test(Formatting format = Formatting.None)
        {
            /// Cette méthode converti un modèle en format json
            string resultat = JsonConvert.SerializeObject(p, format);

            Console.WriteLine("Exemple de conversion d'un objet simple");
            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();

            /**
                * Sortie
                * Exemple de conversion d'un objet simple
                * {"FirstName":"Nick","LastName":"B","FullName":"B, Nick","Birthday":"1980-01-01T00:00:00","City":"Shawinigan","Province":null,"Email":null,"Mobile":null}
                * Appuyez sur pause
                * */
        }

        /// <summary>
        /// Cette méthode montre comment sauvegarder un objet en format json dans un fichier texte
        /// </summary>
        /// <param name="filename">Nom du fichier</param>
        static void save_to_file(string filename)
        {

            string resultat = JsonConvert.SerializeObject(p, Formatting.Indented);

            using (var tw = new StreamWriter(filename, false))
            {
                tw.WriteLine(resultat);
                tw.Close();
            }

            Console.WriteLine($"Exemple de sauvegarde dans le fichier {filename}");
            Console.WriteLine($"Ouvrir le fichier {filename} dans un éditeur pour voir le résultat");
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();
        }
        
        /// <summary>
        /// Fonction retournant une liste de personnes
        /// </summary>
        /// <returns>Liste de personnnes</returns>
        static List<Person> GetArrayExample()
        {
            return new List<Person>
            {
                new Person { FirstName = "Ayanna", LastName = "Vargas", Birthday = DateTime.Parse("1967-12-25"), City = "Pickering", Province = "ON", Email = "purus.in@semvitae.edu", Mobile = "647-142-8014" },
                new Person { FirstName = "Whitney", LastName = "Parks", Birthday = DateTime.Parse("1978-03-24"), City = "Greater Sudbury", Province = "ON", Email = "consectetuer.euismod@adipiscingelit.net", Mobile = "624-767-4994" },
                new Person { FirstName = "Louis", LastName = "Watts", Birthday = DateTime.Parse("1974-07-09"), City = "Fredericton", Province = "NB", Email = "at@gravidamolestie.ca", Mobile = "253-179-3847" },
                new Person { FirstName = "Pamela", LastName = "Knapp", Birthday = DateTime.Parse("1985-03-13"), City = "Mission", Province = "BC", Email = "eget.dictum@Aliquamvulputate.ca", Mobile = "501-312-8343" },
            };
        }

        /// <summary>
        /// Exemple de sérialization d'une collection
        /// </summary>
        static void serialize_array()
        {
            var data = GetArrayExample();

            var resultat = JsonConvert.SerializeObject(data, Formatting.Indented);

            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");
            Console.ReadLine();
        }

        /// <summary>
        /// Sauvegarde d'une liste en format json dans un fichier
        /// </summary>
        /// <param name="filename">Nom du fichier désiré</param>
        static void save_array_to_file(string filename)
        {
            var data = GetArrayExample();

            var resultat = JsonConvert.SerializeObject(data, Formatting.Indented);

            using (var tw = new StreamWriter(filename))
            {
                tw.WriteLine(resultat);
                tw.Close();
            }

            Console.WriteLine($"Exemple de sauvegarde dans le fichier {filename}");
            Console.WriteLine($"Ouvrir le fichier {filename} dans un éditeur pour voir le résultat");
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();
        }

        /// <summary>
        /// Exemple de désérialisation d'un json qui est dans un fichier vers un objet.
        /// La mécanique est la suivante :
        /// 1 - Lire le contenu du fichier en string
        /// 2 - Convertir le string avec la méthode JsonConvert.DeserializeObject
        /// </summary>
        /// <param name="filename">Chemin vers le fichier</param>
        static void deserialize_array_from_file(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"Le fichier {filename} n'existe pas. Veuillez le générer à partir de la sérialisation d'un tableau vers un fichier.");
                Console.ReadKey();
                return;
            }

            List<Person> data;
            using (StreamReader sr = File.OpenText(filename))
            {
                var fileContent = sr.ReadToEnd();

                data = JsonConvert.DeserializeObject<List<Person>>(fileContent);
            }

            Console.WriteLine($"Le fichier {filename} contient {data.Count} enregistrements.");
            Console.WriteLine($"Le premier enregistrement est : {data[0]}");
            Console.ReadLine();

        }
        
        /// <summary>
        /// Cette méthode converti un objet d'une classe qui hérite d'une autre classe
        /// La fonction de sérialisation est exactement la même que celle retrouvée dans
        /// <see cref="simple_object_test(Formatting)"/>
        /// </summary>
        static void serialize_object_inheritance()
        {
            Student student = new Student
            {
                FirstName = "Nick",
                LastName = "B",
                City = "Shawinigan",
                Birthday = DateTime.Parse("1980-01-01"),
                RegistrationNumber = "CS182647",
                StudentId = 2020
            };

            string resultat = JsonConvert.SerializeObject(student, Formatting.Indented);

            Console.WriteLine("Exemple de conversion d'un objet héritant");
            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();
        }

        /// <summary>
        /// Cette méthode converti un objet d'une classe qui a une collection d'objets
        /// La fonction de sérialisation est exactement la même que celle retrouvée dans
        /// <see cref="simple_object_test(Formatting)"/> et 
        /// <see cref="serialize_object_inheritance"/>
        /// </summary>
        static void serialize_object_aggregation()
        {
            // Le @ devant un nom sert à distinguer le mot-clé réservé au nom de l'objet
            Classroom @class = new Classroom { Name = "Special subjects" };
            
            string resultat = JsonConvert.SerializeObject(@class, Formatting.Indented);
            
            Console.WriteLine("Exemple de conversion d'un objet avec aggrégat");
            Console.WriteLine(resultat);
            Console.WriteLine("Appuyez sur une touche.");

            Console.ReadLine();
        }


        static void deserialize_from_file_to_object()
        {
            var filename = "person.json";

            // Pour l'exercice, si le fichier n'existe pas, on va en générer un
            if (!File.Exists(filename)) save_to_file(filename);


            using (StreamReader sr = File.OpenText(filename))
            {
                var fileContent = sr.ReadToEnd();

                Person p = JsonConvert.DeserializeObject<Person>(fileContent);

                Console.WriteLine($"***** Contenu de {filename} *****");
                Console.WriteLine(fileContent);
                Console.WriteLine($"***** {nameof(Person)}.toString() *****");
                Console.WriteLine(p);
                Console.ReadLine();
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            char key = ' ';

            while (key != 'q') {
                Console.Clear();
                Console.WriteLine("-- Exemple de sérialization et désérialization d'un JSON ---");
                Console.WriteLine("1. Sérialization d'un objet simple");
                Console.WriteLine("2. Sérialization d'un objet héritant");
                Console.WriteLine("3. Sérialization d'un objet avec aggrégation");
                Console.WriteLine("4. Désérialization d'une string vers un objet");
                Console.WriteLine("5. Sauvegarde vers un fichier texte");
                Console.WriteLine("6. Sérialisation d'un tableau");
                Console.WriteLine("7. Sérialisation d'un tableau vers un fichier");
                Console.WriteLine("8. Désérialisation d'un tableau à partir d'un fichier");
                Console.WriteLine("q. Quitter");
                Console.Write("Quel est votre choix : ");
                var result = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);
                key = result.KeyChar;

                switch (key)
                {
                    case '1':
                        simple_object_test(Formatting.Indented);
                        break;
                    case '2':
                        serialize_object_inheritance();
                        break;
                    case '3':
                        serialize_object_aggregation();
                        break;
                    case '4':
                        deserialize_from_file_to_object();
                        break;
                    case '5':
                        save_to_file("person.json");
                        break;
                    case '6':
                        serialize_array();
                        break;
                    case '7':
                        save_array_to_file("people.json");
                        break;
                    case '8':
                        deserialize_array_from_file("people.json");
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine("Sélection invalide!");
                        Console.WriteLine("Appuyez sur un touche");
                        Console.ReadKey();
                        
                        break;
                }

                
            }


        }

        /// TODO pour le prof: Exemple de désérialization d'une collection

        //private static void start_wpf_app()
        //{

        //    MainWindow wnd = new MainWindow();

        //    System.Windows.Application wpfApp = new System.Windows.Application();
        //    wpfApp.Run(wnd);
        //}
    }
}
