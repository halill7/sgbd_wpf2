using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Section
    {
        private string libelle;
        private Section section;
        private string idsection;

        public Section() { 
        
        }

        public Section(string libelle, string idsection)
        {
            this.libelle = libelle;
            this.idsection = idsection;
        }

        public Section(Section section)
        {
            this.section = section;

        }


        public Section(string libelle)
        {
            this.libelle = libelle;

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

        public string IdSection
        {
            set
            {
                this.idsection = value;
            }

            get
            {
                return this.idsection;
            }
        }
    }
}
