using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
    }
}
