using System;

namespace ElatkozottBurok
{
    public class Nassolnivalo
    {
        string nev;
        int koffeinLoket;
        int stresszOldas;
        int ar;



        public string Nev
        {
            get => nev; set
            {
                if (string.IsNullOrEmpty(value))
                {
                    nev = "Ismeretlen nassolnivaló";
                }
                else
                {
                    nev = value;
                }
            }
        }
        public int KoffeinLoket
        {
            get => koffeinLoket; set
            {
                if (value < 0)
                {
                    koffeinLoket = 0;
                }
                else if (value > 50)
                {
                    koffeinLoket = 50;

                }
                else
                {
                    koffeinLoket = value;
                }
            }
        }
        public int StresszOldas
        {
            get => stresszOldas; set
            {
                if (value < 0)
                {
                    stresszOldas = 0;
                }
                else if (value > 30)
                {
                    stresszOldas = 30;
                }
                else
                {
                    stresszOldas = value;
                }
            }
        }
        public int Ar
        {
            get => ar; set
            {
                if (value < 100)
                {
                    ar = 100;
                }
                else
                {
                    ar = value;
                }
            }
        }

        public Nassolnivalo(string nev, int koffeinLoket, int stresszOldas, int ar)
        {
            this.Nev = nev;
            this.KoffeinLoket = koffeinLoket;
            this.StresszOldas = stresszOldas;
            this.Ar = ar;
        }
    }
}