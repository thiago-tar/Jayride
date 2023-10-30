using Microsoft.AspNetCore.Mvc;
using Jayride.Domain.DependencyInjection;
using Jayride.Domain.Entities;
using AutoMapper;
using Jayride.Api.DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jayride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CandidateController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CandidateDTO>> Get()
        {
            try
            {
                var candidates = Dependencies.CandidateRepository.GetAll();
                return Ok(_mapper.Map<IEnumerable<CandidateDTO>>(candidates));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CandidateDTO> Get(int id)
        {
            try
            {
                var candidate = Dependencies.CandidateRepository.Get(id);
                if (candidate == null) return NotFound();

                return Ok(_mapper.Map<CandidateDTO>(candidate));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPost]
        public ActionResult<CandidateDTO> Post([FromBody] CandidateDTO value)
        {
            try
            {
                if(!ModelState.IsValid) { }

                var candidate = _mapper.Map<Candidate>(value);
                candidate = Dependencies.CandidateRepository.Add(candidate);
                return Ok(_mapper.Map<CandidateDTO>(candidate));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Dependencies.CandidateRepository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
