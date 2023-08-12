using ShiftLoggerApp.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLoggerApp.Views
{
    public class Menu
    {
        // Inject client so we can use its methods
        private readonly ShiftLoggerClient _client;
        public Menu(ShiftLoggerClient client)
        {
            _client = client;
        }

        public async Task ShowMenu()
        {
            bool closeApp = false;
            while (closeApp == false)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("Enter 1 to view all entries.");
                Console.WriteLine("Enter 2 to add an entry.");
                Console.WriteLine("Enter 3 to edit an entry.");
                Console.WriteLine("Enter 4 to delete an entry.");
                Console.WriteLine("Enter 5 to exit the program.");
                Console.WriteLine("---------------------------------");

                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        await _client.ShowEntries();
                        Console.WriteLine("Enter any key to go back to the main menu.");
                        Console.ReadLine();
                        break;
                    case "2":
                        await _client.PostEntry();
                        break;
                    case "3":
                        await _client.ShowEntries();
                        await _client.UpdateEntry();
                        break;
                    case "4":
                        await _client.ShowEntries();
                        await _client.DeleteEntry();
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Enter any key to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
