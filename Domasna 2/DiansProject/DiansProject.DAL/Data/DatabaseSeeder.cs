using DiansProject.DAL.Entities;
using DiansProject.DAL.Filters;
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
                    SeedFromRawJsonData(context);

                    context.SaveChanges();
                } else
                { // TODO delete this - this is only used for testing purpouses 
                    //SeedFromRawJsonData(context);
                }
            }
        }

        private static void SeedFromRawJsonData(DatabaseContext context)
        {
            var asdf = Directory.GetCurrentDirectory();
            string rawDataFilePath = @"..\DiansProject.DAL\Raw Data\RawPointsData.txt";

            string rawDataContent = "";

            rawDataContent = File.ReadAllText(rawDataFilePath);

            Pipe<string> pipe = new Pipe<string>();
            ToUpperCaseFilter toUpperCaseFilter = new ToUpperCaseFilter();

            pipe.addFilter(toUpperCaseFilter);


            var openStreetData = JsonConvert.DeserializeObject<OpenStreetData>(rawDataContent);

            foreach(var feature in openStreetData.Features)
            {
                Feature newFeature = new Feature()
                {
                    Id = feature.Id,
                    Type = feature.Type,
                    Geometry = new Geometry()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Longitude = feature.Geometry.Coordinates[0],
                        Latitude = feature.Geometry.Coordinates[1]
                    },
                    Properties = new Properties()
                    {
                        Id = feature.Properties.Id,
                        Access = feature.Properties.Access,
                        Amenity = pipe.runFilters(feature.Properties.Amenity),
                        BicycleParking = feature.Properties.BicycleParking,
                        Capacity = feature.Properties.Capacity,
                        Covered = feature.Properties.Covered,
                        Fee =  feature.Properties.Fee,
                        Level = feature.Properties.Level,
                        Name = feature.Properties.Name,
                        NameEn = feature.Properties.NameEn,
                        Operator = feature.Properties.Operator,
                        Parking = feature.Properties.Parking,
                        Wheelchair = feature.Properties.Wheelchair,
                    }
                };
                context.Features.Add(newFeature);
            }
        }
    }
}
