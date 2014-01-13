using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using TicketSystem.Web.Models;
using TicketSystem.Models;

namespace TicketSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCategories([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Categories.All()
                .Select(x => new CategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.All().Where(c => c.Id == category.Id).FirstOrDefault();

            categoryDb.Name = category.Name;
            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var newCategory = new Category() { Name = category.Name };

            this.Data.Categories.Add(newCategory);

            this.Data.SaveChanges();
            category.Id = newCategory.Id;

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var categoryDb = this.Data.Categories.All().Where(c => c.Id == category.Id).FirstOrDefault();

            foreach (var ticket in categoryDb.Tickets.ToList())
            {
                foreach (var comment in ticket.Comments.ToList())
                {
                    this.Data.Comments.Delete(comment.Id);
                }

                this.Data.Tickets.Delete(ticket.Id);
            }

            this.Data.Categories.Delete(categoryDb.Id);

            this.Data.SaveChanges();

            return Json(new[] { category }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}