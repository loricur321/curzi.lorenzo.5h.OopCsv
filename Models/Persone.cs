using System.Collections.Generic;
using System.IO;
using System.Text;

namespace curzi.lorenzo._5h.OopCsv.Models
{
    public class Persone : List<Persona>
    {
        /// <summary>
        /// Costruttore di default
        /// </summary>
        public Persone() { }

        /// <summary>
        /// Costruttore che accetta in ingresso il file CSV da leggere
        /// </summary>
        /// <param name="fileName">Nome del file da leggere</param>
        public Persone(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            sr.ReadLine(); //Scarto la prima riga contenente la intestazione dei valori

            while(!sr.EndOfStream)
                this.Add(new Persona(sr.ReadLine())); //Aggiugo alla lista le persone lette dal file

            sr.Close();
        }

        /// <summary>
        /// Override del metodo ToString
        /// </summary>
        /// <returns>Stringa contentente la lista di tutte le persone presenti in _persone</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var p in this)
                sb.AppendLine(p.ToString());

            return sb.ToString();
        }
    }
}