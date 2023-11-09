using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class ComparateurNom : IComparer<Jeune>
    {
        public int Compare(Jeune x, Jeune y)
        {
            return x.Nom.CompareTo(y.Nom);
        }
    }
}
