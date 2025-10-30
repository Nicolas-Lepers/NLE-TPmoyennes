
namespace HNI_TPmoyennes
{
    internal class Eleve
    {

        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;

        public List<Note> Notes { get; private set; } = new List<Note>();

        public Eleve(string firstName, string lastName)
        {
            Prenom = firstName;
            Nom = lastName;
        }

        public void AjouterNote(Note note)
        {
            //il est possible d'avoir plusieurs fois la même note dans la même matière
            if (/*_notes.Contains(note)||*/ Notes.Count >= 200)
            {
                Console.WriteLine("L'élève ne peux pas recevoir plus de notes.");
                return;
            }

            Notes.Add(note);
        }

        public float MoyenneMatiere(int i)
        {
            float moyenne = 0;
            int count = 0;

            foreach (var note in Notes)
            {
                if (note.matiere == i)
                {
                    moyenne += note.note;
                    count++;
                }
            }

            if (count == 0)
                return 0;

            return (float)(Math.Truncate((moyenne / count) * 100) / 100);
        }

        public float MoyenneGeneral()
        {
            var matieres = Notes.Select(n => n.matiere).Distinct();
            float moyenneG = 0;
            int count = matieres.Count();

            foreach (var matiere in matieres)
            {
                moyenneG += MoyenneMatiere(matiere);
            }

            if (count == 0)
                return 0;

            return (float)(Math.Truncate((moyenneG / count) * 100) / 100);
        }

    }
}
