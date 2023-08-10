using Drafter.Data;
using Drafter.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Drafter.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresenterController : Controller
    {
        private readonly IDrafterRepository _repository;
        private readonly ILogger<PlayersViewController> _logger;

        public PresenterController(IDrafterRepository repository, ILogger<PlayersViewController> logger)
        {
            _repository = repository;
            _logger = logger;
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

        [HttpGet("pickspresenter")] //NOTBEING USED
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Pick>>> GetPicksPresenter()
        {
            try
            {
                var result = await _repository.GetPicksForPresenter();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get picks for presenter: {ex}");
                return BadRequest("Failed to get picks for presenter");
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

        [HttpGet("lastpicktime")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<DateTime>> GetLastPickTime()
        {
            try
            {
                var result = await _repository.GetLastPickTime();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get last pick time for dashboard: {ex}");
                return BadRequest("Failed to get last pick time for dashboard");
            }
        }
    }
}
