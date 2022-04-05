using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_podst_kryptografia
{
    class MatrixA
    {
        string word;
        int d = 5; // z góry narzucona wielkość macierzy
        int[] key = { 4,2,3,1 }; // tablica z kluczem; klucz jest zapisany w postaci indeksów (czyli o 1 mniej niż w zadaniu)
        string[,] tab = new string[5,6]; // tablica przechowująca słowo 
        bool encoded; // czy zakodowano wyraz 

        public MatrixA(string word)
        {
            this.word = word;
            encoded = false;
        }

        private void EncodeTheWord()
        {
            /*
             * Funkcja wpisująca słowo do tabeli, żeby mozna je było przeczytac za pomocną klucza.
             * Pętla w pętli - służy do wpisania słowa po wierszach,
             * jeśli słowo się skończyło, a tabela dalej ma miejsce, to wpisuje się w nią pusty string (bez spacji)
             */

            int count = 0; // index literki w słowie
            for (int i = 0; i < d; i++)
            {
                for (int j = 0; j < d; j++) 
                {
                    if (count < word.Length) // jeśli index count jest mniejszy wielkość słowa
                        tab[i, j] = word.ElementAt(count).ToString();
                    else
                        tab[i, j] = "";

                    count++;
                }
            }
            encoded = true;
        }

        private string ReadEncoded()
        {
            /*
             * Funkcja czyta zakodowane słowo według klucza
             */
            string newWord = "";

            if(encoded)
            {
                for (int i = 0; i < d; i++)
                
                    for (int j = 0; j < key.Length; j++) 
                        newWord += tab[i, key[j]]; // odczytywanie wyrazu według klucza

                return newWord;
            }

            return "Błąd, słowo nie zostało zaszyfrowane!";          
        }

        public string EncodingWord()
        {
            /*
             * Funkcja która sprawdza, czy słowo zostało zakodowane,
             * jesli nie, to je koduje.
             * Zwraca zakodowane słowo.
             */
            if (encoded == false)
                EncodeTheWord();
            return ReadEncoded();
        }

        public void SetWord(string a)
        {
            word = a;
        }

    }
}
