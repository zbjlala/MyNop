using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyNop.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public string Index()
        {
            return "index";
        }
        [HttpGet]
        public string Test()
        {
            return "1111";
        }
    }
}