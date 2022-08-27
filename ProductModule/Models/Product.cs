using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModule.Models;

[Table("product")]
public class Product : SystemEntity
{
    [Key] public string ProductId { get; set; }
    [Required] public string ExternalProductId { get; set; }
    [Required] public string ProductName { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string CustomsDescription { get; set; }
}