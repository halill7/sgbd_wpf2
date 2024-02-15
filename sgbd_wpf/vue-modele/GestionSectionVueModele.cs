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
    internal class GestionSectionVueModele : INotifyPropertyChanged
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

        DataView collectionSection;
        public DataView CollectionSection
        {
            get { return collectionSection; }
            set
            {
                collectionSection = value;
                OnPropertyChanged("CollectionSection");
            }
        }

        // propriété personne pour modification et ajout

        private Section section { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Libelle
        {
            get { return this.section.Libelle; }
            set
            {
                this.section.Libelle = value;
                OnPropertyChanged("Libelle");
            }
        }

        public string IdSection
        {
            get { return this.section.IdSection; }
            set
            {
                this.section.IdSection = value;
                OnPropertyChanged("Libelle");
            }
        }


        private AccesBD monBD;


        public ICommand Click_Ajouter_Section { get; set; }


        public GestionSectionVueModele()
        {
            Click_Ajouter_Section = new CommandMenu(onExecuteMethod: Execute_Ajouter_Section, onCanExecuteMethod: CanExecute_Ajouter_Section);
            section = new Section();
            monBD = new AccesBD();
            List<Section> listSection;
            listSection = this.monBD.ListeSection();
            DataTable dt = new DataTable();

            dt.Columns.Add("IdSection");
            dt.Columns.Add("Libelle");

            // prépare la liste des section à afficher 
            if (listSection != null)
            {
                while (listSection.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["IdSection"] = listSection[0].IdSection;
                    dr["Libelle"] = listSection[0].Libelle;
                    dt.Rows.Add(dr);
                    listSection.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "IdSection DESC";
                CollectionSection = dv;


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
            this.Libelle = null;

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
        public void Execute_Ajouter_Section(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterSection(this.section);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionSection.Table.NewRow();
                    dr["Libelle"] = this.section.Libelle;
                    CollectionSection.Table.Rows.Add(dr);

                }
                this.Libelle = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout de la section :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Section(object parameter)
        {
                return true;
        }
    
}
}
