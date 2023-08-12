using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShiftLoggerApp.Models
{
    public class UserInput
    {
        public string GetName()
        {
            Console.WriteLine("Enter in your name:");
            var name = Console.ReadLine();
            return name;
        }

        public string GetDate()
        {
            Console.WriteLine("Enter in the date today.");
            var date = Console.ReadLine();
            return date;
        }

        public string GetHoursWorked()
        {
            Console.WriteLine("Enter in how many hours you worked today.");
            var hoursWorked = Console.ReadLine();
            return hoursWorked;
        }

        public string GetIdEntry()
        {
            Console.WriteLine("Enter in the ID you would like to access.");
            var entry = Console.ReadLine();
            return entry;
        }
    }
}
