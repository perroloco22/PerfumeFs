namespace PerfumeApiBackend.DTOs
{
    public class PerfumeDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public BrandDTO Brand{ get; set; }
        public VolumeDTO Volume{ get; set; }
        public GenderDTO Gender { get; set; }
        public ConcentrationDTO Concentration { get; set; }
        public ICollection<PerfumeryDTO> Perfumeries { get; set; }
    }
}
