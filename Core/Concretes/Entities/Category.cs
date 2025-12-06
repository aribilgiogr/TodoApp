using Core.Abstracts.Bases;
using System.Collections.Generic;

namespace Core.Concretes.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Todo> Todos { get; set; }
    }
}
