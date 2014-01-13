using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TicketSystem.Web.Models;
using TicketSystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace TicketSystem.Web.Controllers
{
    [Authorize]
    public class TicketsController : BaseController
    {
        //
        // GET: /Tickets/
        public ActionResult Index()
        {
            return View();
        }

        private IQueryable<ListPageTicketViewModel> GetAllTickets()
        {
            var data = this.Data.Tickets.All().Select(x => new ListPageTicketViewModel
            {
                Author = x.Author.UserName,
                Category = x.Category.Name,
                PriorityName = x.Priority,
                Title = x.Title,
                Id = x.Id
            }).OrderBy(x => x.Id);

            return data;
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddTicket()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public ActionResult Create(SubtmitTicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);
                var category = this.Data.Categories.All().Where(c => c.Name == model.CategoryName).FirstOrDefault();
                var ticket = new Ticket
                {
                    Author = user,
                    Category = category,
                    CategoryId = category.Id,
                    Description = model.Description,
                    Priority = model.Priority,
                    ScreenshotUrl = model.ImageUrl,
                    Title = model.Title,
                };

                this.Data.Tickets.Add(ticket);
                this.Data.Users.All().FirstOrDefault(u => u.Id == userId).Points++;
                this.Data.SaveChanges();
                return View("List");
            }
            else
            {
                return View("AddTicket", model);
            }
        }

        public ActionResult Search(SubmitSearchModel submitModel)
        {
            var result = this.Data.Tickets.All();

            if (!string.IsNullOrEmpty(submitModel.CategoryName) && submitModel.CategoryName != " ")
            {
                result = result.Where(x => x.Category.Name == submitModel.CategoryName);
            }

            var endResult = result.Select(x => new ListPageTicketViewModel
            {
                Author = x.Author.UserName,
                Category = x.Category.Name,
                PriorityName = x.Priority,
                Title = x.Title,
                Id = x.Id
            });

            return View(endResult);
        }


        public JsonResult GetTAllTickets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.GetAllTickets().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            var viewModel = this.Data.Tickets.All().Where(x => x.Id == id)
                .Select(x => new TicketDetailsViewModel
                {
                    AuthorName = x.Author.UserName,
                    Category = x.Category.Name,
                    Comments = x.Comments.Select(c => new CommentViewModel { AuthorName = c.Author.UserName, Content = c.Content }),
                    Description = x.Description,
                    ImageUrl = x.ScreenshotUrl,
                    Priority = x.Priority,
                    Title = x.Title,
                    Id = x.Id
                }).FirstOrDefault();

            return View(viewModel);
        }

        public JsonResult GetTicketCategories()
        {
            var result = this.Data.Categories
                .All()
                .Select(x => new
                {
                    CategoryName = x.Name
                });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTicketPriorities()
        {
            var result = new[]{
            
            new {PriorityName = Priority.Low.ToString(), Id = 0},
            new {PriorityName = Priority.Medium.ToString(), Id = 1},
            new {PriorityName = Priority.High.ToString(), Id = 2}
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var user = this.Data.Users.All().FirstOrDefault(u => u.Id == userId);

                this.Data.Comments.Add(new Comment()
                {
                    Author = user,
                    AuthorID = user.Id,
                    Content = commentModel.Content,
                    TicketId = commentModel.TicketId,
                });

                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorName = username, Content = commentModel.Content };
                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }
    }
}