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
            var eleve = new Eleve(firstName, lastName);
            if (Eleves.Contains(eleve))
                return;

            Eleves.Add(eleve);
        }
        public void AjouterMatiere(string matiere)
        {
            if(Matieres.Contains(matiere)) 
                return;

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
            float moyenne = 0;
            int count = Eleves.Count;

            foreach (var eleve in Eleves)
            {
                moyenne += eleve.MoyenneGeneral();
            }

            if (count == 0)
                return 0;

            return (float)(Math.Truncate((moyenne / count) * 100) / 100);
        }

    }
}
