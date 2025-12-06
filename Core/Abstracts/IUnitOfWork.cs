using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoRepository TodoRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void Commit();
    }
}
