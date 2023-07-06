using AutoMapper;
using Drafter.Data;
using Drafter.Data.Entities;
using Drafter.Services;
using Drafter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Drafter.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IDrafterRepository _repository;
        private readonly IMapper _mapper;

        public AppController(IMailService mailService, IDrafterRepository repository, IMapper mapper)
        {
            _mailService = mailService;
            _repository = repository;
            _mapper = mapper;
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

        [Authorize]
        [HttpGet("Players")]
        public IActionResult Players()
        {
            var results = _repository.GetAllPlayers();
            return View(results);
        }

        [Authorize]
        [HttpPost("Players")]
        public IActionResult Players(Player model)
        {
            _repository.DraftPlayer(model.Id, this.User.Identity.Name).Wait(); // WAIT FIXES ISSUES WITH THREADSAFE ISSUES. https://stackoverflow.com/questions/48767910/entity-framework-core-a-second-operation-started-on-this-context-before-a-previ
            var results = _repository.GetAllPlayers();
            return View(results);
        }
        [Authorize]
        [HttpGet("MyTeams")]
        public IActionResult MyTeams()
        {
            var query = _repository.GetMyTeam(this.User.Identity.Name);
            var results = query.Result;
            return View(results);
        }
        [Authorize]
        [HttpPost("MyTeams")]
        public IActionResult MyTeams(Player model)
        {
            _repository.UndraftPlayer(model.Id).Wait();
            var query = _repository.GetMyTeam(this.User.Identity.Name);
            var results = query.Result;
            return View(results);
        }

        [HttpGet("Timeline")]
        public IActionResult Timeline()
        {
            var query = _repository.GetTimeline();
            var results = query.Result;
            return View(results);
        }

        [HttpGet("Picks")]
        public IActionResult Picks()
        {
            var results = _repository.GetPicks();
            return View(results);
        }

        [HttpGet("NextPick")]
        public IActionResult NextPick()
        {
            var results = _repository.GetNextPick();
            return View(results);
        }

        [Authorize]
        [HttpPost("CreateTeam")]
        public IActionResult CreateTeam(FantasyTeamViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newTeam = _mapper.Map<FantasyTeamViewModel, FantasyTeam>(model);
                    var username = this.User.Identity.Name;

                    _repository.CreateFantasyTeam(newTeam, username).Wait(); // I WANT TO REMOVE THIS SO BAD
                    if (_repository.SaveAll())
                    {
                        return RedirectToAction("MyTeams", "App"); // THIS SHOULD PROVIDE CREATED FOR API, BUT I WANT TO GO HERE
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed create new team: {ex}");
            }
            return BadRequest("Failed to save new team");
        }

        [Authorize]
        [HttpGet("CreateTeam")]
        public IActionResult CreateTeam()
        {
            return View();
        }

        [Authorize]
        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize]
        [HttpGet("DraftSettings")]
        public IActionResult DraftSettings()
        {
            var results = _repository.GetDraftSettings();
            return View(results);
        }

        [Authorize]
        [HttpPost("DraftSettings")]
        public IActionResult GenerateDraft()
        {
            _repository.GenerateDraft();
            return RedirectToAction("Picks", "App");
        }

        [Authorize]
        [HttpGet("CreateDraft")]
        public IActionResult CreateDraft()
        {
            return View();
        }

        [Authorize]
        [HttpPost("CreateDraft")]
        public IActionResult CreateDraft(DraftViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newDraft = _mapper.Map<DraftViewModel, Draft>(model);
                    var username = this.User.Identity.Name;

                    _repository.CreateDraft(newDraft, username).Wait(); // I WANT TO REMOVE THIS SO BAD
                    if (_repository.SaveAll())
                    {
                        return RedirectToAction("MyTeams", "App"); // THIS SHOULD PROVIDE CREATED FOR API, BUT I WANT TO GO HERE
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed create new team: {ex}");
            }
            return BadRequest("Failed to save new team");
        }
    }
}
