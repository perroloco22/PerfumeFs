using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository;

namespace PerfumeApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeController : TemplateController<Perfume,PerfumeRepository>
    {
        public PerfumeController(PerfumeRepository repository) : base(repository)
        {
        }
    }
}
