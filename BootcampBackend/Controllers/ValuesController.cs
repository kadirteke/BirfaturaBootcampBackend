using BootcampBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BootcampBackend.Controllers
{
	public class ValuesController : ApiController
	{
		// GET api/<controller>l
		[Authorize]
		public IEnumerable<Deneme> Get()
		{
			BootcampEntities ent = new BootcampEntities();
			return ent.Denemes.ToList();
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>		
		public void Post([FromBody] Deneme value)
		{
			BootcampEntities ent = new BootcampEntities();
			ent.Denemes.Add(value);
			ent.SaveChanges();
			string a = "";
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}