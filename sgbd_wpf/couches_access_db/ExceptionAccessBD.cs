using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_sgbd.couches_access_db
{
    internal class ExceptionAccessBD : Exception
    {
        public ExceptionAccessBD(string message, Exception ex) : base(message)
        {
            // Vous pouvez ajouter du code supplémentaire ici, si nécessaire.
        }
    }
}
