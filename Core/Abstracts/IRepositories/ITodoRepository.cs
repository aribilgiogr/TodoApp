using Core.Concretes.Entities;
using Utilities.Generics;

namespace Core.Abstracts.IRepositories
{
    public interface ITodoRepository : IRepository<Todo>
    {
        void ToggleComplete(int todo_id);
    }
}
