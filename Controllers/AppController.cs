using Drafter.Data;
using Drafter.Data.Entities;
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
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage("kevy@kevy.c", model.Subject, $"from: {model.Name} - {model.Email}, Message : {model.Message}");
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

        [HttpGet("Players")]
        public IActionResult Players()
        {
            var results = _repository.GetAllPlayers();
            return View(results);
        }

        [HttpPost("Players")]
        public IActionResult Players(Player model)
        {
            int teamId = 2;
            _repository.DraftPlayer(model.Id, teamId);
            var results = _repository.GetAllPlayers();
            return View(results);
        }

        [HttpGet("MyTeams")]
        public IActionResult MyTeams()
        {
            var results = _repository.GetMyTeams(2);
            return View(results);
        }

        [HttpPost("MyTeams")]
        public IActionResult MyTeams(Player model)
        {
            _repository.UndraftPlayer(model.Id);
            var results = _repository.GetMyTeams(2);
            return View(results);
        }

        [HttpGet("Timeline")]
        public IActionResult Timeline()
        {
            var results = _repository.GetTimeline();
            return View(results);
        }


        //DEBUG METHOD, REMOVE LATER
        [HttpGet("Create")]
        public IActionResult CreateKevy()
        {
            _repository.CreateKevy();
            return RedirectToPage("Players");
        }
    }
}
