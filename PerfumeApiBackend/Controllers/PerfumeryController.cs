using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerfumeApiBackend.Controllers.Template;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.ConcretRepo;

namespace PerfumeApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfumeryController : TemplateController<Perfumery, PerfumeryRepository>
    {
        public PerfumeryController(PerfumeryRepository repository) : base(repository)
        {
        }
    }
}
