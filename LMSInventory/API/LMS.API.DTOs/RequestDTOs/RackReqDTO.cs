using System.ComponentModel.DataAnnotations;

namespace LMS.API.DTOs.RequestDTOs
{
    public class RackReqDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityOfRacks { get; set; }
        [Required]
        public int StoreId { get; set; }

    }
}
