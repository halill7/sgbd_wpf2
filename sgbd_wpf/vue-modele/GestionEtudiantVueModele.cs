using projet_sgbd.couches_access_db;
using projet_sgbd.couches_metier;
using sgbd_wpf.vue;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace sgbd_wpf.vue_modele
{
    internal class GestionEtudiantVueModele : INotifyPropertyChanged
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

        DataView collectionEtudiant;
        public DataView CollectionEtudiant
        {
            get { return collectionEtudiant; }
            set
            {
                collectionEtudiant = value;
                OnPropertyChanged("CollectionEtudiant");
            }
        }

        // propriété personne pour modification et ajout

        private Etudiant etudiant { get; set; }

        // Propriété IdPersonne: utilisé pour connaître la personne à modifier
        public int Idpersonne
        {
            get { return this.etudiant.Idpersonne; }
            set
            {
                this.etudiant.IdPersonne = value;
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

        // Propriété Prenom: utilisé pour la personne modifiée ou ajoutée
        public string Prenom
        {
            get { return this.etudiant.Prenom; }
            set
            {
                this.etudiant.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        // Propriété GSM: utilisé pour la personne modifiée ou ajoutée
        public string Gsm
        {
            get { return this.etudiant.Gsm; }
            set
            {
                this.etudiant.Gsm = value;
                OnPropertyChanged("Gsm");
            }
        }

        // Propriété Rue: utilisé pour la personne modifiée ou ajoutée
        public string Rue
        {
            get { return this.etudiant.Rue; }
            set
            {
                this.etudiant.Rue = value;
                OnPropertyChanged("Rue");
            }
        }

        // Propriété CP: utilisé pour la personne modifiée ou ajoutée

        public string Codepostal
        {
            get { return this.etudiant.Codepostal; }
            set
            {
                this.etudiant.Codepostal = value;
                OnPropertyChanged("Codepostal");
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

        // Propriété Localite: utilisé pour la personne modifiée ou ajoutée
        public string Localite
        {
            get { return this.etudiant.Localite; }
            set
            {
                this.etudiant.Localite = value;
                OnPropertyChanged("Localite");
            }
        }


        // Propriété Sexe: utilisé pour la personne modifiée ou ajoutée
        public char Sexe
        {
            get { return this.etudiant.Sexe; }
            set
            {
                this.etudiant.Sexe = value;
                OnPropertyChanged("Sexe");
            }
        }

        private AccesBD monBD;


        DataView collectionEtudiantt;
        public DataView CollectionEtudiantt
        {
            get { return collectionEtudiantt; }
            set
            {
                collectionEtudiantt = value;
                OnPropertyChanged("CollectionEtudiant");
            }
        }



        public ICommand Click_Ajouter_Etudiant { get; set; }


        public GestionEtudiantVueModele()
        {
            Click_Ajouter_Etudiant = new CommandMenu(onExecuteMethod: Execute_Ajouter_Etudiant, onCanExecuteMethod: CanExecute_Ajouter_Etudiant);
            etudiant = new Etudiant();
            monBD = new AccesBD();
            List<Etudiant> listEtudiant;
            listEtudiant = this.monBD.ListeEtudiant();
            //collectionEtudiant = new ObservableCollection<Etudiant>();
            DataTable dt = new DataTable();

            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Nom");
            dt.Columns.Add("Prenom");
            dt.Columns.Add("Sexe");
            dt.Columns.Add("Gsm");
            dt.Columns.Add("Rue");
            dt.Columns.Add("Codepostal");
            dt.Columns.Add("Localite");
            dt.Columns.Add("Email");

            //this.etudiant.adresse = new Adresse();

            // prépare la liste des personnes à afficher 
            if (listEtudiant != null)
            {
                while (listEtudiant.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idpersonne"] = listEtudiant[0].IdPersonne;
                    dr["Nom"] = listEtudiant[0].Nom;
                    dr["Prenom"] = listEtudiant[0].Prenom;
                    dr["Sexe"] = listEtudiant[0].Sexe;
                    dr["Gsm"] = listEtudiant[0].Gsm;
                    dr["Rue"] = listEtudiant[0].Rue;
                    dr["Codepostal"] = listEtudiant[0].Codepostal;
                    dr["Localite"] = listEtudiant[0].Localite;
                    dr["Email"] = listEtudiant[0].Email;
                    dt.Rows.Add(dr);
                    listEtudiant.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "Nom ASC";
                CollectionEtudiantt = dv;


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


        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.Idpersonne = -1;
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
        public void Execute_Ajouter_Etudiant(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterEtudiant(this.etudiant);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionEtudiantt.Table.NewRow();
                    dr["Nom"] = this.etudiant.Nom;
                    dr["Prenom"] = this.etudiant.Prenom;
                    dr["Sexe"] = this.etudiant.Sexe;
                    dr["Gsm"] = this.etudiant.Gsm;
                    dr["Rue"] = this.etudiant.Rue;
                    dr["Codepostal"] = this.etudiant.Codepostal;
                    dr["Localite"] = this.etudiant.Localite;
                    dr["Email"] = this.etudiant.Email;
                    CollectionEtudiantt.Table.Rows.Add(dr);

                }
                this.Nom = "";
                this.Prenom = "";
                this.Gsm = "";
                this.Sexe = 'X';
                this.Rue = "";
                this.Codepostal = "";
                this.Localite = "";
                this.Email = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout de l'étudiant :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Etudiant(object parameter)
        {
            if (this.Nom is null || this.Nom.Length < 3)
                return false;
            else
                return true;
        }
    }
}
