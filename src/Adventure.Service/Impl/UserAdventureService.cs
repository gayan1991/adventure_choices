using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Domain.DomainModels.UserSelectionAggregate;
using Adventure.Domain.Interface.Repository;
using Adventure.Domain.Util;
using Adventure.Domain.Util.Exceptions;
using Adventure.Service.Interface;
using Adventure.Service.Models.Request;
using Adventure.Service.Models.Response;

namespace Adventure.Service.Impl
{
    public class UserAdventureService : IUserAdventureService
    {
        private readonly IAdventureRepository _adventureRepository;
        private readonly IUserAdventureSelectionRepository _userAdventureSelectionRepository;

        public UserAdventureService(IAdventureRepository adventureRepository, IUserAdventureSelectionRepository userAdventureSelectionRepository)
        {
            _adventureRepository = adventureRepository;
            _userAdventureSelectionRepository = userAdventureSelectionRepository;
        }

        public async Task<SuccessDto> CreateNewAdventureForUserAsync(NewUserAdventureDto userSelectedAdventure)
        {
            if (await _userAdventureSelectionRepository.AnyAsync(x => x.UserId == userSelectedAdventure.UserId && x.AdventureId == userSelectedAdventure.GameId && !x.IsCompleted))
            {
                throw new InvalidOperationException("User has not completed previous selection of this game");
            }

            var obj = new UserAdventureSelection(userSelectedAdventure.UserId, userSelectedAdventure.GameId);

            foreach (var selection in userSelectedAdventure.UserSelections)
            {
                obj.Update(selection.Code);
            }

            _userAdventureSelectionRepository.Update(obj);
            await _userAdventureSelectionRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordCreated);
        }

        public async Task<SuccessDto> UpdateAdventureSelectionForUserAsync(Guid userId, Guid gameId, byte code)
        {
            var obj = await _userAdventureSelectionRepository.GetAdventure(userId, gameId);

            if (obj is null)
            {
                throw new NotFoundException(gameId, "Selected Adventure is not played by User");
            }

            if (obj.IsDeleted)
            {
                throw new InvalidOperationException("This adventure is removed from this user");
            }

            if (obj.IsCompleted)
            {
                throw new InvalidOperationException("User has finished this game");
            }

            obj.Update(code);

            _userAdventureSelectionRepository.Update(obj);
            await _userAdventureSelectionRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordUpdated);
        }

        public async Task<SuccessDto> DeleteUsersAdventureGame(Guid userId, Guid gameId)
        {
            var obj = await _userAdventureSelectionRepository.GetAdventure(userId, gameId);

            if (obj is null)
            {
                throw new NotFoundException(gameId, "Adventure Selection is not available");
            }

            if (obj.IsDeleted)
            {
                throw new InvalidOperationException("This adventure is removed from this user");
            }

            obj.Delete();

            _userAdventureSelectionRepository.Update(obj);
            await _userAdventureSelectionRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordDeleted);
        }

        public async Task<UserAdventureDto> GetAdventureInfoByUser(Guid userId, Guid gameId)
        {
            var obj = await _userAdventureSelectionRepository.GetAdventure(userId, gameId);

            if (obj is null)
            {
                throw new NotFoundException(gameId, "Selected Adventure is not played by User");
            }

            var adventure = await _adventureRepository.GetAdventureById(gameId);

            if (adventure is null)
            {
                throw new NotFoundException(gameId, "Adventure Selection is not available");
            }

            return obj.ToDto(adventure.Name);
        }

        public async Task<UserAdventureDto> GetAdventureDetailInfoByUser(Guid userId, Guid gameId)
        {
            var obj = await _userAdventureSelectionRepository.GetAdventureDetails(userId, gameId);

            if (obj is null)
            {
                throw new NotFoundException(gameId, "Selected Adventure is not played by User");
            }

            var adventure = await _adventureRepository.GetAdventureById(gameId);

            if (adventure is null)
            {
                throw new NotFoundException(gameId, "Adventure Selection is not available");
            }

            return obj.ToDetailDto(adventure);
        }

        public async Task<List<UserAdventureDto>> GetAllAdventuresPlayedByUser(Guid userId)
        {
            var listPlayedByUser = await _userAdventureSelectionRepository.GetAdventureListByUser(userId);

            if (listPlayedByUser.Any() || listPlayedByUser.Count == 0)
            {
                throw new NotFoundException("User has not played any games yet!");
            }

            var rtnList = new List<UserAdventureDto>();
            foreach (var selectedAdventure in listPlayedByUser)
            {
                var adventure = await _adventureRepository.GetAdventureById(selectedAdventure.AdventureId);

                if (adventure is null)
                {
                    throw new NotFoundException(selectedAdventure.AdventureId, "Adventure Selection is not available");
                }

                rtnList.Add(selectedAdventure.ToDto(adventure.Name));
            }

            return rtnList;
        }
    }
}
