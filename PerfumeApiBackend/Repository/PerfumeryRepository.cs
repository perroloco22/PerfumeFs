﻿using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;

namespace PerfumeApiBackend.Repository
{
    public class PerfumeryRepository : Repository<Perfumery, PerfumeContext>
    {
        public PerfumeryRepository(PerfumeContext context) : base(context)
        {
        }
    }
}
