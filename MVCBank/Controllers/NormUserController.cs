using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCBank.Models;
using BankSystem.Web.Servicios;


namespace MVCBank.Controllers
{
    public class NormUserController : Controller
    {
        private readonly IServicio_API_User servicioAPI;
        private readonly IServicio_API_BAccount servicio_APIBAccount;
        public NormUserController(IServicio_API_User servicioAPI, IServicio_API_BAccount servicio_APIBAccount)
        {
            this.servicioAPI = servicioAPI;
            this.servicio_APIBAccount = servicio_APIBAccount;
        }

        // GET: NormUserController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password)

        {
            
            var response = await servicioAPI.Autenticar(Email, Password);
                Console.WriteLine("hola"+response?.IdUser);
            if (response?.IdUser != 0)
            {
                var response2 = await servicio_APIBAccount.GetIdUser((int)(response?.IdUser));
                Console.WriteLine("Resp"+response2?.IdUser);
                return View("Details",response2);


            }
            return View(); 
        }

        // GET: NormUserController/Details/5
        public IActionResult Details(BankAccount account)
        {
       

            if (account != null)
            {
                Console.WriteLine("con" + account.IdUser);
                return View(account);
            }
            return RedirectToAction("Index");
        }

        // GET: NormUserController/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            user.Role = "string";
            user.IdUser = 0;
            
            user.Phone = "stringstri";
            user.DNI = "string";
            user.Name = "string";
            var response = await servicioAPI.Crear(user);

            Console.WriteLine(user.Password+"hola");
            if (response!=0)
            {   
                BankAccount account = new BankAccount();
                account.AccountNumber = 1;
                account.AccountAmount = 0;
                account.IdUser = response;
                var response2 = await servicio_APIBAccount.Guardar(account);

            return View("Index");

            } 
            return View();

        }

       



        // GET: NormUserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NormUserController/Edit/5
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

        // GET: NormUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NormUserController/Delete/5
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
