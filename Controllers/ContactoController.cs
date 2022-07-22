using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroEmpresas.Models;

namespace RegistroEmpresas.Controllers
{
    public class ContactoController : Controller
    {
        //consumir la inyección de dependencias por medio del constructor
        private readonly ContextoDeDatos _contexto;
        public ContactoController(ContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Acción que muestra el listado de contactos de la bd
        /// </summary>
        /// <returns>View</returns>
        public async Task<IActionResult> Index()
        {
            var listaContactos = await _contexto.Contactos.ToListAsync();
            return View(listaContactos);
        }

        /// <summary>
        /// Acción que muestra el detalle de un contacto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public async Task<IActionResult> Details(int id)
        {
            var contacto = await _contexto.Contactos.FirstOrDefaultAsync(c => c.Id == id);
            return View(contacto);
        }

        /// <summary>
        /// Acción que muestra el formulario para un registro nuevo
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Create()
        {
            return View();
        }

        // Acción que recibe los datos del formulario y los envía a la bd por medio de EF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
                
            
        }

        // Acción que muestra el formulario con los datos del contacto
        public async Task<IActionResult> Edit(int id)
        {
            var contacto = await _contexto.Contactos.FirstOrDefaultAsync(c => c.Id == id);
            return View(contacto);
        }

        // Acción que recibe los datos modificados y los envía a la bd por medio de EF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contacto);
            
        }

        // Acción que muestra el registro para confirmar eliminación
        public async Task<IActionResult> Delete(int id)
        {
            var contacto = await _contexto.Contactos.FirstOrDefaultAsync(c => c.Id == id);
            return View(contacto);
        }

        // Acción que recibe la confirmación para eliminar el contacto
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Contacto contacto)
        {
            _contexto.Contactos.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
