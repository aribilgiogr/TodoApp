using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using System.Collections.Generic;

namespace Business.Services
{
    public class TodoService : ITodoService
    {
        public void CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                var category = AutoMapperConfig.Mapper.Map<Category>(categoryCreateDto);
                uow.CategoryRepository.Add(category);
                uow.Commit();
            }
        }

        public void CreateTodo(TodoCreateDto todoCreateDto)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                var todo = AutoMapperConfig.Mapper.Map<Todo>(todoCreateDto);
                uow.TodoRepository.Add(todo);
                uow.Commit();
            }
        }

        public void DeleteCategory(int id) => throw new System.NotImplementedException();

        public void DeleteTodo(int id) => throw new System.NotImplementedException();

        public IEnumerable<CategoryDto> GetCategories()
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                var categories = uow.CategoryRepository.FindMany();
                return AutoMapperConfig.Mapper.Map<IEnumerable<CategoryDto>>(categories);
            }
        }

        public TodoDto GetTodoById(int id)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                var todo = uow.TodoRepository.Find(id);

                if (todo == null) { return null; }

                return AutoMapperConfig.Mapper.Map<TodoDto>(todo);
            }
        }

        public IEnumerable<TodoDto> GetTodos(int? categoryId = null)
        {
            using (IUnitOfWork uow = UnitOfWorkFactory.Create())
            {
                var todos = categoryId.HasValue
                    ? uow.TodoRepository.FindMany(t => t.CategoryId == categoryId.Value, "Category")
                    : uow.TodoRepository.FindMany(null, "Category");

                return AutoMapperConfig.Mapper.Map<IEnumerable<TodoDto>>(todos);
            }
        }

        public void UpdateCategory(int id, CategoryCreateDto categoryUpdateDto) => throw new System.NotImplementedException();

        public void UpdateTodo(int id, TodoCreateDto todoUpdateDto) => throw new System.NotImplementedException();
    }
}
