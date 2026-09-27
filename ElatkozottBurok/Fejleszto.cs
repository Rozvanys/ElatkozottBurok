using System;

namespace ElatkozottBurok
{
    public class Fejleszto
    {

        string nev;
        Munkakor munkakor;
        int penz;
        int koffeinszint;
        int stresszSzint;
        bool kiegve;
        string kedvencSnack;

        public string Nev { get => nev; set => nev = value; }
		public Munkakor Munkakor { get => munkakor; set => munkakor = value; }
		public int Penz
        {
            get => penz; set
            {
                if (value < 0) penz = 0;
                else penz = value;
			}
        }
        public int Koffeinszint
        {
            get => koffeinszint;
            set
            {
                if (value < 0)
                {
                    koffeinszint = 0;
                }
                else if (value >= 100)
                {
                    koffeinszint = 100;
                    Kiegve = true;
                }
                else
                {
                    koffeinszint = value;
                }
                
            }
        }
        public int StresszSzint { get => stresszSzint; set => stresszSzint = value; }
        public bool Kiegve { get => kiegve; set => kiegve = value; }
        public string KedvencSnack { get => kedvencSnack; set => kedvencSnack = value; }

        public Fejleszto(string nev, int penz, int koffeinszint, int stresszSzint, bool kiegve, string kedvencSnack)
        {
            this.Nev = nev;
            this.penz = penz;
            this.Koffeinszint = koffeinszint;
            this.StresszSzint = stresszSzint;
            this.Kiegve = kiegve;
            this.KedvencSnack = kedvencSnack;
        }

        void Dolgozik()
        {
            if (this.Kiegve)
            {
                Console.WriteLine($"{this.Nev} kiégett, nem tud dolgozni.");
                return;
            }
            else
            {
				switch (this.Munkakor)
				{
					case Munkakor.Junior:
						this.Koffeinszint -= 25;
						this.StresszSzint += 20;
						break;
					case Munkakor.Senior:
						this.Koffeinszint -= 15;
						this.StresszSzint += 10;
						break;
					case Munkakor.DevOpsVarazslo:
						this.Koffeinszint -= 10;
						this.StresszSzint += 25;
						break;
				}

				if (this.koffeinszint < 15)
                {
                    Console.WriteLine($"{this.nev} agya lefagyott (Blue Screen), koffeinre van szüksége!");
                }
            }
        }

        public void Fogyaszt(Nassolnivalo nassolnivalo)
        {
            if (nassolnivalo == null) return;
            if (nassolnivalo.Nev == this.KedvencSnack)
            {
                this.Koffeinszint += nassolnivalo.KoffeinLoket + 5;
                this.StresszSzint -= nassolnivalo.StresszOldas * 2;
            }
            else
            {
                this.Koffeinszint += nassolnivalo.KoffeinLoket;
                this.StresszSzint -= nassolnivalo.StresszOldas;
            }
        }
    }
}