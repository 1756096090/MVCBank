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
        public IActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5

        public async Task<IActionResult> Details()
        {
            List<BankAccount> bankAccounts = await servicio_APIBAccount.Lista();
            List<User> users = await servicioAPI.Lista();
            Console.WriteLine("Usuarios: " + users.Count + "\nCuentas bancarias " + bankAccounts.Count);
            ViewData["BankAccount"] = bankAccounts;
            ViewData["Users"] = users;
            return View("Details");
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
