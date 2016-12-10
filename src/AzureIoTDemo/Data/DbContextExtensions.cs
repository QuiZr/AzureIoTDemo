using AzureIoTDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureIoTDemo.Data
{
    public static class DbContextExtensions
    {
        public static void Seed(this TemperatureContext context, bool isInProduction)
        {
            if (!isInProduction)
                context.Database.EnsureDeleted();

            context.Database.Migrate();

            AddTemperatureReads(context, 30);

            context.SaveChanges();
            context.Dispose();
        }

        private static void AddTemperatureReads(TemperatureContext context, int dataPerLocation = 30)
        {
            List<string> locations = new List<string> { "Wrocław", "Łódź", "Kraków", "Warszwa", "asdf" };

            List<TemperatureRead> dataToAdd = new List<TemperatureRead>();

            Random random = new Random();

            foreach (var location in locations)
            {
                for (int i = 0; i < dataPerLocation; i++)
                {
                    dataToAdd.Add(
                        new TemperatureRead
                        {
                            Place = location,
                            Value = Convert.ToSingle(Math.Round(random.NextDouble() * 200 - 100, 2)),
                            Date = DateTime.Now
                        });
                }
            }

            context.AddRange(dataToAdd);
        }
    }
}