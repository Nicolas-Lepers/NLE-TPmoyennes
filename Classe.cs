using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Classe
    {
        public string NomClasse { get; set; } = string.Empty;
        public List<Eleve> Eleves { get; set; } = new List<Eleve>();
        public List<string> Matieres { get; set; } = new List<string>();


        public Classe(string classeName)
        {
            NomClasse = classeName;
        }

        public void AjouterEleve(string firstName, string lastName)
        {
            if (Eleves.Count >= 30)
            {
                Console.WriteLine("Trop d'élèves.");
                return;
            }

            var eleve = new Eleve(firstName, lastName);
            if (Eleves.Contains(eleve))
            {
                Console.WriteLine("L'élève est déjà dans la classe.");
                return;
            }

            Eleves.Add(eleve);
        }
        public void AjouterMatiere(string matiere)
        {
            if(Matieres.Contains(matiere) || Matieres.Count >= 10)
            {
                Console.WriteLine("Trop de matières, ou matière déjà enregistrée.");
                return;
            }

            Matieres.Add(matiere);
        }

        public float MoyenneMatiere(int i)
        {
            float moyenne = 0;
            int count = Eleves.Count;

            foreach (var eleve in Eleves)
            {
                moyenne += eleve.MoyenneMatiere(i);
            }

            if (count == 0)
                return 0;

            return (float)(Math.Truncate((moyenne / count) * 100) / 100);
        }
        public float MoyenneGeneral()
        {
            var matieres = Eleves.SelectMany(e => e.Notes.Select(n => n.matiere)).Distinct();
            float moyenneG = 0;
            int count = matieres.Count();

            if (count == 0)
                return 0;

            foreach (var matiere in matieres)
            {
                moyenneG += MoyenneMatiere(matiere);
            }

            return (float)(Math.Truncate((moyenneG / count) * 100) / 100);
        }

    }
}
