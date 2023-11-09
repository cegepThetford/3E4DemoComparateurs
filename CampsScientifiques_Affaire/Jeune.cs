using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class Jeune
    {
        private string _nom;
        private DateTime _dateNaissance;
        private int _niveauComplete;

        public Jeune(string nom, DateTime ddn, int niveau)
        {
            _nom = nom;
            _dateNaissance = ddn;
            _niveauComplete = niveau;
        }

        public int calculerAge()
        {
            int age = DateTime.Now.Year - _dateNaissance.Year;
            if (_dateNaissance > DateTime.Now.AddYears(-age)) 
                age--;
            return age;
        }
        public bool aAgeRequis(Camp unCamp)
        {
            return this.calculerAge() >= unCamp.AgeRequis;
        }
        public bool aNiveauRequis(Camp unCamp)
        {
            return _niveauComplete >= unCamp.NiveauRequis;
        }
        public bool estAdmissible(Camp unCamp)
        {
            return this.aAgeRequis(unCamp) && this.aNiveauRequis(unCamp);
        }
        
        public string Nom { get { return _nom; } set { _nom = value; } }
        public DateTime DateNaissance { get { return _dateNaissance; } set { _dateNaissance = value; } }
        public int NiveauComplete { get { return _niveauComplete; } set { _niveauComplete = value; } }
        public override bool Equals(object obj)
        {
            bool equivalence = false;
            Jeune autre = obj as Jeune;
            if (autre != null)
                equivalence = _nom.Equals(autre.Nom) &&
                              _dateNaissance.Equals(autre.DateNaissance) &&
                              _niveauComplete == autre.NiveauComplete;
            return equivalence;
        }
        public override int GetHashCode()
        {
            return new { _nom, _dateNaissance, _niveauComplete }.GetHashCode();
        }

        public override string ToString()
        {
            return _nom;
        }
    }
}
