using System.ComponentModel.DataAnnotations;

public class Products
{
    public string? _id { get; set; }

    [Required(ErrorMessage = "title is required")]
    public string? title { get; set; }

    [Required(ErrorMessage = "description is required")]
    public string? description { get; set; }

    [Required(ErrorMessage = "image is required")]
    public string? image { get; set; }
    public string[]? imageDetail { get; set; }

    [Required(ErrorMessage = "categoryId is required")]
    public string? categoryId { get; set; }

    [Required(ErrorMessage = "price is required")]
    public int price { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}