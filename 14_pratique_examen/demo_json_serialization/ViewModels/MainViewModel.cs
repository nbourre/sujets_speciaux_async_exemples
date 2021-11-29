
using demo_json_serialization.Commands;
using demo_json_serialization.Services;
using System;
using System.Collections.Generic;

namespace demo_json_serialization.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool firstLoad = true;

        /// <summary>
        /// Liste des VM
        /// </summary>
        public List<BaseViewModel> ContentViewModels { get; set; }

        public PersonViewModel PersonViewModel { get; set; }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { 
                currentViewModel = value;
                OnPropertyChanged();
            }
        }


        public DelegateCommand<BaseViewModel> ChangePageCommand { get; set; }

        public MainViewModel()
        {
            buildViewModels();
            buildCommands();
        }

        private void buildViewModels()
        {
            PersonViewModel = new PersonViewModel { Name = "People", DataService = PeopleDataService.Instance };

            ContentViewModels = new List<BaseViewModel> {
                PersonViewModel
            };
        }

        private void buildCommands()
        {
            ChangePageCommand = new DelegateCommand<BaseViewModel>(ChangePage);
        }

        /// <summary>
        /// Permet de changer le VM actuel
        /// </summary>
        /// <param name="vm"></param>
        private void ChangePage(BaseViewModel vm)
        {
            if (firstLoad)
            {
                CurrentViewModel = vm;
            }
        }
    }
}