namespace FDMC.Controllers
{
    using System.Linq;
    using FDMC.Data;
    using FDMC.Models.BindingModels;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private FdmcDBContext _context;

        public HomeController(FdmcDBContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var cats = this._context.Cats
                .Select(e => new CatsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList();

            return this.View();
        }
    }
}
