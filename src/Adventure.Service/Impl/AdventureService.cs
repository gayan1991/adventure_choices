using Adventure.Domain.Interface.Repository;
using Adventure.Domain.Util;
using Adventure.Domain.Util.Exceptions;
using Adventure.Service.Interface;
using Adventure.Service.Models.Request;
using Adventure.Service.Models.Response;

namespace Adventure.Service.Impl
{
    public class AdventureService : IAdventureService
    {
        private readonly IAdventureRepository _adventureRepository;

        public AdventureService(IAdventureRepository adventureRepository)
        {
            _adventureRepository = adventureRepository;
        }

        public async Task<List<AdventureDto>> GetAllAsync()
        {
            var adventureList = await _adventureRepository.GetAllAsync();

            if (!adventureList.Any())
            {
                throw new NotFoundException("No Adventures are Available");
            }

            return adventureList.Select(x => x.ToDto()).ToList();
        }

        public async Task<AdventureDto> GetSelectionTreeAsync(Guid adventureId)
        {
            var adventure = await _adventureRepository.GetAdventureById(adventureId);

            if (adventure is null)
            {
                throw new NotFoundException(adventureId, "Adventure Selection");
            }

            return adventure.ToDetailDto();
        }

        public async Task<AdventureSelectionDto> GetSelectionAsync(Guid adventureId, byte code)
        {
            if (code <= 0)
            {
                throw new ArgumentException($"{nameof(code)} : {code} is invalid.");
            }

            var selection = await _adventureRepository.GetAdventureStep(adventureId, code);

            if (selection is null)
            {
                throw new NotFoundException(adventureId, "Adventure Selection");
            }

            return selection.ToSelectionDto();
        }

        public async Task<SuccessDto> AddSelectionAsync(Guid adventureId, byte parentCode, SelectionDto selection)
        {
            var adventure = await _adventureRepository.GetAdventureById(adventureId);

            if (adventure is null)
            {
                throw new NotFoundException(adventureId, "Adventure Selection");
            }

            if (adventure.IsDeleted)
            {
                throw new InvalidOperationException("This adventure is deleted");
            }

            if (adventure.IsSelectionAvailable(parentCode))
            {
                throw new NotFoundException(adventureId, $"Adventure Selection Step {parentCode} Not Found");
            }

            adventure.AddChoice(adventure.NextSelectionCode, selection.Text, selection.Action, parentCode);

            _adventureRepository.Update(adventure);
            await _adventureRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordCreated);
        }

        public async Task<SuccessDto> CreateNewAdventureAsync(NewAdventureDto adventureDto)
        {
            var adventure = new Domain.DomainModels.AdventureAggregate.Adventure(adventureDto.Name);

            adventure.AddChoice(0, adventureDto.Selection.Action, adventureDto.Selection.Text);
            AddChoicesToAdventure(adventure, 0, adventureDto.Selection.NextSelections);

            _adventureRepository.Add(adventure);
            await _adventureRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordCreated);
        }

        public async Task<SuccessDto> DeleteAdventureAsync(Guid adventureId)
        {
            var adventure = await _adventureRepository.GetAdventureById(adventureId);

            if (adventure is null)
            {
                throw new NotFoundException(adventureId, "Adventure Selection");
            }

            if (adventure.IsDeleted)
            {
                throw new InvalidOperationException("This adventure has already been deleted");
            }

            adventure.MarkAsDeleted();

            _adventureRepository.Update(adventure);
            await _adventureRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordDeleted);
        }
        
        public async Task<SuccessDto> DeleteSelectionAsync(Guid adventureId, byte code)
        {
            var adventure = await _adventureRepository.GetAdventureById(adventureId);

            if (adventure is null)
            {
                throw new NotFoundException(adventureId, "Adventure Selection");
            }

            if (adventure.IsDeleted)
            {
                throw new InvalidOperationException("This adventure has already been deleted");
            }

            if (adventure[code].IsDeleted)
            {
                throw new InvalidOperationException("This selection has already been deleted");
            }

            adventure[code].MarkAsDeleted();

            _adventureRepository.Update(adventure);
            await _adventureRepository.SaveChangesAsync();

            return new SuccessDto(Constants.RecordDeleted);
        }

        #region Private

        private void AddChoicesToAdventure(Domain.DomainModels.AdventureAggregate.Adventure adventure, byte parentCode, List<SelectionDto>? selections)
        {
            if (selections == null) return;

            foreach (var selection in selections)
            {
                var nextCode = adventure.NextSelectionCode;
                adventure.AddChoice(nextCode, selection.Text, selection.Action, parentCode);

                if (selection.NextSelections.Any())
                {
                    AddChoicesToAdventure(adventure, nextCode, selection.NextSelections);
                }
            }
        }

        #endregion
    }
}
