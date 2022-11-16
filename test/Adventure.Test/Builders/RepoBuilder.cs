using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure.Repository;
using Adventure.Test.Domain.DomainModels.AdventureAggregate;
using Adventure.Test.Fixtures;

namespace Adventure.Test.Builders
{
    internal static class RepoBuilder
    {
        internal static IAdventureRepository AdventureRepository =>
            new AdventureRepository(TestDbManager.CreateInstance());

        internal static IUserAdventureSelectionRepository UserAdventureSelectionRepository =>
            new UserAdventureSelectionRepository(TestDbManager.CreateInstance());
    }
}
