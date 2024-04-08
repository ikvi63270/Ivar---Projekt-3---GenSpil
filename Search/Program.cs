namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Indtast søgning: ");
                string searchString = Console.ReadLine();
                string filePath = @"C:\\Users\\ivark\\Desktop\\Datamatiker Online\\Projects\\Projekt 3 - GenSpil\\Search\\list.txt";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool found = false;
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        string itemName = parts[0].Trim();
                        string itemGenre = parts[1].Trim();
                        string itemPlayers = parts[2].Trim();
                        string itemCondition = parts[3].Trim();
                        string itemPrice = parts[4].Trim();
                        string itemInquiry = parts[5].Trim();
                        if (itemName.Contains(searchString, StringComparison.OrdinalIgnoreCase) || itemGenre.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Found '{searchString}' in the file:");
                            Console.WriteLine("Spil: " + itemName);
                            Console.WriteLine("Genre: " + itemGenre);
                            Console.WriteLine("Antal spillere: " + itemPlayers);
                            Console.WriteLine("Kvalitet: " + itemCondition);
                            Console.WriteLine("Pris: " + itemPrice);
                            Console.WriteLine("Forespørgsel: " + itemInquiry);
                            Console.WriteLine("------------------------------");
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine($"'{searchString}' not found in the file.");
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
                Console.WriteLine("skriv 'y' for at starte en ny søgning");
            } while (Console.ReadLine() == "y");
        }
    }
}
