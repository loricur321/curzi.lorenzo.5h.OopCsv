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
        /// Metodo che consente di calcolare il costo orario di una Persona
        /// </summary>
        /// <param name="id">Id della persona a cui calcolare il costo totale</param>
        public int CalcolaCosto(int id)
        {
            //Costo orario per ogni categoria
            const int costoATA = 10;
            const int costoIDT = 5;
            const int costoITP = 150;

            //Variabili in cui salverò le informazioni della persona cercata
            string type = "";
            int ore = 0;

            foreach(var p in this)
                if(p.ID == id)
                {
                    type = p.Tipo;
                    ore = p.OreLezione;
                }

            //Una volta trovata la persona cercata calcolo il costo totale e ritorno il valore
            switch(type)
            {
                case "ATA":
                    return ore * costoATA;
                case "IDT":
                    return ore * costoIDT;
                case "ITP":
                    return ore * costoITP;
                default: 
                    return 0;
            }
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