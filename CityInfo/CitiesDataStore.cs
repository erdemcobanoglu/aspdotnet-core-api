using CityInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo
{
    public class CitiesDataStore
    { 
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }



        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York Cit",
                    Description = "The one with that big park.",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The Most visited urban in the United States."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empires State Building",
                            Description = "A 102- story skycrapper located in Midtown Manhattan."
                        },
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "France Park",
                            Description = "The Most visited urban in the France."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empires State Building",
                            Description = "A 102- story skycrapper located in Midtown paris."
                        },
                    }
                },
                new CityDto()
                {
                    Id =3 ,
                    Name = "Houston",
                    Description ="The one with new data sience centre.",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Houston Park",
                            Description = "The Most visited urban in the United States."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Houston State Building",
                            Description = "A 102- story skycrapper located in Midtown Housteon."
                        },
                    }
                }
            };
            
        }
    }
}
