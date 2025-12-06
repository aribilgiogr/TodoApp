using Core.Abstracts.IRepositories;
using Core.Concretes.Entities;
using Data.Contexts;
using System;
using System.Data.Entity;
using Utilities.Generics;

namespace Data.Repositories
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(TodoDb context) : base(context)
        {
        }

        public void ToggleComplete(int todo_id)
        {
            var todo = Find(todo_id);
            if (todo != null)
            {
                todo.IsCompleted = !todo.IsCompleted;
                todo.CompletedDate = todo.IsCompleted ? DateTime.Now : (DateTime?)null;
                Update(todo);
            }
        }
    }
}
