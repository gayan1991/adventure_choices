using Adventure.Service.Models.Request;
using Adventure.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Interface
{
    public interface IAdventureService
    {
        Task<List<AdventureDto>> GetAllAsync();
        Task<AdventureDto> GetSelectionTreeAsync(Guid adventureId);
        Task<AdventureSelectionDto> GetSelectionAsync(Guid adventureId, byte code);
        Task<SuccessDto> AddSelectionAsync(Guid adventureId, byte parentCode, SelectionDto selection);
        Task<SuccessDto> DeleteSelectionAsync(Guid adventureId, byte code);
        Task<SuccessDto> CreateNewAdventureAsync(NewAdventureDto adventure);
        Task<SuccessDto> DeleteAdventureAsync(Guid gameId);
    }
}
