using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.UserSelectionAggregate;

namespace Adventure.Domain.Interface.Repository
{
    public interface IUserAdventureSelectionRepository : IRepository<UserAdventureSelection>
    {
        Task<List<UserAdventureSelection>> GetAdventureListByUser(Guid userId);
        Task<UserAdventureSelection?> GetAdventure(Guid userId, Guid adventureId);
        Task<UserAdventureSelection?> GetAdventureDetails(Guid userId, Guid adventureId);
    }
}
