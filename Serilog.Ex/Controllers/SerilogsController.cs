using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Serilog.Events;
using Serilog.Ex.Models;
using Serilog.Ex.Services;

namespace Serilog.Ex.Controllers
{
    public class SerilogsController : Controller
    {

		private readonly SerilogsServices _DBService;

		public SerilogsController(SerilogsServices dBService)
		{
			_DBService = dBService;
		}

		public IActionResult Index()
        {
			var filter = Builders<Serilogs>.Filter.Eq("Status", true);
			var projection = Builders<Serilogs>.Projection
	  .Include("MessageTemplate")
	  .Exclude("_id");

			var Data = _DBService._CollectionName.Find(_=>true).Project(projection).ToList();
			if (Data != null)
			{
				return View(Data);
			}else
			{
				ViewBag.x = "null";
				return View();
			}
			
           
        }
    }
}
