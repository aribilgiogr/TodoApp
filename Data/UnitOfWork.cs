using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using System;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDb context;
        public UnitOfWork(TodoDb context)
        {
            this.context = context;
        }

        private ITodoRepository todoRepository;
        public ITodoRepository TodoRepository => todoRepository = todoRepository ?? new TodoRepository(context);

        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository = categoryRepository ?? new CategoryRepository(context);

        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Dispose();
                throw ex;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
