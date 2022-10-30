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
    public class UserAdventureSelectionsController : ControllerBase
    {
        private readonly IUserAdventureService _userAdventureService;

        public UserAdventureSelectionsController(IUserAdventureService userAdventureService)
        {
            _userAdventureService = userAdventureService;
        }
        
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(UserAdventureDto[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAdventureByUser(Guid id)
        {
            try
            {
                return Ok(await _userAdventureService.GetAllAdventuresPlayedByUser(id));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet("{id:guid}/{gameId:guid}")]
        [ProducesResponseType(typeof(UserAdventureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid id, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.GetAdventureInfoByUser(id, gameId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpGet("{id:guid}/{gameId:guid}/detail")]
        [ProducesResponseType(typeof(UserAdventureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetail(Guid id, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.GetAdventureDetailInfoByUser(id, gameId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NewUserAdventureDto obj)
        {
            try
            {
                return Ok(await _userAdventureService.CreateNewAdventureForUserAsync(obj));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpPut("{id:guid}/{gameId:guid}")]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, Guid gameId, [FromBody] byte code)
        {
            try
            {
                return Ok(await _userAdventureService.UpdateAdventureSelectionForUserAsync(id, gameId, code));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpDelete("{id:guid}/{gameId:guid}")]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid id, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.DeleteUsersAdventureGame(id, gameId));
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
