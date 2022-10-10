using Microsoft.AspNetCore.Mvc;

namespace CURSO_CRUD_ASPNETCORE_VS2022.Controllers
{
    public class BrandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
