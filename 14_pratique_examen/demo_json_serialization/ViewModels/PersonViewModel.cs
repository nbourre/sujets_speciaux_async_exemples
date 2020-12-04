using demo_json_serialization.Commands;
using demo_json_serialization.Models;
using demo_json_serialization.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace demo_json_serialization.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private ObservableCollection<Person> people;
        private PeopleDataService dataService;

        #region Propriétés
        public string FirstName
        {
            get => CurrentPerson.FirstName;
            set {
                CurrentPerson.FirstName = value;
                OnPropertyChanged();
             }
        }
        public string LastName
        {
            get => CurrentPerson.LastName;
            set {
                CurrentPerson.LastName = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get => CurrentPerson.City;
            set {
                CurrentPerson.City = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthday { 
            get => CurrentPerson.Birthday;
            set
            {
                CurrentPerson.Birthday = value;
                OnPropertyChanged();
            }
        }
        
        public string Email { 
            get => CurrentPerson.Email;
            set {
                CurrentPerson.Email = value;
                OnPropertyChanged();
            }
        }

        public string Mobile
        {
            get => CurrentPerson.Mobile; 
            set {
                CurrentPerson.Mobile = value;
                OnPropertyChanged();
            }
        }


        public PeopleDataService DataService
        {
            get => dataService; 
            set
            {
                dataService = value;
                updateService();
            }
        }

        public ObservableCollection<Person> People{
            get => people; 
            set
            {
                people = value;
                OnPropertyChanged();
            }
        }

        private Person currentPerson;

        public Person CurrentPerson
        {
            get { return currentPerson; }
            set {
                currentPerson = value;
                OnPropertyChanged();
                updateProperties();
            }
        }

        #endregion

        public DelegateCommand<string> NextRecordCommand { get; set; }
        public DelegateCommand<string> SaveCommand { get; set; }

        public PersonViewModel()
        {
            Name = this.GetType().Name;
            initCommands();

        }

        private void initCommands()
        {
            NextRecordCommand = new DelegateCommand<string>(NextRecord, CanExecuteNextRecord);
            SaveCommand = new DelegateCommand<string>(Save);
        }

        private void Save(string obj)
        {
            saveAll();
        }

        private bool CanExecuteNextRecord(string obj)
        {
            return People.IndexOf(CurrentPerson) < People.Count - 1;
        }

        private void NextRecord(string obj)
        {
            CurrentPerson = People[People.IndexOf(CurrentPerson) + 1];
        }

        private void updateService()
        {
            People = new ObservableCollection<Person> (DataService.GetAll());
            CurrentPerson = People.First();

            DataService.Filename = @"people_data.json";
        }

        private void updateProperties()
        {
            OnPropertyChanged(nameof(FirstName));
            OnPropertyChanged(nameof(LastName));
            OnPropertyChanged(nameof(City));
            OnPropertyChanged(nameof(Mobile));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Birthday));

        }

        private void saveAll()
        {
            DataService.Save();
        }

    }
}
