using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Automata
    {
        static Random random = new Random();
        int keszpenzKassza;
        List<Nassolnivalo> keszlet;
        bool elakadva;

        public Automata()
        {
            keszpenzKassza = 0;
            keszlet = new List<Nassolnivalo>();
            elakadva = false;
        }

		public Automata(int keszpenzKassza, List<Nassolnivalo> keszlet, bool elakadva)
		{
			this.keszpenzKassza = keszpenzKassza;
			this.keszlet = keszlet ?? new List<Nassolnivalo>();
			this.elakadva = elakadva;
		}

		public int KeszpenzKassza { get => keszpenzKassza; set => keszpenzKassza = value; }
        public List<Nassolnivalo> Keszlet { get => keszlet; set => keszlet = value; }
        public bool Elakadva { get => elakadva; set => elakadva = value; }

        public void Feltolt(List<Nassolnivalo> ujKeszlet)
        {
            keszlet.AddRange(ujKeszlet);
        }

		public Nassolnivalo Vasarlas(string termekNev, Fejleszto vasarlo)
		{
			if (elakadva)
			{
				vasarlo.StresszSzint += 15;
				Console.WriteLine("Az automata elakadt, nem ad ki semmit!");
				return null;
			}

			
			Nassolnivalo termek = keszlet.FirstOrDefault(n => n.Nev == termekNev);
			if (termek == null)
			{
				Console.WriteLine($"A(z) \"{termekNev}\" kifogyott az automatából.");
				return null;
			}

			
			if (vasarlo.Penz < termek.Ar)
			{
				Console.WriteLine($"{vasarlo.Nev}-nek nincs elég pénze ({termek.Nev} ára: {termek.Ar} Ft).");
				return null;
			}

			int veletlen = random.Next(1, 101); // 1..100
			if (veletlen <= 15)
			{
				elakadva = true;
				vasarlo.Penz -= termek.Ar;
				keszpenzKassza += termek.Ar;
				vasarlo.StresszSzint += 30;
				Console.WriteLine("Az automata elnyelte a pénzt és elakadt, a termék bent ragadt!");
				return null;
			}

			vasarlo.Penz -= termek.Ar;
			keszpenzKassza += termek.Ar;
			keszlet.Remove(termek);
			Console.WriteLine($"A vásárlás sikeres! {termek.Nev} kikerült az automatából.");
			return termek;
		}
		void JavitasRugassal()
        {
            //    Nassolnivalo kivalasztottNassolnivalo = keszlet.FirstOrDefault(n => n.Nev == nassolnivaloNev);
            int veletlen = random.Next(0, 100);
            if (veletlen < 50)
            {
                Console.WriteLine("Sajnos a rúgás nem segített");
                
            }else
            {
                elakadva = false;
                Console.WriteLine("A rúgás sikeres volt");
                //fejleszto.Koffeinszint += kivalasztottNassolnivalo.KoffeinLoket;
                //fejleszto.StresszSzint -= kivalasztottNassolnivalo.StresszOldas;
            }
        }
    }
}