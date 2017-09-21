using System;
using System.IO;
using AnanonymousServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnanonymousServer.Controllers
{
    [Route("api/")]
    public class ValuesController : Controller
    {
        [HttpPost]
        public string Post([FromBody] Info data)
        {
            var path = data.Path.Replace('.', '\\') + data.Name + ".b";
            try
            {
                using (var sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                return "null";
            }
        }

        [HttpPut]
        public void Put([FromBody] Info data)
        {
            var path = data.Path.Replace('.', '\\');
            Directory.CreateDirectory(path);
            try
            {
                using (var sw = new StreamWriter(path + data.Name + ".b", false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(data.Data);
                }

            }
            catch (FileNotFoundException)
            {
            }
        }
    }
}
