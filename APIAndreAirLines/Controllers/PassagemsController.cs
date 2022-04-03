using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAndreAirLines.Data;
using APIAndreAirLines.Model;

namespace APIAndreAirLines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemsController : ControllerBase
    {
        private readonly APIAndreAirLinesContext _context;

        public PassagemsController(APIAndreAirLinesContext context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.Include(e => e.Voo.Origem)
                                          .Include(e => e.Voo.Destino)
                                          .Include(e => e.Passageiro)
                                          .ToListAsync();
        }

        [HttpGet("relatorio")]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagemMes(int mes)
        {
            return await _context.Passagem.Include(e => e.Voo.Origem)
                                          .Include(e => e.Voo.Destino)
                                          .Include(e => e.Passageiro)
                                          .Where(d=>d.DataCadastro.Month == mes)
                                          .ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.Include(e => e.Voo.Origem)
                                                  .Include(e => e.Voo.Destino)
                                                  .Include(e => e.Passageiro)
                                                  .Where(d => d.Id == id)
                                                  .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {

            var voo = await _context.Voo.Include(e => e.Origem)
                                        .Include(e => e.Destino)
                                        .Where(d => d.Id == passagem.Voo.Id).FirstOrDefaultAsync();
            if (voo != null)
                passagem.Voo = voo;

            var passageiro = await _context.Passageiro.FindAsync(passagem.Passageiro.Cpf);
            if (passageiro != null)
                passagem.Passageiro = passageiro;

            var precobase = await _context.PrecoBase.Where(x => x.Origem.Sigla == passagem.Voo.Origem.Sigla && x.Destino.Sigla == passagem.Voo.Destino.Sigla).FirstOrDefaultAsync();
            if (precobase != null)
                passagem.PrecoBase = precobase;

            var classe = await _context.Classe.FindAsync(passagem.Classe.Id);
            if (classe != null)
                passagem.Classe = classe;

            passagem.Valor = passagem.Classe.Valor + passagem.PrecoBase.Valor;

            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
