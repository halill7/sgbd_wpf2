using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    class Personne
    {
        private int idPersonne;
        private string nom;
        private string prenom;
        private char sexe;
        private string gsm;
        private string rue;
        private string codepostal;
        private string localite;


        public Personne()
        {

        }


        public Personne(int idpersonne, string nom, string prenom, char sexe, string gsm, string rue, string codepostal, string localite)
        {
            this.idPersonne = idpersonne;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.gsm = gsm;
            this.rue = rue;
            this.codepostal = codepostal;
            this.localite = localite;
        }
        public Personne(string nom, string prenom, char sexe, string gsm, string rue, string codepostal, string localite)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.gsm = gsm;
            this.rue = rue;
            this.codepostal = codepostal;
            this.localite = localite;
        }


        public Personne(int idpersonne, string nom, string prenom)
        {
            this.idPersonne = idpersonne;
            this.nom = nom;
            this.prenom = prenom;
        }

        public int IdPersonne
        {
            set
            {
                this.idPersonne = value;
            }

            get
            {
                return this.idPersonne;
            }
        }

        public string Nom
        {
            set
            {
                this.nom = value;
            }

            get
            {
                return this.nom;
            }
        }

        public string Prenom
        {
            set
            {
                this.prenom = value;
            }

            get
            {
                return this.prenom;
            }
        }

        public char Sexe
        {
            set
            {
                this.sexe = value;
            }

            get
            {
                return this.sexe;
            }
        }

        public string Gsm
        {
            set
            {
                this.gsm = value;
            }

            get
            {
                return this.gsm;
            }
        }

        public string Rue
        {
            set
            {
                this.rue = value;
            }

            get
            {
                return this.rue;
            }
        }

        public string Codepostal
        {
            set
            {
                this.codepostal = value;
            }

            get
            {
                return this.codepostal;
            }
        }

        public string Localite
        {
            set
            {
                this.localite = value;
            }

            get
            {
                return this.localite;
            }
        }

        /*public string setEmail(string Email)
        {

        }*/
    }
}
