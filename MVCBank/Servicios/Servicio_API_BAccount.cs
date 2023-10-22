using MVCBank.Models;
using System.Security.Principal;

namespace BankSystem.Web.Servicios
{
    public class Servicio_API_BAccount : IServicio_API_BAccount
    {
        public static string port = "5142";

        public async Task<List<BankAccount>> Lista()
        {
            List<BankAccount>? lista = new List<BankAccount>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/BankAccount");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<BankAccount>>();
            }

            return lista;
        }

        public async Task<bool> Editar(BankAccount account)
        {
            var client = new HttpClient();
            var response = await client.PutAsJsonAsync($"http://localhost:{port}/api/BankAccount/{account.IdAccount}", account);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Guardar(BankAccount account)
        {
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync($"http://localhost:{port}/api/BankAccount", account);

            return response.IsSuccessStatusCode;
        }

        public async Task<BankAccount> Obtener(int IdAccount)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/BankAccount/{IdAccount}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<BankAccount>();
            }

            return null;
        }
        public async Task<bool> Eliminar(int IdAccount)
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"http://localhost:{port}/api/BankAccount/{IdAccount}");
            return response.IsSuccessStatusCode;
        }

        public async Task<BankAccount> GetIdUser(int IdUser)
        {
            BankAccount account = null;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5142/api/BankAccount/user/{IdUser}");

            if (response.IsSuccessStatusCode)
            {
                account =await response.Content.ReadAsAsync<BankAccount>();
                
                Console.WriteLine("co" + account.IdUser);
                return account;
            }

            return null;
        }

       
    }


}