using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivesController : ControllerBase
    {

        private readonly ILiveRepository _liveRepository;

        
        public LivesController(ILiveRepository liveRepository)
        {
            _liveRepository = liveRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Live>> GetLives()
        {
            return await _liveRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Live>> GetLives(int id)
        {
            return await _liveRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Live>> PostLives([FromBody] Live live)
        {
            var newLive = await _liveRepository.Create(live);
            return CreatedAtAction(nameof(GetLives), new { id = newLive.id}, newLive);
        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Live live)
        {
            if (id != live.id)
            {
                return BadRequest();
            }

            await _liveRepository.Update(live);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var liveToDelete = await _liveRepository.Get(id);
            if (liveToDelete == null)
                return NotFound();

            await _liveRepository.Delete(liveToDelete.id);
            return NoContent();
        }
    }
}