using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class CategoryCreateDto
    {
        [Required, StringLength(100), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
