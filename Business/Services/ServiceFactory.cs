using Core.Abstracts.IServices;

namespace Business.Services
{
    public class ServiceFactory
    {
        // Factory Design Pattern: Genel olarak nesne yaratma işlemlerini merkezi bir noktada toplamak için kullanılır. Olabildiğince new operatörünü kullanmaktan kaçınırız.
        // Örn: Tüm servis nesnelerini bu sınıf üzerinden yaratırız.
        /* Avantajları:
         * - Nesne yaratma kodunu merkezi bir noktada toplar, bu da bakım ve yönetimi kolaylaştırır.
         * - Bağımlılıkları azaltır, çünkü istemciler doğrudan sınıf isimlerine bağlı kalmazlar.
         * - Yeni servis türleri eklemek veya mevcutları değiştirmek daha kolaydır.
         * - Nesne yaratma sürecini soyutlayarak, istemcilerin nesne yaratma detaylarıyla ilgilenmesini engeller.
         */
        public static ITodoService CreateTodoService()
        {
            return new TodoService();
        }
    }
}
