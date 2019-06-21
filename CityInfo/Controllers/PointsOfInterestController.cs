using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfo.Controllers
{
    // burdaki route alanını vermezsen route edemez null döner
    [Route("api/cities")]
    public class PointsOfInterestController : Controller
    {
        

        [HttpGet("{cityId}/pointsofinterest")]
        public IActionResult GetPointOfInterest(int cityId)
        {
            try
            {
                // manuel exception attırmak istersek burayı kullan 
                //throw new Exception("Exception test");

                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                {
                    // çıktıyı output ekranından görebiliriz!
                    //_logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest"); return NotFound();
                }
                return Ok(city.PointOfInterests);
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);
                return StatusCode(500, "A problem happened while handling your request!");
            }
        }

        // interest için 
        [HttpGet("{cityId}/pointsofinterest/{id}", Name ="GetPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int Id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return BadRequest();

             
            //return Ok(city.NumberOfPointsOfInterest);

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(p => p.Id == Id);
            if (pointOfInterest == null)
                return NotFound();

            return Ok(pointOfInterest);

        }

        // ekleme  add using model
        [HttpPost("{cityId}/pointsofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody]PointOfInterestForCreationDto pointOfInterest)
        {



            #region validationCreate
            // validation control başladı
            if (pointOfInterest == null)
                return BadRequest();

            // model state'e manuel error ekledik
            if (pointOfInterest.Description == pointOfInterest.Name)
                ModelState.AddModelError("Description", "the provided description should be different from the name");

            // modelde required doldurulmadıysa validation kontrolü için yapıyoruz
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // içeriye açıklamasını veriyoruz


            // validation check bitti 
            #endregion

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
                if (city == null)
                return NotFound();

            var maxPointOfInterest = CitiesDataStore.Current.Cities.SelectMany(c => c.PointOfInterests).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterest,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            // listeye ekle
            city.PointOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new {cityId,  id = finalPointOfInterest.Id}, finalPointOfInterest);
        }


        //Update işlemi  put işleminde Application/json yapıcaz datatype 'ı postman'de
        [HttpPut("{cityId}/pointsofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int Id, [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            #region validationCreate
            // validation control başladı
            if (pointOfInterest == null)
                return BadRequest();

            // model state'e manuel error ekledik
            if (pointOfInterest.Description == pointOfInterest.Name)
                ModelState.AddModelError("Description", "the provided description should be different from the name");

            // modelde required doldurulmadıysa validation kontrolü için yapıyoruz
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // içeriye açıklamasını veriyoruz


            // validation check bitti 
            #endregion

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(p => p.Id == Id);
            if (pointOfInterestFromStore == null)
                return NotFound();

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();

        }


        // Delete Attribute
        [HttpDelete("{cityId}/pointsofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int Id)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(p => p.Id == Id);
            if (pointOfInterestFromStore == null)
                return NotFound();

            city.PointOfInterests.Remove(pointOfInterestFromStore);
            return NoContent();
        }

        // ToDo Patch Method
    }
}