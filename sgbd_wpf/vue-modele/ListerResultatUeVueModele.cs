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
    internal class ListerResultatUeVueModele : INotifyPropertyChanged
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

        DataView collectionResultatUe;
        public DataView CollectionResultatUe
        {
            get { return collectionResultatUe; }
            set
            {
                collectionResultatUe = value;
                OnPropertyChanged("CollectionResultatUe");
            }
        }

        // propriété personne pour modification et ajout

        private Etudiant etudiant { get; set; }

        private UeAnneeAcademique ueaca { get; set; }

        private Inscription inscris { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public int Idpersonne
        {
            get { return this.inscris.Idpersonne; }
            set
            {
                this.inscris.Idpersonne = value;
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
            get { return this.inscris.Idue; }
            set
            {
                this.inscris.Idue = value;
                OnPropertyChanged("Idue");
            }
        }


        public int Resultat
        {
            get { return this.inscris.Resultat; }
            set
            {
                this.inscris.Resultat = value;
                OnPropertyChanged("Resultat");
            }
        }







        private AccesBD monBD;


        public ICommand Click_Lister_Resultat_Ue { get; set; }

        List<Ue> ues = new List<Ue>();

        List<Etudiant> etu = new List<Etudiant>();

        List<Inscription> ins = new List<Inscription>();


        public ListerResultatUeVueModele()
        {
            // UE
            Click_Lister_Resultat_Ue = new CommandMenu(onExecuteMethod: Execute_Lister_Resultat_Ue, onCanExecuteMethod: CanExecute_Lister_Resultat_Ue);
            ueaca = new UeAnneeAcademique();
            etudiant = new Etudiant();
            inscris = new Inscription();
            monBD = new AccesBD();
            DataTable dt = new DataTable();



            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Idue");
            dt.Columns.Add("Resultat");



            if (ins != null)
            {
                if (this.Idue != 0)
                {
                    ins = monBD.ListeUeReussiOuEnCours(this.Idpersonne);
                }

                while (etu.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idpersonne"] = ins[0].Idpersonne;
                    dr["Idue"] = ins[0].Idue;
                    dr["Resultat"] = ins[0].Resultat;
                    dt.Rows.Add(dr);
                    ues.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                CollectionResultatUe = dv;


            }






        }




        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.Idue = 0;
            this.Idpersonne = 0;
            this.Resultat = 0;
            this.Prenom = "";
            this.Email = "";

        }








        public void Execute_Lister_Resultat_Ue(object parameter)
        {
            try
            {
                // Récupérer la liste des UE de la base de données en fonction de la section
                ins = monBD.ListeUeReussiOuEnCours(this.Idpersonne);

                // Effacer les lignes existantes dans la collection des UE
                CollectionResultatUe.Table.Rows.Clear();

                // Itérer sur la liste des UE
                foreach (Inscription i in ins)
                {
                    // Créer une nouvelle ligne de données pour chaque UE
                    DataRow dr = CollectionResultatUe.Table.NewRow();
                    dr["Idpersonne"] = i.Idpersonne;
                    dr["Idue"] = i.Idue;
                    dr["Resultat"] = i.Resultat;

                    // Ajouter la ligne à la collection des UE
                    CollectionResultatUe.Table.Rows.Add(dr);
                }

                // Réinitialiser les valeurs des propriétés
                this.Idue = 0;
                this.Idpersonne = 0;
                this.Resultat = 0;
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show(
                    "Une erreur est survenue pendant l'affichage des ue et résultat pour un étudiant donné:\n" +
                    ex.Message,
                    "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Lister_Resultat_Ue(object parameter)
        {
            return true;
        }
    }
}
