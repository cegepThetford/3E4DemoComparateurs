using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampsScientifiques_Affaire
{
    public class Bottin
    {
        private List<Camp> _camps;

        public Bottin()
        {
            _camps = new List<Camp>();
        }
        public void ajouterCamp(Camp unCamp)
        {
            _camps.Add(unCamp);
        }
        public int denombrerCampsAdmissibles(Jeune unJeune)
        {
            int compteur = 0;
            foreach (Camp c in _camps)
                if (unJeune.estAdmissible(c))
                    compteur++;
            return compteur;
        }
        public List<Camp> extraireCampsAdmissibles(Jeune unJeune)
        {
            List<Camp> extraction = new List<Camp>();
            foreach (Camp c in _camps)
                if (unJeune.estAdmissible(c))
                    extraction.Add(c);
            return extraction;
        }
        public int denombrerCamps(int unNiveau)
        {
            int compteur = 0;
            foreach (Camp c in _camps)
                if (c.NiveauRequis == unNiveau)
                    compteur++;
            return compteur;
        }
        public int determinerAgeMinRequis(int unNiveau)
        {
            int ageMin = 99;
            foreach (Camp c in _camps)
                if (unNiveau == c.NiveauRequis && c.AgeRequis < ageMin)
                    ageMin = c.AgeRequis;
            if (ageMin == 99)
                return 0;
            return ageMin;
        }
        
        public List<Camp> Camps { get { return _camps; } set { _camps = value; } }

        public override bool Equals(object obj)
        {
            bool equivalence = false;
            Bottin autre = obj as Bottin;
            if (autre != null)
                equivalence = _camps.SequenceEqual(autre.Camps);
            return equivalence;
        }
        public override int GetHashCode()
        {
            return _camps.GetHashCode();
        }
    }
}
