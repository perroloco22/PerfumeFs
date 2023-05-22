using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.DTOs
{
    public class GenderDTO : BaseEntityDTO
    {
        public TypeGender Type { get; set; }
    }
}