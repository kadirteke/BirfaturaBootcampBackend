using BootcampBackend.App_Start;
using BootcampBackend.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BootcampBackend.Controllers
{
	public class TodoListController : ApiController
	{
		private ApplicationUserManager _userManager;

		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		[Authorize]
		[HttpGet]
		public List<tblTodoList> GetAllTodos()
		{
			BootcampEntities ent = new BootcampEntities();
			return ent.tblTodoLists.ToList();
		}

		[Authorize]
		[HttpGet]
		public List<tblTodoList> GetMyTodos()
		{
			ApplicationUser user = UserManager.Users.Where(q => q.UserName == RequestContext.Principal.Identity.Name).FirstOrDefault();
			BootcampEntities ent = new BootcampEntities();
			return ent.tblTodoLists.Where(q => q.KullaniciId == user.Id).ToList();
		}

		[Authorize]
		[HttpPost]
		public string AddTodo([FromBody] tblTodoList todo)
		{
			ApplicationUser user = UserManager.Users.Where(q => q.UserName == RequestContext.Principal.Identity.Name).FirstOrDefault();
			todo.KullaniciId = user.Id;
			BootcampEntities ent = new BootcampEntities();
			ent.tblTodoLists.Add(todo);
			ent.SaveChanges();
			return "Ok";
		}
	}
}