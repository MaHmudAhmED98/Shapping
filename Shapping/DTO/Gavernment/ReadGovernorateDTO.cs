using Shapping.DTO.City;

namespace Shapping.DTO.Governoret
{
    public class ReadGovernorateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ReadCityDTO> Cities { get; set; }
    }
}
