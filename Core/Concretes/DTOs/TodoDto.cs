using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class TodoDto
    {
        public int Id { get; set; }

        [Required, StringLength(200), Display(Name = "Görev Başlığı")]
        public string Title { get; set; }

        [StringLength(1000), Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Tamamlandı mı?")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Tamamlanma Tarihi")]
        public DateTime? CompletedDate { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
    }
}
