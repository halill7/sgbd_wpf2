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
    internal class GestionSeanceVueModele : INotifyPropertyChanged
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

        DataView collectionSeance;
        public DataView CollectionSeance
        {
            get { return collectionSeance; }
            set
            {
                collectionSeance = value;
                OnPropertyChanged("CollectionSeance");
            }
        }

        // propriété personne pour modification et ajout

        private Seance seance { get; set; }


        // Propriété Nom: utilisé pour la personne modifiée ou ajoutée
        public DateTime DateSeance
        {
            get { return this.seance.DateSeance; }
            set
            {
                this.seance.DateSeance = value;
                OnPropertyChanged("DateSeance");
            }
        }

        public int Idseance
        {
            get { return this.seance.Idseance; }
            set
            {
                this.seance.Idseance = value;
                OnPropertyChanged("Idseance");
            }
        }

        public int Idue
        {
            get { return this.seance.Idue; }
            set
            {
                this.seance.Idue = value;
                OnPropertyChanged("Idue");
            }
        }


        private AccesBD monBD;


        public ICommand Click_Ajouter_Seance { get; set; }
        public ICommand Click_Modifier_Seance { get; set; }


        public GestionSeanceVueModele()
        {
            Click_Ajouter_Seance = new CommandMenu(onExecuteMethod: Execute_Ajouter_Seance, onCanExecuteMethod: CanExecute_Ajouter_Seance);
            Click_Modifier_Seance = new CommandMenu(onExecuteMethod: Execute_Modifier_Seance, onCanExecuteMethod: CanExecute_Modifier_Seance);
            seance = new Seance();
            monBD = new AccesBD();
            List<Seance> listSeance;
            listSeance = this.monBD.ListeSeance();
            DataTable dt = new DataTable();

            dt.Columns.Add("Idseance");
            dt.Columns.Add("DateSeance");
            dt.Columns.Add("Idue");

            // prépare la liste des section à afficher 
            if (listSeance != null)
            {
                while (listSeance.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idseance"] = listSeance[0].Idseance;
                    dr["Dateseance"] = listSeance[0].DateSeance.ToString("dd-MM-yyyy");
                    dr["Idue"] = listSeance[0].Idue;
                    dt.Rows.Add(dr);
                    listSeance.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                CollectionSeance = dv;


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
            this.Idseance = -1;
            this.Idue = -1;
            this.DateSeance = DateTime.MinValue;

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
        public void Execute_Ajouter_Seance(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterSeance(this.seance);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionSeance.Table.NewRow();
                    dr["Dateseance"] = this.seance.DateSeance.ToString("dd-MM-yyyy");
                    dr["Idue"] = this.seance.Idue;
                    CollectionSeance.Table.Rows.Add(dr);

                }
                this.DateSeance = DateTime.MinValue;
                this.Idue = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout de la séance :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Seance(object parameter)
        {
            return true;
        }





        // modification seance
        public void Execute_Modifier_Seance(object parameter)
        {
            try
            {
                int resultatAjout = monBD.ModifierSeance(this.seance);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionSeance.Table.NewRow();
                    dr["Idseance"] = this.seance.Idseance;
                    dr["Dateseance"] = this.seance.DateSeance;
                    CollectionSeance.Table.Rows.Add(dr);

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
                "Une erreur est survenue pendant l'ajout du résultat :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Modifier_Seance(object parameter)
        {
            return true;
        }
    }
}
