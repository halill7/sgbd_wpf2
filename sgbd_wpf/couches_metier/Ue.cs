using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Ue
    {
        private int idue;
        private string libelle;
        private int nbreperiodes;
        private string section;
        private int choix;
        public Ue() { }

        public Ue(int idue, string libelle, int nbreperiodes, string section)
        {
            this.idue = idue;
            this.libelle = libelle;
            this.nbreperiodes = nbreperiodes;
            this.section = section;
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

        public string Libelle
        {
            set
            {
                this.libelle = value;
            }

            get
            {
                return this.libelle;
            }
        }

        public int Nbreperiodes
        {
            set
            {
                this.nbreperiodes = value;
            }

            get
            {
                return this.nbreperiodes;
            }
        }

        public string Section
        {
            set
            {
                this.section = value;
            }

            get
            {
                return this.section;
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
