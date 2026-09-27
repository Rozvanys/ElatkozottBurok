using System;
using System.Collections.Generic;
using System.Linq;

namespace ElatkozottBurok
{
    public class Iroda
    {
    
        List<Fejleszto> fejlesztok;
        Automata automataGep;

        public Iroda(List<Fejleszto> fejlesztok, Automata automataGep)
        {
            this.fejlesztok = fejlesztok;
            this.automataGep = automataGep;
        }

        public List<Fejleszto> Fejlesztok { get => fejlesztok; set => fejlesztok = value; }
        public Automata AutomataGep { get => automataGep; set => automataGep = value; }

        void MunkanapSzimulacio(int orakSzama)
        {
            for (int i = 0; i < orakSzama; i++)
            {
                foreach (Fejleszto item in fejlesztok)
                {
                    item.Dolgozik();
                    if (item.Koffeinszint < 20 || item.StresszSzint > 70)
                    {
						Nassolnivalo kivalasztott = automataGep.Keszlet
							.FirstOrDefault(n => n.Nev == item.KedvencSnack);

						if (kivalasztott == null)
						{
							kivalasztott = automataGep.Keszlet.OrderBy(n => n.Ar).FirstOrDefault();
						}

						if (kivalasztott != null)
						{
							Nassolnivalo vasarolt = automataGep.Vasarlas(kivalasztott.Nev, fejleszto);

							if (vasarolt != null)
							{
								item.Fogyaszt(vasarolt);
							}
							else if (automataGep.Elakadva)
							{
								automataGep.JavitasRugassal();
							}
						}
					}
					Console.ForegroundColor = item.Kiegve
						? ConsoleColor.Red
						: (item.StresszSzint > 70 ? ConsoleColor.Yellow : ConsoleColor.Green);
					Console.WriteLine($"{item.Nev}: Koffein={item.Koffeinszint}, Stressz={item.StresszSzint}, Kiégve={item.Kiegve}");
					Console.ResetColor();
				}
            }
        }
		public void NapiJelentes()
		{
			Console.WriteLine();
			Console.WriteLine("===== NAPI JELENTÉS =====");

			var legfeszultebbek = fejlesztok.OrderByDescending(f => f.StresszSzint).Take(3);

			Console.WriteLine("Top 3 legfeszültebb fejlesztő:");
			foreach (var f in legfeszultebbek)
			{
				Console.WriteLine($" - {f.Nev}: Stressz={f.StresszSzint}, Kiégve={f.Kiegve}");
			}

			int kiegettekSzama = fejlesztok.Count(f => f.Kiegve);
			Console.WriteLine($"Kiégett/túladagolt fejlesztők száma: {kiegettekSzama}");
			Console.WriteLine($"Az automata napi bevétele: {automataGep.KeszpenzKassza} Ft");
			Console.WriteLine($"Az automatában maradt termékek száma: {automataGep.Keszlet.Count}");
		}
	}
}