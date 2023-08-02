using Drafter.Data;
using Drafter.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<PlayerDto>>> Get()
        {

            try
            {
                var result = await _repository.GetAllPlayersDashboard();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
        }

        [HttpGet("myteamdashboard")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetMyTeamDashboard()
        {

            try
            {
                var result = await _repository.GetMyPlayersDashboard(this.User.Identity!.Name!);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get team on dashboard: {ex}");
                return BadRequest("Failed to get team on dashboard");
            }
        }

        [HttpGet("picksdashboard")] //NOTBEING USED
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Pick>>> GetPicksDashboard()
        {
            try
            {
                var result = await _repository.GetPicksForDashboard();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get picks for dashboard: {ex}");
                return BadRequest("Failed to get picks for dashboard");
            }
        }

        [HttpGet("nextpickdashboard")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Pick>> GetNextPickDashboard()
        {
            try
            {
                var result = await _repository.GetNextPickDashboard();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get next pick for dashboard: {ex}");
                return BadRequest("Failed to get next pick for dashboard");
            }
        }

        [HttpGet("timelinedashboard")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Pick>> GetTimelineDashboard()
        {
            _logger.LogInformation("Get timeline endpoint was hit");
            try
            {
                var result = await _repository.GetTimelineDashboard();
                _logger.LogInformation("Get timeline completed");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get timeline for dashboard: {ex}");
                return BadRequest("Failed to get timeline for dashboard");
            }
        }
        [HttpPost("draftplayerdashboard")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PlayerDto>> DraftPlayerDashboard([FromBody] PlayerDto playerDto)
        {
            _logger.LogInformation("draft player endpoint was hit");
            try
            {
                var result = await _repository.DraftPlayerDashboard(playerDto, this.User.Identity!.Name!);
                _logger.LogInformation("post draft player completed");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to draft player for dashboard: {ex}");
                return BadRequest("Failed to draft player for dashboard");
            }
        }
    }
}
