using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Professeur : Personne
    {
        private string matricule;
        private string email;
        public Professeur()
        {
        }

        public Professeur(string nom, string prenom, char sexe, string gsm, string rue, string codepostal, string localite, string matricule, string email) : base(nom, prenom, sexe, gsm, rue, codepostal, localite)
        {
            this.matricule = matricule;
            this.email = email;
        }


        public Professeur(int idpersonne, string nom, string prenom, char sexe, string gsm, string rue, string codepostal, string localite, string matricule
            ,string email)
        : base(idpersonne, nom, prenom, sexe, gsm, rue, codepostal, localite)
        {
            this.matricule = matricule;
            this.email = email;
        }


        public string Matricule
        {
            set
            {
                this.matricule = value;
            }

            get
            {
                return this.matricule;
            }
        }

        public string Email
        {
            set
            {
                this.email = value;
            }

            get
            {
                return this.email;
            }
        }
    }
}
