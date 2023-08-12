using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftLoggerApp.Models
{
    public class ShiftDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string HoursWorked { get; set; }
    }