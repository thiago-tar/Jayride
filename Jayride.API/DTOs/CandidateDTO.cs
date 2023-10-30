using System.ComponentModel.DataAnnotations;

namespace Jayride.Api.DTOs
{
    public class CandidateDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
