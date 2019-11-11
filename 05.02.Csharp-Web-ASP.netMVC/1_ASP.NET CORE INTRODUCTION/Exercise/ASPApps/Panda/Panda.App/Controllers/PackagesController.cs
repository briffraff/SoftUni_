namespace Panda.App.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Panda.Models;
    using System;
    using System.Globalization;

    public class PackagesController : Controller
    {
        private readonly PandaDBExtended _context;

        public PackagesController(PandaDBExtended context)
        {
            this._context = context;
        }

        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this._context.Users.ToList();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            Package package = new Package
            {
                Description = bindingModel.Description,
                Recipient = this._context.Users.SingleOrDefault(user => user.UserName == bindingModel.Recipient),
                ShippingAddress = bindingModel.ShippingAddress,
                Weight = bindingModel.Weight,
                Status = this._context.PackageStatuses.SingleOrDefault(status => status.Name == "Pending")
            };

            _context.Packages.Add(package);
            _context.SaveChanges();

            return this.Redirect("/Packages/Pending");
        }


        [HttpGet("/Packages/Ship/{id}")]
        public IActionResult Ship(string id)
        {
            Package package = this._context.Packages.Find(id);
            package.Status = this._context.PackageStatuses.SingleOrDefault(status => status.Name == "Shipped");
            package.EstimatedDeliveryDate = DateTime.UtcNow.AddDays(new Random().Next(5, 10));
            this._context.Update(package);
            this._context.SaveChanges();

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        public IActionResult Deliver(string id)
        {
            Package package = this._context.Packages.Find(id);
            package.Status = this._context.PackageStatuses.SingleOrDefault(status => status.Name == "Delivered");
            this._context.Update(package);
            this._context.SaveChanges();

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("/Packages/Acquire/{id}")]
        public IActionResult Acquire(string id)
        {
            Package package = this._context.Packages.Find(id);
            package.Status = this._context.PackageStatuses.SingleOrDefault(status => status.Name == "Acquired");
            this._context.Update(package);

            //TODO Create receipt

            this._context.SaveChanges();

            return this.Redirect("/Packages/Acquired");
        }

        [HttpGet("/Packages/Details/{id}")]
        public IActionResult Details(string id)
        {
            Package package = this._context.Packages
                .Where(packageFromDb => packageFromDb.Id == id)
                .Include(packageFromDb => packageFromDb.Recipient)
                .Include(packageFromDb => packageFromDb.Status)
                .SingleOrDefault();

            var detailsModel = new PackageDetailsViewModel()
            {
                Id = package.Id,
                Description = package.Description,
                Weight = package.Weight,
                Status = package.Status.Name,
                ShippingAddress = package.ShippingAddress,
                Recipient = package.Recipient.UserName
            };

            if (package.Status.Name == "Pending")
            {
                detailsModel.EstimatedDeliveryDate = "N/A";
            }
            else if (package.Status.Name == "Shipped")
            {
                detailsModel.EstimatedDeliveryDate =
                    package.EstimatedDeliveryDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                detailsModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(detailsModel);

        }


        [HttpGet]
        public IActionResult Pending()
        {
            return this.View(_context.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Pending")
                .ToList().Select(x =>
            {
                return new PackagePendingViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    ShippingAddress = x.ShippingAddress,
                    Weight = x.Weight,
                    Recipient = x.Recipient.UserName,
                };
            }).ToList());
        }


        [HttpGet]
        public IActionResult Shipped()
        {
            return this.View(_context.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Shipped")
                .ToList().Select(x =>
                {
                    return new PackageShippedViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Weight = x.Weight,
                        EstimatedDeliveryDate = x.EstimatedDeliveryDate.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                        Recipient = x.Recipient.UserName,
                    };
                }).ToList());
        }

        [HttpGet]
        public IActionResult Delivered()
        {
            return this.View(_context.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Delivered" || package.Status.Name == "Acquired")
                .ToList().Select(x =>
                {
                    return new PackageDeliveredViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Weight = x.Weight,
                        ShippingAddress = x.ShippingAddress,
                        Recipient = x.Recipient.UserName,
                    };
                }).ToList());
        }

    }
}