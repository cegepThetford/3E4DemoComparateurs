using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class ComparateurAge : IComparer<Jeune>
    {
        public int Compare(Jeune x, Jeune y)
        {
            int ageX = x.calculerAge();
            int ageY = y.calculerAge();
            return ageX - ageY;
        }
    }
}
