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
    public class Materiales_categoriasController : ControllerBase
    {
        private readonly DataContext _context;

        public Materiales_categoriasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Materiales_categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material_categoria>>> GetMaterial_Categorias()
        {
            return await _context.Material_Categorias.ToListAsync();
        }

        // GET: api/Materiales_categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material_categoria>> GetMaterial_categoria(int id)
        {
            var material_categoria = await _context.Material_Categorias.FindAsync(id);

            if (material_categoria == null)
            {
                return NotFound();
            }

            return material_categoria;
        }

        // PUT: api/Materiales_categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial_categoria(int id, Material_categoria material_categoria)
        {
            if (id != material_categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(material_categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Material_categoriaExists(id))
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

        // POST: api/Materiales_categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Material_categoria>> PostMaterial_categoria(Material_categoria material_categoria)
        {
            _context.Material_Categorias.Add(material_categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterial_categoria", new { id = material_categoria.Id }, material_categoria);
        }

        // DELETE: api/Materiales_categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial_categoria(int id)
        {
            var material_categoria = await _context.Material_Categorias.FindAsync(id);
            if (material_categoria == null)
            {
                return NotFound();
            }

            _context.Material_Categorias.Remove(material_categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Material_categoriaExists(int id)
        {
            return _context.Material_Categorias.Any(e => e.Id == id);
        }
    }
}
