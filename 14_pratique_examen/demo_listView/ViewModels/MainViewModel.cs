using demo_listView.Models;
using System;
using System.Collections.ObjectModel;

namespace demo_listView.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Person> people;

        public ObservableCollection<Person> People
        {
            get { return people; }
            set { 
                people = value;
                OnPropertyChanged();
            }
        }

        private Person selectedPerson;

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { 
                selectedPerson = value;
                OnPropertyChanged();
            }
        }

        // TODO : Ajouter une commande pour charger un fichier
        // TODO : Ajouter une commande pour sauvegarder dans un fichier

        public MainViewModel()
        {
            populate();
        }

        private void populate()
        {
            People = new ObservableCollection<Person>
            {
                new Person { FirstName = "Zachary", LastName = "Maxwell", Age=38 },
                new Person { FirstName = "Brianna", LastName = "Oneill", Age=77 },
                new Person { FirstName = "Phyllis", LastName = "Mcgowan", Age=39 },
                new Person { FirstName = "Lucius", LastName = "Blevins", Age=22 },
                new Person { FirstName = "Chase", LastName = "Sears", Age=77 },
                new Person { FirstName = "Flynn", LastName = "Gardner", Age=76 },
                new Person { FirstName = "Sebastian", LastName = "Byers", Age=29 },
                new Person { FirstName = "Dale", LastName = "Cantrell", Age=48 },
                new Person { FirstName = "Stacey", LastName = "Clements", Age=50 },
                new Person { FirstName = "Amy", LastName = "Gay", Age=37 },
                new Person { FirstName = "Joel", LastName = "Rollins", Age=35 },
                new Person { FirstName = "Wilma", LastName = "Noel", Age=27 },
                new Person { FirstName = "Quamar", LastName = "Bender", Age=57 },
                new Person { FirstName = "Kimberly", LastName = "Saunders", Age=20 },
                new Person { FirstName = "Madeline", LastName = "Roman", Age=47 },
                new Person { FirstName = "Justina", LastName = "Brady", Age=43 },
                new Person { FirstName = "Marsden", LastName = "Savage", Age=72 },
                new Person { FirstName = "Austin", LastName = "Weiss", Age=26 },
                new Person { FirstName = "Stephanie", LastName = "Alexander", Age=45 },
                new Person { FirstName = "Pamela", LastName = "Wise", Age=48 },
                new Person { FirstName = "Austin", LastName = "Lawson", Age=59 },
                new Person { FirstName = "Erasmus", LastName = "Mendez", Age=77 },
                new Person { FirstName = "Camilla", LastName = "Rodriquez", Age=24 },
                new Person { FirstName = "Orla", LastName = "Larson", Age=69 },
                new Person { FirstName = "Theodore", LastName = "Green", Age=71 },
                new Person { FirstName = "Hollee", LastName = "Little", Age=31 },
                new Person { FirstName = "Elaine", LastName = "Gonzalez", Age=55 },
                new Person { FirstName = "Winifred", LastName = "England", Age=40 },
                new Person { FirstName = "Vaughan", LastName = "Summers", Age=47 },
                new Person { FirstName = "Dawn", LastName = "Terry", Age=61 },
                new Person { FirstName = "Martena", LastName = "Henderson", Age=32 },
                new Person { FirstName = "Sheila", LastName = "Nichols", Age=46 },
                new Person { FirstName = "Castor", LastName = "Ward", Age=50 },
                new Person { FirstName = "Randall", LastName = "Griffith", Age=42 },
            };
        }
    }
}