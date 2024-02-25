using System.ComponentModel.DataAnnotations;

namespace Jayride.Api.DataAccess.Entities
{
    public class Passenger
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}