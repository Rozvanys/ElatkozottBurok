namespace ElatkozottBurok
{
    internal class Program
    {
        static void Main(string[] args)
        {
			List<Fejleszto> fejlesztok = new List<Fejleszto>
			{
				new Fejleszto("Márk", Munkakor.Junior, 5000, "Maci Laci", 60, 30),
				new Fejleszto("Anna", Munkakor.Senior, 8000, "Kávé", 70, 20),
				new Fejleszto("Béla", Munkakor.DevOpsVarazslo, 10000, "Energiaital", 80, 10)
			};

			Automata automata = new Automata();
			automata.Feltolt(new List<Nassolnivalo>
			{
				new Nassolnivalo("Kávé", 20, 10, 300),
				new Nassolnivalo("Maci Laci", 10, 10, 200),
				new Nassolnivalo("Energiaital", 45, 5, 450)
			});

			Iroda iroda = new Iroda(fejlesztok, automata);
			iroda.MunkanapSzimulacio(8);
			iroda.NapiJelentes();

			Console.WriteLine();
			Console.WriteLine("Nyomj Entert a kilépéshez...");
			Console.ReadLine();


		}
    }
}
