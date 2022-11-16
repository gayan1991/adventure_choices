using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureAggregate;

namespace Adventure.Domain.Interface.Repository
{
    public interface IAdventureRepository : IRepository<DomainModels.AdventureAggregate.Adventure>
    {
        Task<DomainModels.AdventureAggregate.Adventure?> GetAdventureById(Guid adventureId, bool includeDeleted = false);
        Task<AdventureSelection?> GetAdventureStep(Guid adventureId, byte code);
    }
}
