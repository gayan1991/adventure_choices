using Adventure.Application.Interceptors;
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
        [RequestResponseLog]
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

        [HttpGet("{userId:guid}/{gameId:guid}")]
        [RequestResponseLog]
        [ProducesResponseType(typeof(UserAdventureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(Guid userId, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.GetAdventureInfoByUser(userId, gameId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpGet("{userId:guid}/{gameId:guid}/detail")]
        [RequestResponseLog]
        [ProducesResponseType(typeof(UserAdventureDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDetail(Guid userId, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.GetAdventureDetailInfoByUser(userId, gameId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpPost]
        [RequestResponseLog]
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
        
        [HttpPut("{userId:guid}/{gameId:guid}")]
        [RequestResponseLog]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid userId, Guid gameId, [FromBody] byte code)
        {
            try
            {
                return Ok(await _userAdventureService.UpdateAdventureSelectionForUserAsync(userId, gameId, code));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
        
        [HttpDelete("{userId:guid}/{gameId:guid}")]
        [RequestResponseLog]
        [ProducesResponseType(typeof(SuccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(Guid userId, Guid gameId)
        {
            try
            {
                return Ok(await _userAdventureService.DeleteUsersAdventureGame(userId, gameId));
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
