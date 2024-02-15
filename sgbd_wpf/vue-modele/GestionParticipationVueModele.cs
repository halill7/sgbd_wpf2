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
using System.Windows.Controls;

namespace sgbd_wpf.vue_modele
{
    internal class GestionParticipationVueModele : INotifyPropertyChanged
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

        DataView collectionParticipation;
        public DataView CollectionParticipation
        {
            get { return collectionParticipation; }
            set
            {
                collectionParticipation = value;
                OnPropertyChanged("CollectionParticipation");
            }
        }

        // propriété personne pour modification et ajout

        private Participation participation { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public int Idue
        {
            get { return this.participation.Idue; }
            set
            {
                this.participation.Idue = value;
                OnPropertyChanged("Idue");
            }
        }

        public int Idpersonne
        {
            get { return this.participation.Idpersonne; }
            set
            {
                this.participation.Idpersonne = value;
                OnPropertyChanged("Idpersonne");
            }
        }

        public int Idseance
        {
            get { return this.participation.Idseance; }
            set
            {
                this.participation.Idseance = value;
                OnPropertyChanged("Idseance");
            }
        }

        public string Statut
        {
            get { return this.participation.Statut; }
            set
            {
                this.participation.Statut = value;
                OnPropertyChanged("Statut");
            }
        }
        private AccesBD monBD;


        public ICommand Click_Ajouter_Participation { get; set; }


        public GestionParticipationVueModele()
        {
            Click_Ajouter_Participation = new CommandMenu(onExecuteMethod: Execute_Ajouter_Participation, onCanExecuteMethod: CanExecute_Ajouter_Participation);
            participation = new Participation();
            monBD = new AccesBD();
            List<Participation> listParticipation;
            listParticipation = this.monBD.ListeParticipation();
            DataTable dt = new DataTable();

            dt.Columns.Add("Idue");
            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Idseance");
            dt.Columns.Add("Statut");


            // prépare la liste des section à afficher 
            if (listParticipation != null)
            {
                while (listParticipation.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idue"] = listParticipation[0].Idue;
                    dr["Idpersonne"] = listParticipation[0].Idpersonne;
                    dr["Idseance"] = listParticipation[0].Idseance;
                    dr["Statut"] = listParticipation[0].Statut;
                    dt.Rows.Add(dr);
                    listParticipation.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                CollectionParticipation = dv;


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
            this.Idseance = -1;
            this.Idue = -1;
            this.Idpersonne = -1;
            this.Statut = null;

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
        public void Execute_Ajouter_Participation(object parameter)
        {
            try
            {
                int resultatAjout = monBD.EncoderPresence(this.participation);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionParticipation.Table.NewRow();
                    dr["Idue"] = this.participation.Idue;
                    dr["Idpersonne"] = this.participation.Idpersonne;
                    dr["Idseance"] = this.participation.Idseance;
                    dr["Statut"] = this.participation.Statut;
                    CollectionParticipation.Table.Rows.Add(dr);
                }
                this.Idue = 0;
                this.Idpersonne = 0;
                this.Idseance = 0;
                this.Statut = "";

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout de la présence à la séance :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Participation(object parameter)
        {
            return true;
        }


        /**private void TextBoxChanged(object sender, TextChangedEventArgs eventArgs)
        {
            var tbx = sender as TextBox;
            if (tbx != null)
            {
                // Vérifiez si le texte est un entier valide
                if (int.TryParse(tbx.Text, out int searchTerm))
                {
                    // Convertir la liste d'entiers en une liste de chaînes
                    var stringList = this.Idue.Select(x => x.ToString()).ToList();
                    // Filtrer la liste de chaînes par la valeur entière recherchée
                    var filteredList = stringList.Where(x => x.Contains(tbx.Text));
                    // Convertir les chaînes filtrées en entiers
                    var filteredIntegers = filteredList.Select(int.Parse);
                    GRD.ItemsSource = null;
                    // Réaffecter la source de données à la DataGrid
                    GRD.ItemsSource = filteredIntegers;
                }
                else
                {
                    // Si le texte n'est pas un entier valide, afficher la collection complète
                    GRD.ItemsSource = this.Idue;
                }
            }
        }**/






    }
}
