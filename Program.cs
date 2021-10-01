using System;
using curzi.lorenzo._5h.OopCsv.Models;

namespace curzi.lorenzo._5h.OopCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma OopCsv di Lorenzo Curzi 5H, 25/09/2021");

            Persone listaPersone = new Persone("in.csv");

            Console.WriteLine(listaPersone);
        }
    }
}
