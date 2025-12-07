using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface ITodoService
    {
        IEnumerable<TodoDto> GetTodos(int? categoryId = null);
        TodoDto GetTodoById(int id);
        IEnumerable<CategoryDto> GetCategories();

        void CreateTodo(TodoCreateDto todoCreateDto);
        void UpdateTodo(int id, TodoCreateDto todoUpdateDto);
        void DeleteTodo(int id);

        void CreateCategory(CategoryCreateDto categoryCreateDto);
        void UpdateCategory(int id, CategoryCreateDto categoryUpdateDto);
        void DeleteCategory(int id);
    }
}
