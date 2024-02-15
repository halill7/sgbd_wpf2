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
    internal class GestionUeVueModele : INotifyPropertyChanged
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


        private AccesBD monBD;


        public ICommand Click_Ajouter_Ue { get; set; }


        public GestionUeVueModele()
        {
            // UE
            Click_Ajouter_Ue = new CommandMenu(onExecuteMethod: Execute_Ajouter_Ue, onCanExecuteMethod: CanExecute_Ajouter_Ue);
            ue = new Ue();
            monBD = new AccesBD();
            List<Ue> listUe;
            listUe = this.monBD.ListeUe();
            DataTable dt = new DataTable();

            dt.Columns.Add("Idue");
            dt.Columns.Add("Libelle");
            dt.Columns.Add("Nbreperiodes");
            dt.Columns.Add("Section");

            // prépare la liste des section à afficher 
            if (listUe != null)
            {
                while (listUe.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idue"] = listUe[0].Idue;
                    dr["Libelle"] = listUe[0].Libelle;
                    dr["Nbreperiodes"] = listUe[0].Nbreperiodes;
                    dr["Section"] = listUe[0].Section;
                    dt.Rows.Add(dr);
                    listUe.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                dv.Sort = "Libelle ASC";
                CollectionUe = dv;


            }


            // UEACADEMIQUE //
            Click_Ajouter_UeAca = new CommandMenu(onExecuteMethod: Execute_Ajouter_UeAca, onCanExecuteMethod: CanExecute_Ajouter_UeAca);
            ueAca = new UeAnneeAcademique();
            monBD = new AccesBD();
            List<UeAnneeAcademique> listUeAca;
            listUeAca = this.monBD.ListeUeAca();
            DataTable dtt = new DataTable();

            dtt.Columns.Add("Idue");
            dtt.Columns.Add("DateDebut");
            dtt.Columns.Add("DateFin");

            // prépare la liste des ue academique à afficher 
            if (listUeAca != null)
            {
                while (listUeAca.Count > 0)
                {
                    DataRow drr = dtt.NewRow();
                    drr["Idue"] = listUeAca[0].Idue;
                    // Pour la date de début
                    drr["DateDebut"] = listUeAca[0].DateDebut.ToString("dd-MM-yyyy");

                    // Pour la date de fin
                    drr["DateFin"] = listUeAca[0].DateFin.ToString("dd-MM-yyyy");
                    dtt.Rows.Add(drr);
                    listUeAca.RemoveAt(0);
                }

                DataView dvv = new DataView(dtt);
                CollectionUeAca = dvv;

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
            this.DateDebut = DateTime.MinValue;
            this.Idue = -1;
            this.DateFin = DateTime.MinValue;

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
        public void Execute_Ajouter_Ue(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterUe(this.ue);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionUe.Table.NewRow();
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
                "Une erreur est survenue pendant l'ajout de l'ue :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Ue(object parameter)
        {
            return true;
        }




        ////// UEACADEMIQUE //////

        DataView collectionUeAca;
        public DataView CollectionUeAca
        {
            get { return collectionUeAca; }
            set
            {
                collectionUeAca = value;
                OnPropertyChanged("CollectionUeAca");
            }
        }

        // propriété UeAnneeAcademique pour modification et ajout

        private UeAnneeAcademique ueAca { get; set; }


        // Propriété Idue: utilisé pour la personne modifiée ou ajoutée
        public int Idue
        {
            get { return this.ueAca.Idue; }
            set
            {
                this.ueAca.Idue = value;
                OnPropertyChanged("Idue");
            }
        }

        // Propriété DateTime: utilisé pour la personne modifiée ou ajoutée
        public DateTime DateDebut
        {
            get { return this.ueAca.DateDebut; }
            set
            {
                this.ueAca.DateDebut = value;
                OnPropertyChanged("DateDebut");
            }
        }

        // Propriété Datefin: utilisé pour la personne modifiée ou ajoutée
        public DateTime DateFin
        {
            get { return this.ueAca.DateFin; }
            set
            {
                this.ueAca.DateFin = value;
                OnPropertyChanged("DateFin");
            }
        }


        public ICommand Click_Ajouter_UeAca { get; set; }




        // ajout de la catégorie dans la BD
        public void Execute_Ajouter_UeAca(object parameter)
        {
            try
            {
                int resultatAjoutt = monBD.AjouterUeAnneeAcademiqueDateSeance(this.ueAca, this.Idue);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow drr = CollectionUeAca.Table.NewRow();
                    drr["Idue"] = this.ueAca.Idue;
                    drr["DateDebut"] = this.ueAca.DateDebut;
                    drr["DateFin"] = this.ueAca.DateFin;
                    CollectionUe.Table.Rows.Add(drr);

                }
                this.Idue = 0;
                this.DateFin = DateTime.MinValue;
                this.DateDebut = DateTime.MinValue;
            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Une erreur est survenue pendant l'ajout de l'ue académique :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_UeAca(object parameter)
        {
            return true;
        }




    }
}
