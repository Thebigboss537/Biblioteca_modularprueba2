#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca_modular.Data;
using Biblioteca_modular.Models;

namespace Biblioteca_modular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Materiales_autoresController : ControllerBase
    {
        private readonly DataContext _context;

        public Materiales_autoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Materiales_autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material_autor>>> GetMaterial_Autores()
        {
            return await _context.Material_Autores.ToListAsync();
        }

        // GET: api/Materiales_autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material_autor>> GetMaterial_autor(int id)
        {
            var material_autor = await _context.Material_Autores.FindAsync(id);

            if (material_autor == null)
            {
                return NotFound();
            }

            return material_autor;
        }

        // PUT: api/Materiales_autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial_autor(int id, Material_autor material_autor)
        {
            if (id != material_autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(material_autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Material_autorExists(id))
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

        // POST: api/Materiales_autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material_autor>> PostMaterial_autor(Material_autor material_autor)
        {
            _context.Material_Autores.Add(material_autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial_autor", new { id = material_autor.Id }, material_autor);
        }

        // DELETE: api/Materiales_autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial_autor(int id)
        {
            var material_autor = await _context.Material_Autores.FindAsync(id);
            if (material_autor == null)
            {
                return NotFound();
            }

            _context.Material_Autores.Remove(material_autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Material_autorExists(int id)
        {
            return _context.Material_Autores.Any(e => e.Id == id);
        }
    }
}
