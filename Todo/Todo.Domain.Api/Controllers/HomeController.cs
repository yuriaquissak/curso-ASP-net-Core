using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Domain.Api.Models;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
using Todo.Domain.Queries;
using Todo.Api.Controllers;
using Microsoft.Extensions.Configuration;
using todo.domain.api;
using Todo.Domain.Handlers.HealthCheck;

namespace Todo.Domain.Api.Controllers
{
    public class HomeController : Controller
    {
        TodoItem Test;
        string str;
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public IActionResult Index([FromServices] ITodoRepository repository, [FromServices] HealthHandler handler)
        {
            

            str = Configuration.GetConnectionString("connectionString");
            Test = repository.GetTest();

            ViewBag.Latencia = handler.Watch(repository).ElapsedMilliseconds;
            ViewBag.Server = handler.Handle(str).Server;
            ViewBag.DataBase = handler.Handle(str).Database;
            if (Test != null)
            {
                ViewBag.Teste = "Servidor Operacional";
            }
            else 
            {
                ViewBag.Teste = "Servidor Fora do Ar";
            }
            return View("/wwwroot/index.cshtml");
        }
    }
}
