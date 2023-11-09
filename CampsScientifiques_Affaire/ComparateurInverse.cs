using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class ComparateurInverse<T> : IComparer<T>
    {
        private IComparer<T> _autreComparateur;
        public IComparer<T> AutreComparateur { get { return _autreComparateur; } set { _autreComparateur = value; }}
        public ComparateurInverse(IComparer<T> autreComparateur)
        {
            _autreComparateur = autreComparateur;
        }
        public int Compare(T x, T y)
        {
            //return _autreComparateur.Compare(y, x);
            return -_autreComparateur.Compare(x, y);
        }
    }
}
