using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class TodoCreateDto
    {
        [Required, StringLength(200), Display(Name = "Görev Başlığı")]
        public string Title { get; set; }

        [StringLength(1000), Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
