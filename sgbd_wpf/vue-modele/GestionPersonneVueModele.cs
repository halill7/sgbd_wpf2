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
    internal class GestionPersonneVueModele : INotifyPropertyChanged
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

        DataView collectionPersonne;
        public DataView CollectionPersonne
        {
            get { return collectionPersonne; }
            set
            {
                collectionPersonne = value;
                OnPropertyChanged("CollectionPersonne");
            }
        }

        // propriété personne pour modification et ajout

        private Personne personne { get; set; }

        // Propriété IdPersonne: utilisé pour connaître la personne à modifier
        public int IdPersonne
        {
            get { return this.personne.IdPersonne; }
            set
            {
                this.personne.IdPersonne = value;
                OnPropertyChanged("IdPersonne");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Nom
        {
            get { return this.personne.Nom; }
            set
            {
                this.personne.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        // Propriété Prenom: utilisé pour la personne modifiée ou ajoutée
        public string Prenom
        {
            get { return this.personne.Prenom; }
            set
            {
                this.personne.Prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        // Propriété GSM: utilisé pour la personne modifiée ou ajoutée
        public string Gsm
        {
            get { return this.personne.Gsm; }
            set
            {
                this.personne.Gsm = value;
                OnPropertyChanged("Gsm");
            }
        }

        // Propriété Rue: utilisé pour la personne modifiée ou ajoutée
        public string Rue
        {
            get { return this.personne.Rue; }
            set
            {
                this.personne.Rue = value;
                OnPropertyChanged("Rue");
            }
        }

        // Propriété CP: utilisé pour la personne modifiée ou ajoutée

        public string Codepostal
        {
            get { return this.personne.Codepostal; }
            set
            {
                this.personne.Codepostal = value;
                OnPropertyChanged("Codepostal");
            }
        }


        // Propriété Localite: utilisé pour la personne modifiée ou ajoutée
        public string Localite
        {
            get { return this.personne.Localite; }
            set
            {
                this.personne.Localite = value;
                OnPropertyChanged("Localite");
            }
        }


        // Propriété Sexe: utilisé pour la personne modifiée ou ajoutée
        public char Sexe
        {
            get { return this.personne.Sexe; }
            set
            {
                this.personne.Sexe = value;
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



        public ICommand Click_Modifier_Personne { get; set; }


        public GestionPersonneVueModele()
        {
            Click_Modifier_Personne = new CommandMenu(onExecuteMethod: Execute_Modifier_Personne, onCanExecuteMethod: CanExecute_Modifier_Personne);
            personne = new Etudiant();
            monBD = new AccesBD();
            List<Personne> listPersonne;
            listPersonne = this.monBD.ListePersonne();
            //collectionEtudiant = new ObservableCollection<Etudiant>();
            DataTable dt = new DataTable();


            dt.Columns.Add("IdPersonne");
            dt.Columns.Add("Nom");
            dt.Columns.Add("Prenom");
            dt.Columns.Add("Sexe");
            dt.Columns.Add("Gsm");
            dt.Columns.Add("Rue");
            dt.Columns.Add("Codepostal");
            dt.Columns.Add("Localite");

            //this.etudiant.adresse = new Adresse();

            // prépare la liste des personnes à afficher 
            if (listPersonne != null)
            {
                while (listPersonne.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["IdPersonne"] = listPersonne[0].IdPersonne;
                    dr["Nom"] = listPersonne[0].Nom;
                    dr["Prenom"] = listPersonne[0].Prenom;
                    dr["Sexe"] = listPersonne[0].Sexe;
                    dr["Gsm"] = listPersonne[0].Gsm;
                    dr["Rue"] = listPersonne[0].Rue;
                    dr["Codepostal"] = listPersonne[0].Codepostal;
                    dr["Localite"] = listPersonne[0].Localite;
                    dt.Rows.Add(dr);
                    listPersonne.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "IdPersonne ASC";
                CollectionPersonne = dv;


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



        // faire une méthode pour mofidier une personne
        public void Execute_Modifier_Personne(object parameter)
        {
            try
            {
                int resultatAjout = monBD.ModifierPersonne(this.personne);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionPersonne.Table.NewRow();
                    dr["Idpersonne"] = this.personne.IdPersonne;
                    dr["Nom"] = this.personne.Nom;
                    dr["Prenom"] = this.personne.Prenom;
                    dr["Gsm"] = this.personne.Gsm;
                    dr["Rue"] = this.personne.Rue;
                    dr["Codepostal"] = this.personne.Codepostal;
                    dr["Localite"] = this.personne.Localite;
                    CollectionPersonne.Table.Rows.Add(dr);

                }

                /**
                this.Idpersonne = 0;
                this.Idue = 0;
                this.Resultat = 0;
                **/
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant la modification de la personne :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Modifier_Personne(object parameter)
        {
            return true;
        }

    }
}
