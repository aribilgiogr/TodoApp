using Core.Abstracts;
using Data.Contexts;

namespace Data
{
    public class UnitOfWorkFactory
    {
        // Factory Tasarım Deseni ile UnitOfWork nesnesini LazyLoading ile oluşturuyoruz. Gerektiğinde oluşuyor, bellekte fazladan yer kaplamıyor. Bu yöntem using ile birlikte kullanıldığında bellekte tutulan nesnelerin iş bitiminde bellekten atılmasını sağlar.
        public static IUnitOfWork Create()
        {
            var context = new TodoDb();
            return new UnitOfWork(context);
        }
    }
}
