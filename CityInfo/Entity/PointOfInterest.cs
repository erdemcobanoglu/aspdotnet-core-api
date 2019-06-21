using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Entity
{
    public class PointOfInterest
    {
        //18-06-2019

        // add library => using System.ComponentModel.DataAnnotations; 
        [Key] // id oldugu için key ekliyoruz
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("CityId")] // add fk
        // add relationships
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
