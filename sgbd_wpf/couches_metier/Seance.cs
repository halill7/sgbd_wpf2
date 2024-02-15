using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    internal class Seance
    {
        private int idseance;
        private int idue;
        private DateTime dateseance;

        public Seance() { }

        public Seance(int idseance, DateTime dateseance, int idue)
        {
            this.idseance = idseance;
            this.dateseance = dateseance;
            this.idue = idue;
        }

        public Seance(int idseance, DateTime dateseance)
        {
            this.idseance = idseance;
            this.dateseance = dateseance;
        }

        public DateTime DateSeance
        {
            set
            {
                this.dateseance = value;
            }

            get
            {
                return this.dateseance;
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
    }
}
