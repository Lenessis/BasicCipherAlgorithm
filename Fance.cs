using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSK_podst_kryptografia
{
    class Fance
    {
        int n; //klucz
        List<string>[] tab; // tablica list
        string word; // kodowane słowo
        int word_length = 0; //długość słowa
        bool encoded; // czy słowo jest zakodowane

        public Fance(int n, string word)
        {
            // tworzenie tablicy list + zapisanie klucza i zapisanie słowa
            this.n = n; // długość "klucza"
            this.word = word; // słowo
            this.word_length = word.Length;
            encoded = false;
            tab = new List<string>[n]; // tworzenie tablicy o typie lista i wielkości n 

            for (int i = 0; i < n; i++)
            {
                tab[i] = new List<string>(); // tworzenie nowej listy w każdym indeksie tablicy
            }
            /*
             * Rozwiązanie zawierajace listy pozwala na zaoszczędzenie pamięci programu
             */
        }

        private void EncodeTheWord()
        {
            /*
             * Funkcja kodująca słowo szyfrem płotkowym
             */

            bool isDown = true; // zmienna pomocnicza, zaznaczajaca, czy wpisywanie idzie w dłó czy w górę płotka
            for (int i = 0, j = 0; i < word_length; i++) // i => index literki w słowie; j => index komórki tablicy, do której będzie wpisywana literka
            {                
                if (isDown) // w dół płotka
                {
                    tab[j].Add(word.ElementAt(i).ToString()); //dodaj element do odpowiedniej listy
                    j++;
                    if (j == n) // jeśli index dotarł już do gruntu (zmienna n), to ma się odbić w górę
                    {
                        j = n-2; // max index to n-1, ale nie zapisujemy podwójnie literki na szczycie bądź na gruncie, więc trzeba się przesunąć o jeszcze jeden indeks
                        isDown = false; // płotek teraz będzie rósł
                    }
                }
                else // w górę płotka
                {
                    tab[j].Add(word.ElementAt(i).ToString()); //dodaj element do odpowiedniej listy
                    j--;
                    if (j == -1) // kiedy płotek dotarł na szczyt (jest za indeksem 0)
                    {
                        j = 1; // zmień indeks na 1
                        isDown = true; // płotek będzie spadał
                    }
                }
            }
            encoded = true; // wyraz został zakodowany
        }

        private string ReadEncoded()
        {
            /*
             * Funkcja czyta z tablicy i list zakodowane słowo.
             */
            string newWord = ""; // Zmienna do wpisywania nowego słowa

            if(encoded == true) // sprawdzenie, czy słowo zostało zakodowane
            {
                for (int i = 0; i < n; i++)
                {
                    foreach (var item in tab[i]) // odczytywanie list z każdej komórki tablicy
                    {
                        newWord += item; // wpisywanie pojedynczych literek do nowego wyrazu
                    }
                }

                return newWord;
            }
            return "Wystąpił błąd - słowo nie zostało zakodowane."; //komunikat w przypadku błędu    
        }

        private string Crack()
        {
            if(encoded==true)
            {
                /*
                 * Funkcja dekodująca słowo
                 */
                string crackWord ="";
                int[] listCounts = new int[n];
                for (int i = 0; i < n; i++)
                    listCounts[i] = 0; //licznik indeksów dla każdej z listy

                bool isDown = true; // zmienna pomocnicza, zaznaczajaca, czy odczytywanie idzie w dłó czy w górę płotka

                for (int i = 0, j = 0; i < word_length; i++) // i => index literki w słowie; j => index komórki tablicy, do której będzie wpisywana literka
                {
                    if (isDown) // w dół płotka
                    {       
                        if(listCounts[j]< tab[j].Count) // sprawdzanie, czy indeks listy nie przekroczył jej wielkości
                            crackWord += tab[j].ElementAt(listCounts[j]++); // jeśli nie, odczytaj element
                        
                        j++;
                        if (j == n) // jeśli index dotarł już do gruntu (zmienna n), to ma się odbić w górę
                        {
                            j = n - 2; // max index to n-1, ale nie zapisujemy podwójnie literki na szczycie bądź na gruncie, więc trzeba się przesunąć o jeszcze jeden indeks
                            isDown = false; // płotek teraz będzie rósł
                        }
                    }
                    else // w górę płotka
                    {
                        if (listCounts[j] < tab[j].Count) // sprawdzanie, czy indeks listy nie przekroczył jej wielkości
                            crackWord += tab[j].ElementAt(listCounts[j]++); // jeśli nie, odczytaj element
                        j--;
                        if (j == -1) // kiedy płotek dotarł na szczyt (jest za indeksem 0)
                        {
                            j = 1; // zmień indeks na 1
                            isDown = true; // płotek będzie spadał
                        }
                    }
                }
                encoded = false; // wyraz został zakodowany
                return crackWord;
            }
            return "Wystąpił błąd w przypadku rozkodowania słowa! Najprawdopodobniej nie zostało ono wcześniej zakodowane!";
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

        public string CrackingWord()
        {
            /*
             * Funkcja zwraca rozszyfrowane słowo
             */
            return Crack();
        }

        public void SetWord(string a)
        {
            word = a;
        }

        public void SetKey(int k)
        {
            n = k;
        }

    }
}
