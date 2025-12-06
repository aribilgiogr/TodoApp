using Core.Abstracts;
using Data.Contexts;

namespace Data
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            var context = new TodoDb();
            return new UnitOfWork(context);
        }
    }
}
