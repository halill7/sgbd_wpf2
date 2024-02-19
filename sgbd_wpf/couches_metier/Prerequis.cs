using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_metier
{
    class Prerequis
    {
        private int idue;
        private string ueprerequis;

        public Prerequis()
        {
          
        }
        public Prerequis(int idue, string ueprerequis)
        {
            this.idue = idue;
            this.ueprerequis = ueprerequis;
        }



    }
}
