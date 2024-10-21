﻿using Microsoft.AspNetCore.Mvc;

namespace CalculoDeSeguroDeVeiculos.Api.Controllers
{
    public class FallBackController : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "index.html"), "text/HTML");
        }
    }
}
