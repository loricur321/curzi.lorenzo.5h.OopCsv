using System;
using System.Text;

namespace curzi.lorenzo._5h.OopCsv.Models
{
    public class Persona
    {
        /// <summary>
        /// Field dell'attributo ID
        /// </summary>
        int _id;

        /// <summary>
        /// Property del field _id
        /// </summary>
        public int ID
        {
            get => _id;

            //Impongo che il valore dell'id sia maggiore di zero tramite un controllo
            //In caso si cerchi di scrivere in _id un valore minimo di 0 il programma lancierà un'eccezione
            set
            {
                if (value < 0)
                    throw new Exception("Il valore del campo ID deve essere maggiore di zero.");
                else
                    _id = value;
            }
        }

        /// <summary>
        /// Property Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Property Cognome
        /// </summary>
        public string Cognome { get; set; }

        /// <summary>
        /// Field dell'attributo OreLezione
        /// </summary>
        int _oreLezione;

        /// <summary>
        /// Property del field _oreLezione
        /// </summary>
        public int OreLezione
        {
            get => _oreLezione;

            //Impongo che il valore dell'id sia maggiore di zero tramite un controllo
            //nel campo set della property.
            //In caso si cerchi di scrivere in _id un valore maggiore di 60 il programma lancierà un'eccezione
            set
            {
                if (value < 0)
                    throw new Exception("Il numero di ore di lezione deve essere compreso tra 0 e 60");
                else
                    _oreLezione = value;
            }
        }

        /// <summary>
        /// Field dell'attributo Tipo
        /// </summary>
        string _tipo;

        /// <summary>
        /// Property del field _tipo
        /// </summary>
        public string Tipo
        {
            get => _tipo;

            set
            {
                //In caso il dato ricevuto in ingresso non sia equivalente a IDT, ITP o ATA
                //lancio una eccezione ricordando le tre possibilità possibili
                if(value != "IDT" && value != "ITP" && value != "ATA")
                    throw new Exception("Il campo tipo può assumere i seguenti valori: IDT, ITP o ATA.");
                else
                    _tipo = value;
            }
        }

        /// <summary>
        /// Costruttore di default
        /// </summary>
        public Persona() { }

        /// <summary>
        /// Costruttore standard
        /// </summary>
        /// <param name="id">Id legato alla persona</param>
        /// <param name="nome">Nome della persona</param>
        /// <param name="cognome">Cognome della persona</param>
        /// <param name="oreLezione">Ore di lezione svolte dalla persona</param>
        /// <param name="tipo">Ruolo assunto dalla persona</param>
        public Persona (int id, string nome, string cognome, int oreLezione, string tipo)
        {
            ID = id;
            Nome = nome;
            Cognome = cognome;
            OreLezione = oreLezione;
            Tipo = tipo;
        }

        /// <summary>
        /// Costruttore che riceve in ingresso una riga del file CSV
        /// </summary>
        /// <param name="riga">Riga da leggere</param>
        public Persona(string riga)
        {
            string[] splittedLine = riga.Split(';');

            //Eseguo un controllo nella converesione in interro della stringa contenente il campo ID
            //e in caso di anomalie informo l'utente tramite una eccezione
            if (Int32.TryParse(splittedLine[0], out int result))
                ID = result;
            else
                throw new Exception("Il valore del campo ID deve essere un numero maggiore di zero.");

            Nome = splittedLine[1];
            Cognome = splittedLine[2];

            //Eseguo un controllo nella converesione in interro della stringa contenente il campo OreLezione
            //e in caso di anomalie informo l'utente tramite una eccezione
            if (Int32.TryParse(splittedLine[3], out result))
                OreLezione = result;
            else
                throw new Exception("Il valore del campo OreLezione deve essere un numero compreso tra 0 e 60.");

            Tipo = splittedLine[4];
        }

        /// <summary>
        /// Override del metodo ToString
        /// </summary>
        /// <returns>Stringa contenente tutte le informazioni della persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"ID:\t\t{ID}");
            sb.AppendLine($"Nome:\t\t{Nome}");
            sb.AppendLine($"Cognome:\t{Cognome}");
            sb.AppendLine($"Ore Lezione:\t{OreLezione}");
            sb.AppendLine($"Tipo:\t\t{Tipo}");

            return sb.ToString();
        }
    }
}