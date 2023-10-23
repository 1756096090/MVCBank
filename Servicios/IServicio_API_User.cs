using MVCBank.Models;

namespace BankSystem.Web.Servicios
{
    public interface IServicio_API_User
    {
        Task<List<User>> Lista();
        Task<int> Crear(User user);
        Task<User> Obtener(int IdUser);
        Task<bool> Guardar(User account);
        Task<bool> Eliminar(User account);
        Task<User> Autenticar(String Email, String Password);

    }
}
