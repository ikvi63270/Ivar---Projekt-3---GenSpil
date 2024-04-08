using System.Globalization;

namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Enter the search criteria (name, genre, minplayers, maxplayers, condition, minprice, maxprice, inquiry):");
                string searchCriteria = Console.ReadLine();
                Console.WriteLine("Indtast søgning: ");
                string searchString = Console.ReadLine();
                string filePath = @"C:\\Users\\ivark\\Desktop\\Datamatiker Online\\Projects\\Projekt 3 - GenSpil\\V2.0\\list.txt";
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    bool found = false;
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        string itemName = parts[0].Trim();
                        string itemGenre = parts[1].Trim();
                        string itemMinPlayers = parts[2].Trim();
                        string itemMaxPlayers = parts[3].Trim();
                        string itemCondition = parts[4].Trim();
                        string itemPrice = parts[5].Trim();
                        string itemInquiry = parts[6].Trim();
                        if (MatchCriteria(searchCriteria, searchString, itemName, itemGenre, itemMinPlayers, itemMaxPlayers, itemCondition, itemPrice, itemInquiry))
                        {
                            Console.WriteLine($"Found '{searchString}' in the file:");
                            Console.WriteLine("Spil: " + itemName);
                            Console.WriteLine("Genre: " + itemGenre);
                            Console.WriteLine("Minimum antal spillere: " + itemMinPlayers);
                            Console.WriteLine("Maksimum antal spillere: " + itemMaxPlayers);
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
        static bool MatchCriteria(string criteria, string searchValue, string itemName, string itemGenre, string itemMinPlayers, string itemMaxPlayers, string itemCondition, string itemPrice, string itemInquiry)
        {
            switch (criteria.ToLower())
            {
                case "name":
                    return itemName.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
                case "genre":
                    return itemGenre.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
                case "minplayers":
                    int minPlayers;
                    if (int.TryParse(searchValue, out minPlayers))
                    {
                        int itemMinPlayersInt;
                        if (int.TryParse(itemMinPlayers, out itemMinPlayersInt))
                        {
                            return itemMinPlayersInt >= minPlayers;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "maxplayers":
                    int maxPlayers;
                    if (int.TryParse(searchValue, out maxPlayers))
                    {
                        int itemMaxPlayersInt;
                        if (int.TryParse(itemMaxPlayers, out itemMaxPlayersInt))
                        {
                            return itemMaxPlayersInt <= maxPlayers;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "condition":
                    return itemCondition.Equals(searchValue, StringComparison.OrdinalIgnoreCase);
                case "minprice":
                    int minPrice;
                    if (int.TryParse(searchValue, out minPrice))
                    {
                        int itemMinPriceInt;
                        if (int.TryParse(itemPrice, out itemMinPriceInt))
                        {
                            return itemMinPriceInt >= minPrice;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "maxprice":
                    int maxPrice;
                    if (int.TryParse(searchValue, out maxPrice))
                    {
                        int itemMaxPriceInt;
                        if (int.TryParse(itemPrice, out itemMaxPriceInt))
                        {
                            return itemMaxPriceInt <= maxPrice;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                case "inquiry":
                    return itemInquiry.Equals(searchValue, StringComparison.OrdinalIgnoreCase);
                default:
                    return false;
            }
        }
    }
}
