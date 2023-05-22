using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.DTOs;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.Repository.ConcretRepo
{
    public class PerfumeRepository : Repository<Perfume, PerfumeContext>
    {
        protected readonly IMapper _mapper;
        public PerfumeRepository(PerfumeContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<PerfumeDTO> GetByIdDTOAsync(int id)
        {
            var perfume = await _context.Perfumes
                .ProjectTo<PerfumeDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(ent => ent.Id == id);

            //var perfume = await _context.Perfumes
            //            .Include(perf => perf.Brand)
            //            .Include(perf => perf.Concentration)
            //            .Include(perf => perf.Gender)
            //            .Include(perf => perf.Stocks)
            //                .ThenInclude(stock => stock.Perfumery)
            //            .FirstOrDefaultAsync(perf => perf.ID == id);

            return perfume;
        }
    }
}
