using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Dtoo
{
    public class CategoryDto
    {
        [Required]
        public string? CategoryNameDto { get; set; }
    }
}