using AnanonymousServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnanonymousServer.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        [HttpPost]
        public JsonResult Post([FromBody] Info data)
        {
            var path = FileWorker.Format(data);
            return Json(FileWorker.Check(path, data.IdRow));
        }

        [HttpPut]
        public JsonResult Put([FromBody] Info data)
        {

            return Json("It's test");

        }
    }
}