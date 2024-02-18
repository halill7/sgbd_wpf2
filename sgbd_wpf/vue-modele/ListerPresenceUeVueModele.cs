using projet_sgbd.couches_access_db;
using projet_sgbd.couches_metier;
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

namespace sgbd_wpf.vue_modele
{
    class ListerPresenceUeVueModele : INotifyPropertyChanged
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

        DataView collectionPresenceUe;
        public DataView CollectionPresenceUe
        {
            get { return collectionPresenceUe; }
            set
            {
                collectionPresenceUe = value;
                OnPropertyChanged("CollectionPresenceUe");
            }
        }

        // propriété personne pour modification et ajout

        private Etudiant etudiant { get; set; }

        private UeAnneeAcademique ueaca { get; set; }

        private Participation par { get; set; }


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


        public int Idseance
        {
            get { return this.par.Idseance; }
            set
            {
                this.par.Idseance = value;
                OnPropertyChanged("Idseance");
            }
        }


        public string Statut
        {
            get { return this.par.Statut; }
            set
            {
                this.par.Statut = value;
                OnPropertyChanged("Statut");
            }
        }





        private AccesBD monBD;


        public ICommand Click_Lister_Presence_Ue { get; set; }

        List<Ue> ues = new List<Ue>();

        List<Etudiant> etu = new List<Etudiant>();

        List<Participation> part = new List<Participation>();


        public ListerPresenceUeVueModele()
        {
            // UE
            Click_Lister_Presence_Ue = new CommandMenu(onExecuteMethod: Execute_Lister_Presence_Ue, onCanExecuteMethod: CanExecute_Lister_Presence_Ue);
            ueaca = new UeAnneeAcademique();
            etudiant = new Etudiant();
            par = new Participation();
            monBD = new AccesBD();
            DataTable dt = new DataTable();



            dt.Columns.Add("Idue");
            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Idseance");
            dt.Columns.Add("Statut");



            if (part != null)
            {
                if (this.Idue != 0)
                {
                    part = monBD.ListePrésence(this.Idue);
                }

                while (etu.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idue"] = part[0].Idue;
                    dr["Idpersonne"] = part[0].Idpersonne;
                    dr["Idseance"] = part[0].Idseance;
                    dr["Statut"] = part[0].Statut;
                    dt.Rows.Add(dr);
                    ues.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                CollectionPresenceUe = dv;


            }






        }




        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.Idue = 0;
            this.Idpersonne = 0;
            this.Idseance = 0;
            this.Statut = "";
            this.Prenom = "";
            this.Email = "";

        }








        public void Execute_Lister_Presence_Ue(object parameter)
        {
            try
            {
                // Récupérer la liste des UE de la base de données en fonction de la section
                part = monBD.ListePrésence(this.Idue);

                // Effacer les lignes existantes dans la collection des UE
                CollectionPresenceUe.Table.Rows.Clear();

                // Itérer sur la liste des UE
                foreach (Participation p in part)
                {
                    // Créer une nouvelle ligne de données pour chaque UE
                    DataRow dr = CollectionPresenceUe.Table.NewRow();
                    dr["Idue"] = p.Idue;
                    dr["Idpersonne"] = p.Idpersonne;
                    dr["Idseance"] = p.Idseance;
                    dr["Statut"] = p.Statut;

                    // Ajouter la ligne à la collection des UE
                    CollectionPresenceUe.Table.Rows.Add(dr);
                }

                // Réinitialiser les valeurs des propriétés
                this.Idue = 0;
                this.Idpersonne = 0;
                this.Idseance = 0;
                this.Statut = "";
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show(
                    "Une erreur est survenue pendant l'affichage des présences :\n" +
                    ex.Message,
                    "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Lister_Presence_Ue(object parameter)
        {
            return true;
        }
    }
}
