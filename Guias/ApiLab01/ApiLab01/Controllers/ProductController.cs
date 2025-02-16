using ApiLab01.Data;
using ApiLab01.DTOs;
using ApiLab01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiLab01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductDbContext _context;
        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        #region Obtener todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> ObtenerProducto()
        {
            var productos = await _context.Productos.ToListAsync();
            var productsDTO = productos.Select(p => new ProductDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Stock = p.Stock
            }).ToList();

            return Ok(productsDTO);
        }
        #endregion

        #region Obtener por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> ObtenerProductoPorId(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            var productDTO = new ProductDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Stock = producto.Stock
            };
            return Ok(productDTO);
        }
        #endregion

        #region Insertar
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductDTO productDTO)
        {
            var producto = new Productos
            {
                Nombre = productDTO.Nombre,
                Precio = productDTO.Precio,
                Stock = productDTO.Stock
            };
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }
        #endregion

        #region Actualizar
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, ProductDTO productDTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            producto.Nombre = productDTO.Nombre;
            producto.Precio = productDTO.Precio;
            producto.Stock = productDTO.Stock;
            await _context.SaveChangesAsync();
            return Ok();
        }
        #endregion

        #region Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        #endregion
    }
}