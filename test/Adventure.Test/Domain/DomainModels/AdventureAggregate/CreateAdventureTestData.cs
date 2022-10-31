using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Test.Builders.AdventureAggregate;
using Xunit;

namespace Adventure.Test.Domain.DomainModels.AdventureAggregate
{
    internal class CreateAdventureTestData : TheoryData<Adventure.Domain.DomainModels.AdventureAggregate.Adventure>
    {
        internal CreateAdventureTestData()
        {
            AdventureRecordOnly();
        }

        private void AdventureRecordOnly()
        {
            var adventure = new AdventureBuilder()
                .WithName("XYZ");

            Add(adventure);
        }
    }
}
