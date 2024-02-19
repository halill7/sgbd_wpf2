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
using System.Reflection;

namespace sgbd_wpf.vue_modele
{
    internal class GestionInscriptionVueModele : INotifyPropertyChanged
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

        DataView collectionInscription;
        public DataView CollectionInscription
        {
            get { return collectionInscription; }
            set
            {
                collectionInscription = value;
                OnPropertyChanged("CollectionInscription");
            }
        }

        // propriété personne pour modification et ajout

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


        public ICommand Click_Ajouter_Inscription { get; set; }
        public ICommand Click_Modifier_Resultat { get; set; }


        public GestionInscriptionVueModele()
        {
            Click_Ajouter_Inscription = new CommandMenu(onExecuteMethod: Execute_Ajouter_Inscription, onCanExecuteMethod: CanExecute_Ajouter_Inscription);
            Click_Modifier_Resultat = new CommandMenu(onExecuteMethod: Execute_Modifier_Resultat, onCanExecuteMethod: CanExecute_Modifier_Resultat);
            inscris = new Inscription();
            monBD = new AccesBD();
            List<Inscription> listInscription;
            listInscription = this.monBD.ListeInscris();
            DataTable dt = new DataTable();

            
            dt.Columns.Add("Idue");
            dt.Columns.Add("Idpersonne");
            dt.Columns.Add("Resultat");

            // prépare la liste des section à afficher 
            if (listInscription != null)
            {
                while (listInscription.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Idue"] = listInscription[0].Idue;
                    dr["Idpersonne"] = listInscription[0].Idpersonne;
                    dr["Resultat"] = listInscription[0].Resultat;
                    dt.Rows.Add(dr);
                    listInscription.RemoveAt(0);
                }

                DataView dv = new DataView(dt);
                CollectionInscription = dv;


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

        public void Modifier(int indexSelection)
        {
            if (indexSelection >= 0 && indexSelection < CollectionInscription.Count)
            {
                DataRowView rowView = CollectionInscription[indexSelection];

                // Conversion sécurisée de la valeur de IdPersonne
                if (int.TryParse(rowView["IdPersonne"].ToString(), out int idPersonne))
                {
                    Idpersonne = idPersonne;
                }
                else
                {
                    // Gérer le cas où la conversion échoue
                    // Vous pouvez assigner une valeur par défaut ou afficher un message d'erreur
                }

                // Conversion sécurisée de la valeur de Resultat
                if (int.TryParse(rowView["Resultat"].ToString(), out int resultat))
                {
                    Resultat = resultat;
                }
                else
                {
                    // Gérer le cas où la conversion échoue
                    // Vous pouvez assigner une valeur par défaut ou afficher un message d'erreur
                }

                // Mise à jour du bouton d'action
                this.Effectuer = "Effectuer la modification";
            }
        }


        // Cette méthode est utlisée lorsqu'on clique sur le bouton d'action
        public string EffectuerAction(int index)
        {
            if (this.effectuer == "Effectuer la modification")
            {
                // Met à jour la personne dans la base de données.
                int resultat = this.monBD.ModifierResultat(this.Idue, this.Idpersonne, this.Resultat);

                if (resultat != 0)
                {
                    // Mise à jour de la liste des personnes affichée
                    DataRowView rowView = collectionInscription[index];
                    int idPersonne = (int)rowView["IdPersonne"];

                    // Supprime la ligne actuelle
                    collectionInscription.Delete(index);

                    // Insère une nouvelle ligne avec les données mises à jour
                    DataRowView newRow = collectionInscription.AddNew();
                    newRow["IdPersonne"] = idPersonne;
                    newRow["Resultat"] = this.Resultat;

                    // Valide les modifications
                    collectionInscription.EndInit();

                    // Initialisation des champs de la personne
                    // à modifier ou à ajouter
                    this.Clear_personne();

                    this.Effectuer = "";

                    return "La modification s'est bien déroulée.";
                }
                else
                {
                    return "La modification ne s'est pas bien déroulée.";
                }
            }

            return "yes";
        }





        // Cette méthode met à vide les champs de la personne à modifier 
        private void Clear_personne()
        {
            this.Idpersonne = -1;
            this.Idue = -1;
            this.Resultat = -1;

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
        public void Execute_Ajouter_Inscription(object parameter)
        {
            try
            {
                int resultatAjout = monBD.AjouterEtudiantUe(this.Idpersonne, this.Idue);
                {
                    // mise à jour de la liste des catégorie affichée
                    DataRow dr = CollectionInscription.Table.NewRow();
                    dr["Idpersonne"] = this.inscris.Idpersonne;
                    dr["Idue"] = this.inscris.Idue;
                    CollectionInscription.Table.Rows.Add(dr);

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
                "Une erreur est survenue pendant l'ajout de l'incritpion à l'ue :\n" +
                    ex.Message,
                 "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Ajouter_Inscription(object parameter)
        {
            return true;
        }


        public void Execute_Modifier_Resultat(object parameter)
        {
            try
            {
                // Modifier le résultat dans la base de données
                int resultatModification = monBD.ModifierResultat(this.Idue, this.Idpersonne, this.Resultat);

                // Rechercher la ligne correspondante dans la table des inscriptions
                DataRow[] rowsToUpdate = CollectionInscription.Table.Select($"Idue = {this.Idue} AND Idpersonne = {this.Idpersonne}");
                foreach (DataRow rowToUpdate in rowsToUpdate)
                {
                    // Mettre à jour le résultat dans la ligne correspondante
                    rowToUpdate["Resultat"] = this.Resultat;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Une erreur est survenue pendant la modification du résultat :\n" +
                    ex.Message,
                    "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Le nom de la catégorie doit au moins avoir 3 caractères
        public bool CanExecute_Modifier_Resultat(object parameter)
        {
            return true;
        }


    }
}
