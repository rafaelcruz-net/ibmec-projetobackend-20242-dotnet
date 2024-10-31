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
    [Route("api/fabricante/{idFabricante}/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly SampleContext _context;

        public VeiculosController(SampleContext context)
        {
            _context = context;
        }

        // GET: api/Veiculos
        [HttpGet]
        public ActionResult<IEnumerable<Veiculo>> GetVeiculos([FromRoute] Guid idFabricante)
        {
            return _context.Veiculos.Include(x => x.Fabricante)
                                    .Where(x => x.Fabricante.Id == idFabricante)
                                    .ToList();                        
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public ActionResult<Veiculo> GetVeiculo(Guid id)
        {
            var veiculo = (_context.Veiculos.Find(id));

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // PUT: api/Veiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(Guid id, Veiculo veiculo)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // POST: api/Veiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo([FromRoute] Guid idFabricante, Veiculo veiculo)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var fabricante = _context.Fabricantes.Find(idFabricante);

            if (fabricante == null)
                return BadRequest();

            //Associando o veiculo ao fabricante
            veiculo.Fabricante = fabricante;

            //Salvar o veiculo
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();

            return Created("", new { id = veiculo.Id });
        }

        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(Guid id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculos.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(Guid id)
        {
            return _context.Veiculos.Any(e => e.Id == id);
        }
    }
}
