using DiansProject.DAL.Entities;
using DiansProject.DAL.Json_Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiansProject.DAL.Data
{
    public class DatabaseSeeder
    {
        public static void Seed(IServiceProvider applicationServices)
        {
            using (IServiceScope serviceScope = applicationServices.CreateScope())
            {
                DatabaseContext context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                if (context.Database.EnsureCreated())
                {
                    //SeedFromRawJsonData();
                }
                SeedFromRawJsonData();
            }
        }

        private static void SeedFromRawJsonData()
        {
            string rawDataFilePath = @"C:\Users\ThinkBook\source\repos\DiansProject\DiansProject\DiansProject.DAL\Raw Data\RawPointsData.txt";
            string rawDataContent = "";


            rawDataContent = File.ReadAllText(rawDataFilePath);


            var openStreetData = JsonConvert.DeserializeObject<OpenStreetData>(rawDataContent);

            foreach(var feature in openStreetData.Features)
            {
                var 
            }



            //context.SaveChanges();
        }
    }
}
