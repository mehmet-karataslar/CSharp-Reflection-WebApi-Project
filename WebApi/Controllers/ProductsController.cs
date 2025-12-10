using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // In-memory veri deposu (gerçek uygulamada veritabanı kullanılır)
    private static List<ProductDto> _products = new List<ProductDto>
    {
        new ProductDto { Id = 1, Name = "Laptop", Description = "Yüksek performanslı laptop", Price = 15000.00m, Stock = 10 },
        new ProductDto { Id = 2, Name = "Mouse", Description = "Kablosuz mouse", Price = 250.00m, Stock = 50 },
        new ProductDto { Id = 3, Name = "Klavye", Description = "Mekanik klavye", Price = 800.00m, Stock = 30 }
    };

    /// <summary>
    /// Tüm ürünleri listele
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAll()
    {
        return Ok(_products);
    }

    /// <summary>
    /// ID ile ürün getir
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<ProductDto> GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new { message = $"ID={id} olan ürün bulunamadı." });
        }
        return Ok(product);
    }

    /// <summary>
    /// Yeni ürün ekle
    /// </summary>
    [HttpPost]
    public ActionResult<ProductDto> Create([FromBody] ProductDto product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Yeni ID oluştur
        var newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
        product.Id = newId;
        _products.Add(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    /// <summary>
    /// Ürün sil
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new { message = $"ID={id} olan ürün bulunamadı." });
        }

        _products.Remove(product);
        return NoContent();
    }
}

