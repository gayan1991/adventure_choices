using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureModels;

namespace Adventure.Domain.Interface.Repository
{
    public interface IAdventureRepository : IRepository<DomainModels.AdventureModels.Adventure>
    {
        Task<DomainModels.AdventureModels.Adventure?> GetAdventureById(Guid adventureId);
        Task<AdventureSelection?> GetAdventureStep(Guid adventureId, byte code);
        void Add(DomainModels.AdventureModels.Adventure adventure);
        void Update(Domain.DomainModels.AdventureModels.Adventure adventure);
    }
}
