using Drafter.Data;
using Drafter.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PlayersViewController : Controller
    {
        private readonly IDrafterRepository _repository;
        private readonly ILogger<PlayersViewController> _logger;

        public PlayersViewController(IDrafterRepository repository, ILogger<PlayersViewController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<PlayerDto>> Get()
        {

            try
            {
                return Ok(_repository.GetAllPlayersDashboard());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }
    }
}
