using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class UeAnneeAcademique:Ue
    {
        private DateTime dateDebut;
        private DateTime dateFin;
        private string matricule;
        private int idue;

        public UeAnneeAcademique()
        {

        }

        public UeAnneeAcademique(int idue, string libelle, int nbreperiodes, string section) : base(idue,libelle, nbreperiodes, section)
        {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
        }


        public UeAnneeAcademique(int idue, DateTime datedebut, DateTime datefin)
        {
            this.idue = idue;
            this.dateDebut = datedebut;
            this.dateFin = datefin;
        }


        public DateTime DateDebut
        {
            set
            {
                this.dateDebut = value;
            }

            get
            {
                return this.dateDebut;
            }
        }

        public DateTime DateFin
        {
            set
            {
                this.dateFin = value;
            }

            get
            {
                return this.dateFin;
            }
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
    }
}
