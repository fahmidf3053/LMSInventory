namespace LMS.API.DTOs.ResponseDTOs
{
    public class RackResDTO
    {
        public RackResDTO()
        {
            Elements = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfRacks { get; set; }
        public string StoreName { get; set; }
        public int StoreId { get; set; }
        public List<ElementResDTO> Elements { get; set; }
    }
}
