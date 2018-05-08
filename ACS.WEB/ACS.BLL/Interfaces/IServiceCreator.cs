
namespace ACS.BLL.Interfaces
{
    /// <summary>
    /// В данном случае для упрощения примера я не буду использовать контейнеры внедрения зависимостей, а вместо этого воспользуюсь абстрактной фабрикой, которую будет представлять интерфейс IServiceCreator. Хотя естественнно можно также использовать для внедрения зависимостей DI-контейнеры типа Ninject.
    /// </summary>
    public interface IServiceCreator
    {
        IAccountAppUserService CreateAccountUserService(string connection);
    }
}
