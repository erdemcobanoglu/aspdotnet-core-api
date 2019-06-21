using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.Models
{
    public class PointOfInterestForUpdateDto
    {
        // data annotation
        [Required(ErrorMessage ="You should be provide a name value")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
