using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ShiftLoggerApp.Models
{
    public class Validate
    {
        public int IsInteger(string input)
        {
            int intId;
            bool result = int.TryParse(input, out intId);

            if (result == false)
            {
                Console.WriteLine("Input is not an integer. Entry will not go through.");
                Console.ReadLine();
            }
            return intId;
        }
    }
}
