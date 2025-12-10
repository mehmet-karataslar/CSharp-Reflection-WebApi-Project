using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

/// <summary>
/// Ürün veri transfer nesnesi - Validation attribute'ları ile
/// </summary>
public class ProductDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ürün adı zorunludur")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Ürün adı 3 ile 100 karakter arasında olmalıdır")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Fiyat zorunludur")]
    [Range(0.01, 1000000, ErrorMessage = "Fiyat 0.01 ile 1,000,000 arasında olmalıdır")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Stok miktarı zorunludur")]
    [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0 veya daha büyük olmalıdır")]
    public int Stock { get; set; }
}

