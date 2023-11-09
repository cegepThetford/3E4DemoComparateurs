using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class Camp
    {
        private string _titre;
        private int _niveauRequis;
        private int _ageRequis;

        public Camp(string titre, int niveau, int age)
        {
            _titre = titre;
            _niveauRequis = niveau;
            _ageRequis = age;
        }

        public string Titre { get { return _titre; } set { _titre = value; } }
        public int NiveauRequis { get { return _niveauRequis; } set { _niveauRequis = value; } }
        public int AgeRequis { get { return _ageRequis; } set { _ageRequis = value; } }

        public override bool Equals(object obj)
        {
            bool equivalence = false;
            Camp autre = obj as Camp;
            if (autre != null)
                equivalence = _titre.Equals(autre.Titre) &&
                              _niveauRequis == autre.NiveauRequis &&
                              _ageRequis == autre.AgeRequis;
            return equivalence;
        }
        public override int GetHashCode()
        {
            return new { _titre, _niveauRequis, _ageRequis}.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_titre} (N:{_niveauRequis},A:{_ageRequis})";
        }

    }
}
