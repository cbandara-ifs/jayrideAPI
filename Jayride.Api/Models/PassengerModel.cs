using System.ComponentModel.DataAnnotations;

namespace Jayride.Api.Models
{
    public class PassengerModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}