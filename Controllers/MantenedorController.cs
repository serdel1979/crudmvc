using CRUD.Datos;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class MantenedorController : Controller
    {


        ContactoDatos contactoDatos = new ContactoDatos();  

        public IActionResult Listar()
        {
            var lista = contactoDatos.Listar();

            return View(lista);
        }



        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarContacto(ContactoModel contact)
        {

            if (contactoDatos.Guardar(contact))
            {
                return RedirectToAction("Listar");
            }

            return View();
        }


    }
}
