using System.Text;
using AnanonymousServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AnanonymousServer.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            var allText = System.IO.File.ReadAllText(@"Conf\persinfo.json", Encoding.UTF8);

            var jsonObject = JsonConvert.DeserializeObject(allText);
            return Json(jsonObject);
        }
    }
}