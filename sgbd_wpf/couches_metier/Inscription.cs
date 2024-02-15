using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Inscription
    {
        private int idpersonne;
        private int idue;
        private int resultat;

        UeAnneeAcademique ue = new UeAnneeAcademique();
        Etudiant etudiant = new Etudiant();

        public Inscription() { }

        public Inscription(int idue)
        {
            this.idue = idue;
        }

        public Inscription(int idue, int idpersonne)
        {
            this.idue = idue;
            this.idpersonne = idpersonne;   
        }

        public Inscription(int idue, int idpersonne, int resultat)
        {
            this.idue = idue;
            this.idpersonne = idpersonne;
            this.resultat = resultat;  
        }


        public int Idpersonne
        {
            set
            {
                this.idpersonne = value;
            }

            get
            {
                return this.idpersonne;
            }
        }

        public int Idue
        {
            set
            {
                this.idue = value;
            }

            get
            {
                return this.idue;
            }
        }

        public int Resultat
        {
            set
            {
                this.resultat = value;
            }

            get
            {
                return this.resultat;
            }
        }
    }
}
