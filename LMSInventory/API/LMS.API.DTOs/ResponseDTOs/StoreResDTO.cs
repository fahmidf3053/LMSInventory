namespace LMS.API.DTOs.ResponseDTOs
{
    public class StoreResDTO
    {
        public StoreResDTO()
        {
            Racks = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public List<RackResDTO> Racks { get; set; }

    }
}
