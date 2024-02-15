using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Participation
    {
        private int idue;
        private int idpersonne;
        private int idseance;
        private string statut;
        
        
        public Participation()
        {

        }

        public Participation(int idue, int idpersonne, int idseance, string statut)
        {
            this.idue = idue;
            this.idpersonne = idpersonne;
            this.idseance = idseance;
            this.statut = statut;
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

        public int Idseance
        {
            set
            {
                this.idseance = value;
            }

            get
            {
                return this.idseance;
            }
        }

        public string Statut
        {
            set
            {
                this.statut = value;
            }

            get
            {
                return this.statut;
            }
        }
    }
}
