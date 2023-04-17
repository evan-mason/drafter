using Drafter.Data;
using Drafter.Services;
using Drafter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDrafterRepository _repository;

        public AppController(IMailService mailService, IDrafterRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact() 
        {
            return View(); 
        }

        [HttpPost("contact")]
        public IActionResult Contact (ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("kevy@kevy.c", model.Subject, $"from: {model.Name} - {model.Email}, Message : {model.Message}" );
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }

        public IActionResult Players()
        {
            var results = _repository.GetAllPlayers();
            return View(results);
        }
    }
}
