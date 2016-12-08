using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureIoTDemo.Models
{
    public class TemperatureRead
    {
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }
}
