
using Utilities;
using View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ProfesseurCommand { get; set; }
        public ICommand SectionCommand { get; set; }
        public ICommand UeCommand { get; set; }
        public ICommand PersonneCommand { get; set; }
        public ICommand SeanceCommand { get; set; }
        public ICommand InscriptionCommand { get; set; }
        public ICommand ParticipationCommand { get; set; }
        public ICommand ListUeSectionCommand { get; set; }

        public ICommand ListEtudiantUeCommand { get; set; }
        public ICommand ListPresenceUeCommand { get; set; }

        public ICommand ListResultatUeCommand { get; set; }

        private void Home(object obj) => CurrentView = new EtudiantVM();
        private void Professeur(object obj) => CurrentView = new ProfesseurVM();
        private void Section(object obj) => CurrentView = new SectionVM();
        private void Ue(object obj) => CurrentView = new UeVM();
        private void Personne(object obj) => CurrentView = new PersonneVM();
        private void Seance(object obj) => CurrentView = new SeanceVM();
        private void Inscription(object obj) => CurrentView = new InscriptionVM();
        private void Participation(object obj) => CurrentView = new ParticipationVM();
        private void ListUeSection(object obj) => CurrentView = new ListUeSectionVM();

        private void ListEtudiantUe(object obj) => CurrentView = new ListEtudiantUeVM();

        private void ListPresenceUe(object obj) => CurrentView = new ListPresenceUeVM();

        private void ListResultatUe(object obj) => CurrentView = new ListResultatUeVM();


        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ProfesseurCommand = new RelayCommand(Professeur);
            SectionCommand = new RelayCommand(Section);
            UeCommand = new RelayCommand(Ue);
            PersonneCommand = new RelayCommand(Personne);
            SeanceCommand = new RelayCommand(Seance);
            InscriptionCommand = new RelayCommand(Inscription);
            ParticipationCommand = new RelayCommand(Participation);
            ListUeSectionCommand = new RelayCommand(ListUeSection);
            ListEtudiantUeCommand = new RelayCommand(ListEtudiantUe);
            ListPresenceUeCommand = new RelayCommand(ListPresenceUe);
            ListResultatUeCommand = new RelayCommand(ListResultatUe);

            // Startup Page
            CurrentView = new EtudiantVM();
        }
    }
}
