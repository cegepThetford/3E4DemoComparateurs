using System.Collections.Generic;

namespace CampsScientifiques_Affaire
{
    public class ComparateurDouble<T> : IComparer<T>
    {
        private IComparer<T> _premierComparateur;
        private IComparer<T> _secondComparateur;
        public IComparer<T> PremierComparateur {
            get { return _premierComparateur; }
            set { _premierComparateur = value; } }
        public IComparer<T> SecondComparateur
        {
            get { return _secondComparateur; }
            set { _secondComparateur = value; }
        }
        public ComparateurDouble(IComparer<T> premier, IComparer<T> second)
        {
            _premierComparateur = premier;
            _secondComparateur = second;
        }
        public int Compare(T x, T y)
        {
            int resultat = _premierComparateur.Compare(x, y);
            if (resultat == 0)
                resultat = _secondComparateur.Compare(x, y);
            return resultat;
        }
    }
}