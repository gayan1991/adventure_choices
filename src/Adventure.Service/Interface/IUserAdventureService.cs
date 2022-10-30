using Adventure.Service.Models.Request;
using Adventure.Service.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Interface
{
    public interface IUserAdventureService
    {
        Task<UserAdventureDto> GetAdventureInfoByUser(Guid userId, Guid gameId);
        Task<UserAdventureDto> GetAdventureDetailInfoByUser(Guid userId, Guid gameId);
        Task<List<UserAdventureDto>> GetAllAdventuresPlayedByUser(Guid userId);
        Task<SuccessDto> DeleteUsersAdventureGame(Guid userId, Guid gameId);
        Task<SuccessDto> CreateNewAdventureForUserAsync(NewUserAdventureDto userSelectedAdventure);
        Task<SuccessDto> UpdateAdventureSelectionForUserAsync(Guid userId, Guid gameId, byte code);
    }
}
