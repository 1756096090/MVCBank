using MVCBank.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BankSystem.Web.Servicios
{
    public class Servicio_API_User : IServicio_API_User
    
    {
        public static string port = "5142";

        public async Task<User> Autenticar(string Email, string Password)
        {
            User user = null;
            var client = new HttpClient();
            var response = await client.GetAsync($"http://localhost:5142/api/User/{Email}/{Password}");

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
                Console.WriteLine(user);
            }
            return user;
        }

        public async Task<int> Crear(User user)
            
        {
            int indice = 0;
            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:5142/api/User", user);
            indice = await response.Content.ReadAsAsync<int>();
            Console.WriteLine(indice);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(indice);
                return indice;
            }
            return indice;
        }
        

        public async Task<bool> Eliminar(User user)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:{port}/api/User/{user.IdUser}");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Guardar(User user)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.PutAsJsonAsync($"http://localhost:{port}/api/User/{user.IdUser}", user);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<User>> Lista()
        {
            List<User> lista = new List<User>();
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/User");

            if (response.IsSuccessStatusCode)
            {
                lista = await response.Content.ReadAsAsync<List<User>>();
            }

            return lista;
        }

        public async Task<User> Obtener(int IdUser)
        {
            User user = null;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:{port}/api/User/{IdUser}");

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }

            return user;
        }
    }
}