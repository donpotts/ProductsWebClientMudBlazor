using System.ComponentModel.DataAnnotations;

namespace ProductsWebClientMudBlazor.Models;

public class Products
{
    [Key]
    public long? Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }
}
