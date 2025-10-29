using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Eleve
    {

        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;

        private List<Note> _notes = new List<Note>();

        public Eleve(string firstName, string lastName)
        {
            Prenom = firstName;
            Nom = lastName;
        }

        public void AjouterNote(Note note)
        {
            if (_notes.Contains(note))
                return;

            _notes.Add(note);
        }

        public float MoyenneMatiere(int i)
        {
            float moyenne = 0;
            int count = 0;

            foreach (var note in _notes)
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
            float moyenne = 0;
            int count = _notes.Count;

            foreach (var note in _notes)
            {
                moyenne += note.note;
            }

            if (count == 0)
                return 0;

            return (float)(Math.Truncate((moyenne / count) * 100) / 100);
        }

    }
}
