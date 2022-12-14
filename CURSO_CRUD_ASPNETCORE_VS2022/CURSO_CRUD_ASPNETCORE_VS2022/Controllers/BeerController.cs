using CURSO_CRUD_ASPNETCORE_VS2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CURSO_CRUD_ASPNETCORE_VS2022.Controllers
{
    public class BeerController : Controller
    {
        #region Forma de Regrese la Informacion de la Base de Datos por medio de la Inyeccion de Dependencia 

        private readonly BD_PubContext _context; /* Hacemos esta instancea para que el objeto no sea modificado una vez asignado */

        /* CONSTRUCTOR DE MI CLASE BEERCONTROLLER */
        public BeerController(BD_PubContext context) /* Forma de obtener la inyeccion de Dependencia en los (BD_PubContext context) */
        {
            _context = context; /*Mientras aqui lo asignamos a nuestro campo privado */
        }
        #endregion

        /* Luego de hacer lo de arriba modificamos el metodo de abajo para mostrar los datos de la Base de Datos */

        #region Forma de Mostrar la lista de Nuestros Datos en ASP .NET
        public async Task<IActionResult> Index()
        {    /* En este caso _CONTEXT = la Base de Datos, BEERS = La tabla,ToListAsync = Lista de Objetos de tabla BEERS */
            var beers = _context.Beers.Include(b => b.Brand);
            return View(await beers.ToListAsync());
        }
        #endregion

        public IActionResult Create()
        {
            /*Forma de agregar los Datos a la Base de Datos */
            ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name"); /*Forma en la que puede acceder a mi BD con VIEWDATA */
            return View();
        }
    }
}
