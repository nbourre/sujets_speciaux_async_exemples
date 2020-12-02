
using demo_openFolderDialog.Commands;
using Ookii.Dialogs.Wpf;
using System;
using System.IO;

namespace demo_openFolderDialog.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public DelegateCommand<string> OpenFileDialogCommand { get; set; }
        public DelegateCommand<string> SaveFileDialogCommand { get; set; }

        private VistaOpenFileDialog openFileDialog;
        private VistaSaveFileDialog saveFileDialog;

        private string openFilename;

        public string OpenFilename
        {
            get { return openFilename; }
            set { 
                openFilename = value;
                OnPropertyChanged();
            }
        }

        private string saveFilename;

        public string SaveFilename
        {
            get { return saveFilename; }
            set {
                saveFilename = value;
                OnPropertyChanged();
            }
        }

        private string fileContent;

        public string FileContent
        {
            get { return fileContent; }
            set {
                fileContent = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            saveFileDialog = new VistaSaveFileDialog();
            /// Permet de filtrer les fichies de base
            saveFileDialog.Filter = "Text file|*.txt|Comma-separated values (CSV)|*.csv|All files|*.*";
            /// Extension par défaut si l'utilisateur omet de l'inscrire
            saveFileDialog.DefaultExt = "txt";
            
            openFileDialog = new VistaOpenFileDialog();
            openFileDialog.Filter = "Text file|*.txt|Comma-separated values (CSV)|*.csv|All files|*.*";

            OpenFileDialogCommand = new DelegateCommand<string>(SelectFile);
            SaveFileDialogCommand = new DelegateCommand<string>(ChooseFileToSave);
        }

        private void SelectFile(string obj)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                OpenFilename = openFileDialog.FileName;
                showFileContent();
            }
        }

        private void ChooseFileToSave(string obj)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                SaveFilename = saveFileDialog.FileName;
                saveToFile();
            }
        }

        /// <summary>
        /// Seulement pour des fins de démonstration
        /// </summary>
        private void saveToFile()
        {
            using (var tw = new StreamWriter(SaveFilename, false))
            {
                tw.WriteLine(OpenFilename);
                tw.WriteLine(SaveFilename);
                tw.Close();
            }
        }

        private void showFileContent()
        {
            using (var sr = new StreamReader(OpenFilename))
            {
                FileContent = "-- FileContent --" + Environment.NewLine;
                FileContent += sr.ReadToEnd();
            }
        }
    }
}