using Adventure.Test.Builders;

namespace Adventure.Test.Domain.DomainModels.AdventureAggregate;

public class TestAdventure : TestBase
{
    [Theory]
    [ClassData(typeof(CreateAdventureTestData))]
    public async Task CreateUser_TestAsync(Adventure.Domain.DomainModels.AdventureAggregate.Adventure user)
    {
        #region Arrange

        var repo = RepoBuilder.AdventureRepository;

        #endregion

        #region Act

        repo.Add(user);
        await repo.SaveChangesAsync();

        #endregion

        #region Assert

        //var getUser = await repo.GetByIdAsync(user.Id);
        //ValidateObjects(user, getUser);
        //ValidateObjects(user.DriverDetail, getUser.DriverDetail);

        //foreach (var detail in user.Details)
        //{
        //    var getDetail = getUser.Details.FirstOrDefault(d => d.Id == detail.Id);
        //    ValidateObjects(detail, getDetail);
        //}

        #endregion
    }
}