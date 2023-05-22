using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerfumeApiBackend.Controllers.Template;
using PerfumeApiBackend.DataAccess;
using PerfumeApiBackend.DTOs;
using PerfumeApiBackend.Models.DataModels;
using PerfumeApiBackend.Repository.ConcretRepo;

namespace PerfumeApiBackend.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class PerfumeController : TemplateController<Perfume,PerfumeRepository>
    {
        public PerfumeController(PerfumeRepository repository) : base(repository)
        {
            
        }

        [HttpGet("dto/{id:int}")]
        public async Task<ActionResult<PerfumeDTO>> GetByIdDTOAsync(int id)
        {
            var dto = await _repository.GetByIdDTOAsync(id);
            if (dto is null)
            {
                return NotFound();
            }
            return Ok(dto);

        }

        
    }
}
