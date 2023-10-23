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

        [HttpPost]
        public async Task<IActionResult> Details(int IdAccount)
        {
            Console.WriteLine("Iniciando post");
            var account = await servicio_APIBAccount.Obtener(IdAccount);
            Console.WriteLine("Cuenta obtenida: " +  account.IdAccount);
            if (account != null)
            {
                Console.WriteLine("Id Account " + account.IdAccount);
                Transferencia transfer = new Transferencia() { Amount = 0, IdAccountSender = account.IdAccount, IdAccountReceiver = 0};
                var response = transfer;
                return View("Edit", transfer);
            }
            Console.WriteLine("Fallo");
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
                var lista = await servicio_APIBAccount.Lista();
                account.AccountNumber = lista.Count + 1;
                account.AccountAmount = 0;
                account.IdUser = response;
                var response2 = await servicio_APIBAccount.Guardar(account);

            return View("Index");

            } 
            return View();

        }

       



        // GET: NormUserController/Edit/5
       public async Task<ActionResult> Edit(int IdAccount)
        {

            var response = await servicio_APIBAccount.Obtener(IdAccount);
            Console.WriteLine("hola" + response?.IdUser);
            if (response?.IdUser != 0)
            {
                Transferencia transfer = new Transferencia() { Amount = 0, IdAccountSender = response.IdAccount, IdAccountReceiver = 0 };
                
                return View("Edit", transfer);


            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Transferencia bank)
        {
            if(bank != null)
            {
                Console.WriteLine("Cantidad: " + bank.Amount);
                Console.WriteLine("Id Emisor: " + bank.IdAccountSender);
                Console.WriteLine("Id Receptor: " + bank.IdAccountReceiver);

                BankAccount accountSender = await servicio_APIBAccount.Obtener(bank.IdAccountSender);
                //Console.WriteLine("Comprobacion emisor: " + accountSender.IdAccount); //Emite error null reference exception
                BankAccount accountReceiver = await servicio_APIBAccount.Obtener(bank.IdAccountReceiver);
                Console.WriteLine("Comprobacion receptor: " + accountReceiver.IdAccount);
                
                if (accountReceiver != null)
                {
                    accountReceiver.AccountAmount = bank.Amount;
                    Console.WriteLine("Transferencia emitida: ");
                }

                Console.WriteLine("Transferencia realizandose...");
                //await servicio_APIBAccount.Editar(accountSender);
                bool success = await servicio_APIBAccount.Editar(accountReceiver);
                Console.WriteLine("Transferencia realizada..." + success);
                
                return View("Details", accountSender);
            }
            Console.WriteLine("Operacion fallida");
            return BadRequest("No se pudo realizar la accion");            
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
