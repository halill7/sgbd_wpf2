using projet_sgbd.couches_access_db;
using sgbd_wpf.vue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using projet_sgbd.couches_metier;

namespace sgbd_wpf.vue_modele
{
    internal class ListerEtudiantUeVueModele : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {

                {
                    this.PropertyChanged(this,
                        new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        DataView collectionetudiantlist;
        public DataView Collectionetudiantlist
        {
            get { return collectionetudiantlist; }
            set
            {
                collectionetudiantlist = value;
                OnPropertyChanged("Collectionetudiantlist");
            }
        }

        // propriété personne pour modification et ajout

        private Etudiant etudiant { get; set; }

        private UeAnneeAcademique ueaca { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public int Idpersonne
        {
            get { return this.etudiant.Idpersonne; }
            set
            {
                this.etudiant.Idpersonne = value;
                OnPropertyChanged("Idpersonne");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Nom
        {
            get { return this.etudiant.Nom; }
            set
            {
                this.etudiant.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Prenom
        {
            get { return this.etudiant.Prenom; }
            set
            {
                this.etudiant.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        public string Email
        {
            get { return this.etudiant.Email; }
            set
            {
                this.etudiant.Email = value;
                OnPropertyChanged("Email");
            }
        }

        public int Idue
        {
            get { return this.ueaca.Idue; }
            set
            {
                this.ueaca.Idue = value;
                OnPropertyChanged("Idue");
            }
        }

        public DateTime DateDebut
        {
            get { return this.ueaca.DateDebut; }
            set
            {
                this.ueaca.DateDebut = value;
                OnPropertyChanged("DateDebut");
            }
        }

        public DateTime DateFin
        {
            get { return this.ueaca.DateFin; }
            set
            {
                this.ueaca.DateFin = value;
                OnPropertyChanged("DateFin");
            }
        }




        private AccesBD monBD;


        public ICommand Click_Lister_Etudiant_Ue { get; set; }

        List<Ue> ues = new List<Ue>();

        List<Etudiant> etu = new List<Etudiant>();


        public ListerEtudiantUeVueModele()
        {
            // UE
            Click_Lister_Etudiant_Ue = new CommandMenu(onExecuteMethod: Execute_Lister_Etudiant_Ue, onCanExecuteMethod: CanExecute_Lister_Etudiant_Ue);
            ueaca = new UeAnneeAcademique();
            etudiant = new Etudiant();
            monBD = new AccesBD();
            DataTable dt = new DataTable();



            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Nom");
            dt.Columns.Add("Prenom");
            dt.Columns.Add("Email");



            if (etu != null)
            {
                if (this.Idue != 0)
                {
                    etu = monBD.ListeEtudiantUeAnneeAca(this.Idue, this.DateFin);
                }

                while (etu.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idpersonne"] = etu[0].Idpersonne;
                    dr["Nom"] = etu[0].Nom;
                    dr["Prenom"] = etu[0].Prenom;
                    dr["Email"] = etu[0].Email;
                    dt.Rows.Add(dr);
                    ues.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                Collectionetudiantlist = dv;


            }






        }




        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.Idue = 0;
            this.DateFin = DateTime.MinValue;
            this.Prenom = "";
            this.Email = "";

        }








        public void Execute_Lister_Etudiant_Ue(object parameter)
        {
            try
            {
                // Récupérer la liste des UE de la base de données en fonction de la section
                etu = monBD.ListeEtudiantUeAnneeAcademique(this.Idue, this.DateFin);

                // Effacer les lignes existantes dans la collection des UE
                Collectionetudiantlist.Table.Rows.Clear();

                // Itérer sur la liste des UE
                foreach (Etudiant etuu in etu)
                {
                    // Créer une nouvelle ligne de données pour chaque UE
                    DataRow dr = Collectionetudiantlist.Table.NewRow();
                    dr["Idpersonne"] = etuu.Idpersonne;
                    dr["Nom"] = etuu.Nom;
                    dr["Prenom"] = etuu.Prenom;
                    dr["Email"] = etuu.Email;

                    // Ajouter la ligne à la collection des UE
                    Collectionetudiantlist.Table.Rows.Add(dr);
                }

                // Réinitialiser les valeurs des propriétés
                this.Idue = 0;
                this.DateFin = DateTime.MinValue;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show(
                    "Une erreur est survenue pendant l'affichage des étudiants :\n" +
                    ex.Message,
                    "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Lister_Etudiant_Ue(object parameter)
        {
            return true;
        }
    }
}
