using System.ComponentModel.DataAnnotations;

namespace LMS.API.DTOs.RequestDTOs
{
    public class StoreReqDTO
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }

    }
}
