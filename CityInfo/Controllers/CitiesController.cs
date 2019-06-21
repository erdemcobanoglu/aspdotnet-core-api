using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        //// new methods  | bu alanı oluşturduktan sonra postman kontrollerini ekliyoruz
        //public JsonResult GetCitiesManuel()
        //{
        //    // create manuel data
        //    return new JsonResult(new List<object>()
        //    {
        //        new {id = 1, Name= "New York City"},
        //        new {id = 2, Name = "Antwerp"},
        //        new {id = 3, Name = "Houston"}
        //    }); 
        //}

        #region versiyon 1
        //[HttpGet()]
        //public JsonResult GetCities()
        //{ 
        //        return new JsonResult(CitiesDataStore.Current.Cities); 
           
        //}

        //[HttpGet("{Id}")]
        //public JsonResult GetCity(int Id)
        //{
        //    return new JsonResult
        //    (
        //     CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == Id)
        //    );
        //}
        #endregion

        // Burdan itibaren örnek 2 status code lu örneğimiz
        #region versiyon 2 
        [HttpGet()]
        public IActionResult GetCities()
        {
            // yada alternatif alttaki yöntem
            //var temp = new JsonResult(CitiesDataStore.Current.Cities);
            //temp.StatusCode = 200;
            //return temp;

             
             return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{Id}")]
        public IActionResult GetCity(int Id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == Id);

            if (cityToReturn == null)
                return NotFound();

            return Ok(cityToReturn);
        } 
        #endregion
    }
}