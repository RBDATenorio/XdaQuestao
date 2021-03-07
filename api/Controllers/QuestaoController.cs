using System.Threading.Tasks;
using api.Domain;
using api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestaoController : ControllerBase
    {
        private readonly IApiRepository _repo;
        public QuestaoController(IApiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllQuestaoAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{QuestaoId}")]
        public async Task<IActionResult> Get(int QuestaoId)
        {
            try
            {
                var results = await _repo.GetAllQuestaoAsyncById(QuestaoId);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Banca}")]
        public async Task<IActionResult> Get(string Banca)
        {
            try
            {
                var results = await _repo.GetAllQuestaoAsyncByBanca(Banca);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
       
    [HttpPost]
    public async Task<IActionResult> Post(Questao model)
    {
        try
        {
            _repo.Add(model);

            if(await _repo.SaveChangesAsync())
            {
                return Created($"/api/questao/{model.QuestaoId}", model);
            }
        }
        catch (System.Exception)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError);
        }
        return BadRequest();
    }    
    [HttpPut]
    public async Task<IActionResult> Put(int QuestaoId, Questao model)
    {
        try
        {
            var evento = await _repo.GetAllQuestaoAsyncById(QuestaoId);
            
            if(evento == null) return NotFound();

            _repo.Update(model);

            if(await _repo.SaveChangesAsync())
            {
                return Created($"/api/questao/{model.QuestaoId}", model);
            }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();
        }        
    [HttpDelete]
    public async Task<IActionResult> Delete(int QuestaoId)
    {
        try
        {
            var evento = await _repo.GetAllQuestaoAsyncById(QuestaoId);
            
            if(evento == null) return NotFound();

            _repo.Delete(evento);

            if(await _repo.SaveChangesAsync())
            {
                return Ok();
            }


            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
                return BadRequest();
        }                    
    }
}