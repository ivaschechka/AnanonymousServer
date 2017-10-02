using System.IO;
using AnanonymousServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnanonymousServer.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello into API";
        }



        [HttpPost]
        public JsonResult Post([FromBody] Info data)
        {
            var path = FileWorker.Format(data);
            return Json(FileWorker.Read(path));
        }

        [HttpPut]
        public JsonResult Put([FromBody] Info data)
        {
            var path = FileWorker.Format(data);
            return Json(FileWorker.Write(path, data.Data));
        }
    }

    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        [HttpPost]
        public JsonResult Post([FromBody] Info data)
        {
            var path = FileWorker.Format(data);
            return Json(FileWorker.Check(path, data.IdRow));
        }
    }
}
