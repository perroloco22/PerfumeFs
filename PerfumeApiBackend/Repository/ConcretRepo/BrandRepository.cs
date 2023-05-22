using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.Repository.ConcretRepo
{
    public class BrandRepository : Repository<Brand, PerfumeContext>
    {
        public BrandRepository(PerfumeContext context) : base(context)
        {
        }
    }
}
