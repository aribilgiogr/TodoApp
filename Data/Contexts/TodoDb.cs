using Core.Concretes.Entities;
using System.Data.Entity;

namespace Data.Contexts
{
    public class TodoDb : DbContext
    {
        public TodoDb() : base("name=TodoDb")
        {

        }

        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
