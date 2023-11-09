using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class ComparateurLongueurNom : IComparer<Jeune>
    {
        public int Compare(Jeune x, Jeune y)
        {
            int comparaison = x.Nom.Length - y.Nom.Length;
            if (comparaison == 0)
                comparaison = x.Nom.CompareTo(y.Nom);
            return comparaison;
        }
    }
}
