using System;
using System.Collections.Generic;
using System.Linq;

namespace HNI_TPmoyennes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création d'une classe
            Classe sixiemeA = new Classe("6eme A");
            // Ajout des élèves à la classe
            sixiemeA.AjouterEleve("Jean", "RAGE");
            sixiemeA.AjouterEleve("Paul", "HAAR");
            sixiemeA.AjouterEleve("Sibylle", "BOQUET");
            sixiemeA.AjouterEleve("Annie", "CROCHE");
            sixiemeA.AjouterEleve("Alain", "PROVISTE");
            sixiemeA.AjouterEleve("Justin", "TYDERNIER");
            sixiemeA.AjouterEleve("Sacha", "TOUILLE");
            sixiemeA.AjouterEleve("Cesar", "TICHO");
            sixiemeA.AjouterEleve("Guy", "DON");

            // Ajout de matières étudiées par la classe
            sixiemeA.AjouterMatiere("Francais");
            sixiemeA.AjouterMatiere("Anglais");
            sixiemeA.AjouterMatiere("Physique/Chimie");
            sixiemeA.AjouterMatiere("Histoire");

            Random random = new Random();
            // Ajout de 5 notes à chaque élève et dans chaque matière
            for (int ieleve = 0; ieleve < sixiemeA.Eleves.Count; ieleve++)
            {
                for (int matiere = 0; matiere < sixiemeA.Matieres.Count; matiere++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        //simplifacation pour tronquer la note a 2 chiffre apres la virgule
                        var note = (float)((6.5 + random.NextDouble() * 34)) / 2.0f;
                        sixiemeA.Eleves[ieleve].AjouterNote(new Note(matiere, note));
                        // Note minimale = 3
                    }
                }
            }

            Eleve eleve = sixiemeA.Eleves[6];
            // Afficher la moyenne d'un élève dans une matière
            Console.Write(eleve.Prenom + " " + eleve.Nom + ", Moyenne en " + sixiemeA.Matieres[1] + " : " +
            eleve.MoyenneMatiere(1) + "\n");
            // Afficher la moyenne générale du même élève
            Console.Write(eleve.Prenom + " " + eleve.Nom + ", Moyenne Generale : " + eleve.MoyenneGeneral() + "\n");
            // Afficher la moyenne de la classe dans une matière
            Console.Write("Classe de " + sixiemeA.NomClasse + ", Moyenne en " + sixiemeA.Matieres[1] + " : " +
            sixiemeA.MoyenneMatiere(1) + "\n");
            // Afficher la moyenne générale de la classe
            Console.Write("Classe de " + sixiemeA.NomClasse + ", Moyenne Generale : " + sixiemeA.MoyenneGeneral() + "\n");
            Console.Read();
        }
    }
}



