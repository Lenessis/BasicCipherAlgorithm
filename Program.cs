using System;

namespace BSK_podst_kryptografia
{
    class Program
    {
        

        static void Main(string[] args)
        {
            // menu
            // szyfr płotkowy - kodujący i dekodujący
            // szyfr macierzowy - macierz wielkości 5, klucz 3-4-1-5-2 ( czytanie po wierszach) - kodujacy
            // szyfr macierzowy - na podstawie słowa (czytanie po kolumnach) - trzeba wpisac slowo

            Menu();
        }

        static void Menu()
        {
            int option;
            string word = "";

            Menu:
            Console.Clear();

            Console.WriteLine("1. Szyfr płotkowy");
            Console.WriteLine("2. Szyfr Macierzowy d=5 klucz = 3-4-1-5-2");
           // Console.WriteLine("3. Szyfr Macierzowy ...");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybierz opcje: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:                   
                    Console.Write("Podaj słowo: ");
                    word = Console.ReadLine();

                    int n;
                    Console.Write("Podaj klucz n: ");
                    n = Convert.ToInt32(Console.ReadLine());

                    Fance fance = new Fance(n, word);

                    Console.WriteLine("Zakodowane słowo: "+ fance.EncodingWord()); 
                    Console.WriteLine("Rozkodowane słowo: "+ fance.CrackingWord());
                    Console.ReadKey();
                    goto Menu;
                    break;

                case 2:
                    Console.Write("Podaj słowo: ");
                    word = Console.ReadLine();

                    MatrixA mA = new MatrixA(word);

                    Console.WriteLine("Zakodowane słowo: " + mA.EncodingWord());
                    Console.ReadKey();
                    goto Menu;
                    break;

                case 3:
                    Console.ReadKey();
                    goto Menu;
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    goto Menu;
                    
            }
        }
    }
}
