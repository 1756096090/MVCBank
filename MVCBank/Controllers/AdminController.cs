using BankSystem.Web.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBank.Models;

namespace MVCBank.Controllers
{
    public class AdminController : Controller
    {
        private readonly IServicio_API_User servicioAPI;
        private readonly IServicio_API_BAccount servicio_APIBAccount;
        public AdminController(IServicio_API_User servicioAPI, IServicio_API_BAccount servicio_APIBAccount)
        {
            this.servicioAPI = servicioAPI;
            this.servicio_APIBAccount = servicio_APIBAccount;
        }


        // GET: AdminController
      
        public IActionResult Index(User user)
        {
            return View("Index", user);
        }

        // GET: AdminController/Details/5

        public async Task<IActionResult> Information()
        {
            List<BankAccount> bankAccounts = await servicio_APIBAccount.Lista();
            List<User> users = await servicioAPI.Lista();
            Console.WriteLine("Usuarios: " + users.Count + "\nCuentas bancarias " + bankAccounts.Count);
            ViewData["BankAccount"] = bankAccounts;
            ViewData["Users"] = users;
            return View("Info");
        }

        // GET: AdminController/Create
        public async Task<IActionResult> DetailsUser(int IdUser)
        {
            User user = await servicioAPI.Obtener(IdUser);

            if(user != null)
            {
                return View("DetailsUser", user);
            }
            return BadRequest("No se pudo obtener el usuario");
        }

        // POST: AdminController/Create
        

        // GET: AdminController/Edit/5
        /*public async Task<ActionResult> Edit(int IdUser)
        {
            var user = await servicioAPI.Obtener(IdUser);
            
            if(user != null)
            {
                return RedirectToAction("Edit", user);
            }

            return View();
        }*/


        // POST: AdminController/Edit/5
        

        // GET: AdminController/Delete/5

        // POST: AdminController/Delete/5
        public async Task<ActionResult> Delete(int IdUser)
        {
            User user = await servicioAPI.Obtener(IdUser);

            if (user != null)
            {
                //bool resp = await servicioAPI.Eliminar(user);
                return View();
            }
            return BadRequest("No se pudo eliminar el usuario");
        }
    }
}
