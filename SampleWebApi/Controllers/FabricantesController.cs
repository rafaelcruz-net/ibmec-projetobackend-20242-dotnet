using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebApi.Model;
using SampleWebApi.Repository;

namespace SampleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricantesController : ControllerBase
    {
        private readonly IFabricanteRepository _fabricantesRepository;

        public FabricantesController(IFabricanteRepository repository)
        {

            _fabricantesRepository = repository;

        }

        // GET: api/Fabricantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fabricante>>> GetFabricantes()
        {
            return (await this._fabricantesRepository.GetAllAsync()).ToList();
        }

        // GET: api/Fabricantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fabricante>> GetFabricante(Guid id)
        {
            var fabricante = await this._fabricantesRepository.GetByIdAsync(id);

            if (fabricante == null)
            {
                return NotFound();
            }

            return fabricante;
        }

        // PUT: api/Fabricantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricante(Guid id, Fabricante fabricante)
        {
            if (id != fabricante.Id)
            {
                return BadRequest();
            }

            try
            {
                await _fabricantesRepository.UpdateAsync(fabricante);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await FabricanteExists(id) == false)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fabricantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fabricante>> PostFabricante(Fabricante fabricante)
        {
            await _fabricantesRepository.SaveAsync(fabricante);

            return CreatedAtAction("GetFabricante", new { id = fabricante.Id }, fabricante);
        }

        // DELETE: api/Fabricantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricante(Guid id)
        {
            var fabricante = await _fabricantesRepository.GetByIdAsync(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            await _fabricantesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> FabricanteExists(Guid id)
        {
            return (await _fabricantesRepository.GetAllByCriteria(x => x.Id == id)).Any();
        }
    }
}
