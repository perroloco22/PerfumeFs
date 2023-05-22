namespace PerfumeApiBackend.DTOs
{
    public class PerfumeryDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<StockDTO> Stocks { get; set; }

    }
}