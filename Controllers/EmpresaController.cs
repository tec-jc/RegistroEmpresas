using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroEmpresas.Models;

namespace RegistroEmpresas.Controllers
{
    public class EmpresaController : Controller
    {
        //consumir la inyección de dependencias mediante el constructor
        private readonly ContextoDeDatos _contexto;
        public EmpresaController(ContextoDeDatos contexto)
        {
            _contexto = contexto;
        }

        // Acción que muestra el listado de empresas registradas
        public async Task<IActionResult> Index()
        {
            var listaEmpresas = await _contexto.Empresas.Include(c => c.Contacto).ToListAsync();
            return View(listaEmpresas);
        }

        // Acción que muestra el detalle de un registro
        public async Task<IActionResult> Details(int id)
        {
            var empresa = await _contexto.Empresas.Include(c => c.Contacto).FirstOrDefaultAsync(e => e.Id == id);
            return View(empresa);
        }

        // Acción que muesta el formulario para agregar una empresa
        public async Task<IActionResult> Create()
        {
            ViewBag.Contactos = await _contexto.Contactos.ToListAsync();
            return View();
        }

        // Acción que recibe los datos del formulario y los envía a la bd por medio de EF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            _contexto.Empresas.Add(empresa);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Acción que muestra el formulario con los datos de la empresa
        public async Task<IActionResult> Edit(int id)
        {
            var empresa = await _contexto.Empresas.Include(c => c.Contacto).FirstOrDefaultAsync(e => e.Id == id);
            ViewBag.Contactos = await _contexto.Contactos.ToListAsync();
            return View(empresa);
        }

        // Acción que recibe los datos modificados para enviarlos a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Empresa empresa)
        {
            _contexto.Empresas.Update(empresa);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Acción que muestre los datos del registro para confirmar la eliminación
        public async Task<IActionResult> Delete(int id)
        {
            var empresa = await _contexto.Empresas.Include(c => c.Contacto).FirstOrDefaultAsync(e => e.Id == id);
            return View(empresa);
        }

        // Acción que recibe la confirmación para eliminar el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Empresa empresa)
        {
            _contexto.Empresas.Remove(empresa);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
