using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.Repository
{
    public class PerfumeRepository : Repository<Perfume, PerfumeContext>
    {
        public PerfumeRepository(PerfumeContext context) : base(context)
        {
        }
    }
}
