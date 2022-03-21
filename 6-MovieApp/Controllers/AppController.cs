using _6_MovieApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_MovieApp.Controllers
{
    public class AppController : Controller
    {
        public static List<MovieAppViewModel> _movies =  new List<MovieAppViewModel>();

        public IActionResult Index()
        {
            return View(_movies);
        }

        //[HttpGet("Edit")]
        /* Modificacion mia para que genere el identificador
         */
        public IActionResult AddOrEdit(Guid id)
        {
            var movie = _movies.FirstOrDefault(x => x.Identi == id);
            return View(movie);
        }

        /* en lugar de poner x.Id se reemplaza por x.Identi
         * para recoger el identificador generado automaticamente 
         */
        [HttpPost]
        public IActionResult AddOrEdit(MovieAppViewModel model)
        {
            var movie = _movies.FirstOrDefault(x => x.Identi == model.Id);

            if (ModelState.IsValid)
            {
                if (movie == null)
                {  
                    _movies.Add(model);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    movie.Genero = model.Genero;
                    movie.Nombre = model.Nombre;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        [HttpGet("About")]
        public IActionResult About()
        {
            return View();
        }

        /* modificacion para que funcione bien
         */
        public IActionResult Delete(Guid id)
        {
            _movies.Remove(_movies.FirstOrDefault(x => x.Identi == id));
            return RedirectToAction(nameof(Index));
        }
    }
}
