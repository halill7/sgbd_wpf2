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
using System.Windows.Documents;

namespace sgbd_wpf.vue_modele
{
    class ListerUeSectionVueModele : INotifyPropertyChanged
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

        DataView collectionUe;
        public DataView CollectionUe
        {
            get { return collectionUe; }
            set
            {
                collectionUe = value;
                OnPropertyChanged("CollectionUe");
            }
        }

        // propriété personne pour modification et ajout

        private Ue ue { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Libelle
        {
            get { return this.ue.Libelle; }
            set
            {
                this.ue.Libelle = value;
                OnPropertyChanged("Libelle");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public int Nbreperiodes
        {
            get { return this.ue.Nbreperiodes; }
            set
            {
                this.ue.Nbreperiodes = value;
                OnPropertyChanged("Nbreperiodes");
            }
        }

        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public string Section
        {
            get { return this.ue.Section; }
            set
            {
                this.ue.Section = value;
                OnPropertyChanged("Section");
            }
        }

        public int IdSection
        {
            get { return this.ue.Idue; }
            set
            {
                this.ue.Idue = value;
                OnPropertyChanged("Idue");
            }
        }

        public int Idue
        {
            get { return this.ue.Idue; }
            set
            {
                this.ue.Idue = value;
                OnPropertyChanged("Idue");
            }
        }




        private AccesBD monBD;


        public ICommand Click_Lister_Ue { get; set; }

        List<Ue> ues = new List<Ue>();


        public ListerUeSectionVueModele()
        {
            // UE
            Click_Lister_Ue = new CommandMenu(onExecuteMethod: Execute_Lister_Ue, onCanExecuteMethod: CanExecute_Lister_Ue);
            ue = new Ue();
            monBD = new AccesBD();
            DataTable dt = new DataTable();

            List<Ue> list = new List<Ue>();


            dt.Columns.Add("Idue");
            dt.Columns.Add("Libelle");
            dt.Columns.Add("Nbreperiodes");
            dt.Columns.Add("Section");



            if (ues != null)
            {
                if (this.Section != null)
                {
                    list = monBD.ListeUeSectionDonne(this.Section);
                }
                
                while (ues.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idue"] = ues[0].Idue;
                    dr["Libelle"] = ues[0].Libelle;
                    dr["Nbreperiodes"] = ues[0].Nbreperiodes;
                    dr["Section"] = ues[0].Section;
                    dt.Rows.Add(dr);
                    ues.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "Libelle ASC";
                CollectionUe = dv;


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
            this.Nbreperiodes = 0;
            this.Section = null;

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
        /**public void Execute_Lister_Ue(object parameter)
        {
            try
            {
                ues = monBD.ListeUeSectionDonne(this.Section);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionUe.Table.NewRow();
                    dr["Idue"] = this.ues[0];
                    dr["Libelle"] = this.ue.Libelle;
                    dr["Nbreperiodes"] = this.ue.Nbreperiodes;
                    dr["Section"] = this.ue.Section;
                    CollectionUe.Table.Rows.Add(dr);

                }
                this.Libelle = "";
                this.Nbreperiodes = 0;
                this.Section = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'affiche des ue :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }**/


        public void Execute_Lister_Ue(object parameter)
        {
            try
            {
                // Récupérer la liste des UE de la base de données en fonction de la section
                ues = monBD.ListeUeSectionDonne(this.Section);

                // Effacer les lignes existantes dans la collection des UE
                CollectionUe.Table.Rows.Clear();

                // Itérer sur la liste des UE
                foreach (Ue ue in ues)
                {
                    // Créer une nouvelle ligne de données pour chaque UE
                    DataRow dr = CollectionUe.Table.NewRow();
                    dr["Idue"] = ue.Idue;
                    dr["Libelle"] = ue.Libelle;
                    dr["Nbreperiodes"] = ue.Nbreperiodes;
                    dr["Section"] = ue.Section;

                    // Ajouter la ligne à la collection des UE
                    CollectionUe.Table.Rows.Add(dr);
                }

                // Réinitialiser les valeurs des propriétés
                this.Libelle = "";
                this.Nbreperiodes = 0;
                this.Section = "";
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                MessageBox.Show(
                    "Une erreur est survenue pendant l'affichage des UE :\n" +
                    ex.Message,
                    "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Lister_Ue(object parameter)
        {
            return true;
        }




       
    }
}
