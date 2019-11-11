namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Data;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly PandaDBExtended context;

        public HomeController(PandaDBExtended context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {

            //if (User.Identity.IsAuthenticated == false)
            //{
                var userPackages =
                    this.context.Packages
                        .Where(packages => packages.Recipient.UserName == this.User.Identity.Name)
                        .Include(Package => Package.Status)
                        .Select(package => new PackageHomeViewModel
                        {
                            Id = package.Id,
                            Description = package.Description,
                            Status = package.Status.Name
                        })
                        .ToList();

                return this.View(userPackages);
            //}

            //return this.View();

        }
    }
}
