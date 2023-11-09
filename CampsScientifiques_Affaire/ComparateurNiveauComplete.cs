using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class ComparateurNiveauComplete : IComparer<Jeune>
    {
        public int Compare(Jeune x, Jeune y)
        {
            return x.NiveauComplete - y.NiveauComplete;
        }
    }
}
