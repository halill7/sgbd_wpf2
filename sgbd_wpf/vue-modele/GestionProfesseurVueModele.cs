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
    internal class GestionProfesseurVueModele : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }

        DataView collectionProf;
        public DataView CollectionProf
        {
            get { return collectionProf; }
            set
            {
                collectionProf = value;
                OnPropertyChanged("CollectionProf");
            }
        }

        // propriété personne pour modification et ajout

        private Professeur prof { get; set; }

        // Propriété IdPersonne: utilisé pour connaître la personne à modifier
        public int IdPersonne
        {
            get { return this.prof.IdPersonne; }
            set
            {
                this.prof.IdPersonne = value;
                OnPropertyChanged("IdPersonne");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Nom
        {
            get { return this.prof.Nom; }
            set
            {
                this.prof.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        // Propriété Prenom: utilisé pour la personne modifiée ou ajoutée
        public string Prenom
        {
            get { return this.prof.Prenom; }
            set
            {
                this.prof.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        // Propriété GSM: utilisé pour la personne modifiée ou ajoutée
        public string Gsm
        {
            get { return this.prof.Gsm; }
            set
            {
                this.prof.Gsm = value;
                OnPropertyChanged("Gsm");
            }
        }

        // Propriété Rue: utilisé pour la personne modifiée ou ajoutée
        public string Rue
        {
            get { return this.prof.Rue; }
            set
            {
                this.prof.Rue = value;
                OnPropertyChanged("Rue");
            }
        }

        // Propriété CP: utilisé pour la personne modifiée ou ajoutée

        public string Codepostal
        {
            get { return this.prof.Codepostal; }
            set
            {
                this.prof.Codepostal = value;
                OnPropertyChanged("Codepostal");
            }
        }

        public string Email
        {
            get { return this.prof.Email; }
            set
            {
                this.prof.Email = value;
                OnPropertyChanged("Email");
            }
        }

        // Propriété Localite: utilisé pour la personne modifiée ou ajoutée
        public string Localite
        {
            get { return this.prof.Localite; }
            set
            {
                this.prof.Localite = value;
                OnPropertyChanged("Localite");
            }
        }

        // Propriété Matricule: utilisé pour la personne modifiée ou ajoutée
        public string Matricule
        {
            get { return this.prof.Matricule; }
            set
            {
                this.prof.Matricule = value;
                OnPropertyChanged("Matricule");
            }
        }


        // Propriété Sexe: utilisé pour la personne modifiée ou ajoutée
        public char Sexe
        {
            get { return this.prof.Sexe; }
            set
            {
                this.prof.Sexe = value;
                OnPropertyChanged("Sexe");
            }
        }

        private AccesBD monBD;




        public ICommand Click_Ajouter_Prof { get; set; }


        public GestionProfesseurVueModele()
        {
            Click_Ajouter_Prof = new CommandMenu(onExecuteMethod: Execute_Ajouter_Prof, onCanExecuteMethod: CanExecute_Ajouter_Prof);
            prof = new Professeur();
            monBD = new AccesBD();
            List<Professeur> listProf;
            listProf = this.monBD.ListeProf();
            //collectionEtudiant = new ObservableCollection<Etudiant>();
            DataTable dt = new DataTable();

            dt.Columns.Add("Nom");
            dt.Columns.Add("Prenom");
            dt.Columns.Add("Sexe");
            dt.Columns.Add("Gsm");
            dt.Columns.Add("Rue");
            dt.Columns.Add("Codepostal");
            dt.Columns.Add("Localite");
            dt.Columns.Add("Matricule");
            dt.Columns.Add("Email");

            //this.etudiant.adresse = new Adresse();

            // prépare la liste des personnes à afficher 
            if (listProf != null)
            {
                while (listProf.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Nom"] = listProf[0].Nom;
                    dr["Prenom"] = listProf[0].Prenom;
                    dr["Sexe"] = listProf[0].Sexe;
                    dr["Gsm"] = listProf[0].Gsm;
                    dr["Rue"] = listProf[0].Rue;
                    dr["Codepostal"] = listProf[0].Codepostal;
                    dr["Localite"] = listProf[0].Localite;
                    dr["Matricule"] = listProf[0].Matricule;
                    dr["Email"] = listProf[0].Email;
                    dt.Rows.Add(dr);
                    listProf.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "Nom ASC";
                CollectionProf = dv;


            }

        }



        // propriété effectuer: contenu du bouton d'action

        public string effectuer;
        public string Effectuer
        {
            get { return this.effectuer; }
            set
            {
                this.effectuer = value;
                OnPropertyChanged("Effectuer");
            }
        }

        /*public void Modifier(int indexSelection)
        {
            IdPersonne =
                collectionEtudiant.ElementAt(indexSelection).IdPersonne;
            Nom = collectionEtudiant.ElementAt(indexSelection).Nom;
            Prenom = collectionEtudiant.ElementAt(indexSelection).Prenom;
            GSM = collectionEtudiant.ElementAt(indexSelection).Gsm;
            Rue = collectionEtudiant.ElementAt(indexSelection).Rue;
            CP = collectionEtudiant.ElementAt(indexSelection).Codepostal;
            Localite =
                collectionEtudiant.ElementAt(indexSelection).Localite;

            // Mise à jour du bouton d'action
            this.Effectuer = "Effectuer la modification";

        }*/

        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.IdPersonne = -1;
            this.Nom = null;
            this.Prenom = null;
            this.Gsm = null;
            this.Rue = null;
            this.Codepostal = null;
            this.Localite = null;
        }


        // Cette méthode est utlisée lorsqu'on clique sur le bouton d'action

        // méthode utilisée lorsqu'on clique sur le bouton Ajouter

        public void Ajouter()
        {
            // Met les champs de la nouvelle personne à vide
            this.Clear_personne();

            // Mise à jour du bouton d'action
            this.Effectuer = "Effectuer l'ajout";
        }



        // ajout de la catégorie dans la BD
        public void Execute_Ajouter_Prof(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterProf(this.prof);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionProf.Table.NewRow();
                    dr["Nom"] = this.prof.Nom;
                    dr["Prenom"] = this.prof.Prenom;
                    dr["Sexe"] = this.prof.Sexe;
                    dr["Gsm"] = this.prof.Gsm;
                    dr["Rue"] = this.prof.Rue;
                    dr["Codepostal"] = this.prof.Codepostal;
                    dr["Localite"] = this.prof.Localite;
                    dr["Matricule"] = this.prof.Matricule;
                    dr["Email"] = this.prof.Email;
                    CollectionProf.Table.Rows.Add(dr);

                }
                this.Nom = "";
                this.Prenom = "";
                this.Gsm = "";
                this.Sexe = 'X';
                this.Rue = "";
                this.Codepostal = "";
                this.Localite = "";
                this.Matricule = "";
                this.Email = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout du professeur :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Prof(object parameter)
        {
            if (this.Nom is null || this.Nom.Length < 3)
                return false;
            else
                return true;
        }
    }
}
