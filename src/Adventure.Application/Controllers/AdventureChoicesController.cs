using Adventure.Domain.Util.Exceptions;
using Adventure.Service.Interface;
using Adventure.Service.Models.Request;
using Adventure.Service.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Adventure.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureChoicesController : ControllerBase
    {
        private readonly IAdventureService _adventureService;

        public AdventureChoicesController(IAdventureService adventureService)
        {
            _adventureService = adventureService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(AdventureDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _adventureService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(AdventureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _adventureService.GetSelectionTreeAsync(id));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NewAdventureDto adventure)
        {
            try
            {
                return Ok(await _adventureService.CreateNewAdventureAsync(adventure));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("{id:guid}/{parentCode}")]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSelection(Guid id, byte parentCode, [FromBody] SelectionDto adventure)
        {
            try
            {
                return Ok(await _adventureService.AddSelectionAsync(id, parentCode, adventure));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _adventureService.DeleteAdventureAsync(id));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpDelete("{id:guid}/{code}")]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, byte code)
        {
            try
            {
                return Ok(await _adventureService.DeleteSelectionAsync(id, code));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        #region Private

        private dynamic HandleException(Exception ex)
        {
            switch (ex)
            {
                case NotFoundException:
                    return StatusCode(StatusCodes.Status404NotFound, ex.Message);
                case InvalidOperationException:
                    return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        #endregion
    }
}
