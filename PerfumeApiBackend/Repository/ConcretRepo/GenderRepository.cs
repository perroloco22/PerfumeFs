using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.Repository.ConcretRepo
{
    public class GenderRepository : Repository<Gender, PerfumeContext>
    {
        public GenderRepository(PerfumeContext context) : base(context)
        {
        }
    }
}
