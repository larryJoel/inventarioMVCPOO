using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using InventarioMVCPOO.Models;
using InventarioMVCPOO.Datos;
using Microsoft.EntityFrameworkCore;
namespace InventarioMVCPOO.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _contexto;

    public HomeController(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _contexto.Articulo.ToListAsync());
    }

     [HttpGet]
    public IActionResult Crear()
    {
        return View();
    }

      [HttpPost]
      [ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Articulo articulo)
    {
        if(ModelState.IsValid)
        {
           _contexto.Articulo.Add(articulo) ;
           await _contexto.SaveChangesAsync();
           TempData["Mensaje"]="El articulo se creo correctamente";
           return RedirectToAction("index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Editar(int? Id)
    {
        if(Id == null){
            return NotFound();
        }
        var articulo = _contexto.Articulo.Find(Id);
        if(articulo == null){
            return NotFound();
        }
        return View(articulo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(Articulo articulo)
    {
        if(ModelState.IsValid)
        {
           _contexto.Update(articulo) ;
           await _contexto.SaveChangesAsync();
           TempData["Mensaje"]="El articulo se editó correctamente";
           return RedirectToAction("index");
        }
        return View(articulo);
    }

     [HttpGet]
    public IActionResult Borrar(int? Id)
    {
        if(Id == null){
            return NotFound();
        }
        var articulo = _contexto.Articulo.Find(Id);
        if(articulo == null){
            return NotFound();
        }
        return View(articulo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Borrar(int id)
    {
            var articulo = await _contexto.Articulo.FindAsync(id);
            if(articulo == null){
                return NotFound();
            }
            _contexto.Articulo.Remove(articulo) ;
           await _contexto.SaveChangesAsync();
           TempData["Mensaje"]="El articulo se borró correctamente";
           return RedirectToAction("index");
        
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
