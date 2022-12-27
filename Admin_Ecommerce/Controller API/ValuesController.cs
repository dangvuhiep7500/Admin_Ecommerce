using System.ComponentModel.DataAnnotations;

public class Products
{
    public string? _id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string? title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string? description { get; set; }

    [Required(ErrorMessage = "Image is required")]
    public string? image { get; set; }
    public string[]? imageDetail { get; set; }

    [Required(ErrorMessage = "CategoryId is required")]
    public string? categoryId { get; set; }

    [Required(ErrorMessage = "Price is required")]
    public int price { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}