using MVCBank.Models;

namespace BankSystem.Web.Servicios
{
    public interface IServicio_API_BAccount
    {
        Task<List<BankAccount>> Lista();
        Task<BankAccount> Obtener(int IdAccount);
        Task<bool> Guardar(BankAccount account);
        Task<bool> Editar(BankAccount account);
        Task<bool> Eliminar(int IdAccount);
        Task<BankAccount> GetIdUser(int IdUser);
        
    }
}
