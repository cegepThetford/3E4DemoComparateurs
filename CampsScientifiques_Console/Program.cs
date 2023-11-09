using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampsScientifiques_Affaire;

namespace CampsScientifiques_Console
{
    class Program
    {
        private static Jeune _adam, _bernard, _charles, _denis, _eric, _felix, _guylaine, _helene, _ian, _jacob, _kim;
        private static List<Jeune> _jeunes;
        static void Main(string[] args)
        {
            initialisation();

            afficherJeunes("Ordre initial");

            _jeunes.Sort(new ComparateurAge());
            afficherJeunes("Ordre d'âge");

            _jeunes.Sort(new ComparateurInverse<Jeune>(new ComparateurAge()));
            afficherJeunes("Ordre d'âge (inverse)");

            _jeunes.Sort(
                new ComparateurDouble<Jeune>(
                    new ComparateurInverse<Jeune>(new ComparateurAge()),
                    new ComparateurNom()
                    )
            );
            afficherJeunes("Ordre d'âge (inverse V2)");

            _jeunes.Sort(new ComparateurLongueurNom());
            afficherJeunes("Ordre de longueur de nom");

            _jeunes.Sort(new ComparateurNom());
            afficherJeunes("Ordre alphabétique de nom");

            IComparer<Jeune> comparateur = new ComparateurNiveauComplete();
            _jeunes.Sort(comparateur);
            afficherJeunes("Ordre de niveau complété");

            Console.ReadLine();

        }
        private static void afficherJeunes(string titre)
        {
            Console.WriteLine(titre);
            foreach (Jeune unJeune in _jeunes)
                Console.WriteLine("  {0} ({1} ans, niveau {2})", unJeune.Nom, unJeune.calculerAge(), unJeune.NiveauComplete);
        }

        private static void initialisation()
        {
            _adam = new Jeune("Adam", DateTime.Now.AddYears(-15), 3);
            _bernard = new Jeune("Bernard", DateTime.Now.AddYears(-14), 2);
            _charles = new Jeune("Charles", DateTime.Now.AddYears(-17), 1);
            _denis = new Jeune("Denis", DateTime.Now.AddYears(-16), 3);
            _eric = new Jeune("Eric", DateTime.Now.AddYears(-18), 4);
            _felix = new Jeune("Felix", DateTime.Now.AddYears(-19), 2);
            _guylaine = new Jeune("Guylaine", DateTime.Now.AddYears(-13), 1);
            _helene = new Jeune("Helene", DateTime.Now.AddYears(-20), 5);
            _ian = new Jeune("Ian", DateTime.Now.AddYears(-20), 7);
            _jacob = new Jeune("Jacob", DateTime.Now.AddYears(-20), 8);
            _kim = new Jeune("Kim", DateTime.Now.AddYears(-15), 3);

            _jeunes = new List<Jeune>();
            _jeunes.Add(_kim);
            _jeunes.Add(_jacob);
            _jeunes.Add(_adam);
            _jeunes.Add(_bernard);
            _jeunes.Add(_charles);
            _jeunes.Add(_ian);
            _jeunes.Add(_helene);
            _jeunes.Add(_eric);
            _jeunes.Add(_denis);
            _jeunes.Add(_guylaine);
            _jeunes.Add(_felix);
        }

    }
}
