using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC.Data;
using TDDTestingMVC.Models;

namespace TDDTestingMVC.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objCliente = new ClienteDataAccessLayer();
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objCliente.getAllClientes().ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                objCliente.addCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Edit(int id)
        {
            Cliente cliente = objCliente.getAllClientes().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente cliente)
        {
            if (id == 0 || cliente == null)
            {
                return NotFound();
            }
            objCliente.updateCliente(id, cliente);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            objCliente.deleteCliente(id);
            return RedirectToAction("Index");
        }


    }
}
