using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;    // add
using System.ComponentModel.DataAnnotations.Schema;  // add
using CityInfo.Models;

namespace CityInfo.Entity
{
    // 18-06-2019
    // Bu adımdan sonra ekle => Microsoft.EntityFrameworkCore.SqlServer

    public class City
    {
        // add library => using System.ComponentModel.DataAnnotations; 
        [Key] // id oldugu için key ekliyoruz
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
 

        // add child resources # add entity #
        public ICollection<PointOfInterest> PointOfInterests { get; set; } = new List<PointOfInterest>();
    }
}
