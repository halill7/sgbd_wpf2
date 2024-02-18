using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Etudiant : Personne
    {
      
        private string email;
        private int choix;
        private Etudiant etudiant;
        private int idpersonne;


        public Etudiant()
        {
        
        }

        public Etudiant(Etudiant etudiant)
        {
            this.etudiant = etudiant;
        }

        /**public Etudiant(int idPersonne, string nom, string prenom, char sexe, string gsm1, string rue, string codepostal1, string localite) : base(nom, prenom, sexe,gsm1, rue, codepostal1, localite)
        {
            IdPersonne = idPersonne;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            this.gsm1 = gsm1;
            Rue = rue;
            this.codepostal1 = codepostal1;
            Localite = localite;
        }**/
        public Etudiant(int idpersonne, string nom, string prenom, char sexe, string gsm, string rue, string codepostal, string localite, string email)
            : base(idpersonne, nom, prenom, sexe, gsm, rue, codepostal, localite)
        {
            this.email = email;
        }



        public Etudiant(int idpersonne, string nom, string prenom, string email)
    : base(idpersonne, nom, prenom)
        {
            this.email = email;
        }


        public int Idpersonne
        {
            set { this.idpersonne = value; }
            get { return this.idpersonne; }
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

        public int Choix
        {
            set
            {
                this.choix = value;
            }

            get
            {
                return this.choix;
            }
        }
    }

}
