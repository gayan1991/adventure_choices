using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Domain.Util.Exceptions;
using Adventure.Test.Builders;
using Adventure.Test.Builders.AdventureAggregate;

namespace Adventure.Test.Domain.DomainModels.AdventureAggregate;

public class TestAdventure : TestBase
{
    #region Exception

    [Fact]
    public void CreateAdventure_NoDetail_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;
        Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
            .WithName("XYZ");

        #endregion

        #region Act

        try
        {
            _ = adventure.SelectionTree;
        }
        catch (NotFoundException nfe)
        {
            exceptionMsg = nfe.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Requested code (0) is not found", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_WrongStarterCode_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithText("Hello World");

        #endregion

        #region Act

        try
        {
            Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithAdventureSelection(selection);
        }
        catch (ArgumentException ae)
        {
            exceptionMsg = ae.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Code (1) is invalid, make sure code 0 is registered", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_WrongParentCode_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(0)
            .WithText("Pick a colour!");

        var selection2 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(0)
            .WithAction("Blue")
            .WithText("Blue");

        var selection3 = new AdventureSelectionBuilder()
            .WithCode(2)
            .WithParentCode(2)
            .WithAction("Yellow")
            .WithText("Yellow");

        #endregion

        #region Act

        try
        {
            Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3);
        }
        catch (ArgumentException ae)
        {
            exceptionMsg = ae.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Invalid parent code (2) is invalid, make sure parent is registered before adding the child", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_ParentCodeEqualChildCode_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(0)
            .WithText("Pick a colour!");

        var selection2 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(0)
            .WithAction("Blue")
            .WithText("Blue");

        var selection3 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(1)
            .WithAction("Yellow")
            .WithText("Yellow");

        #endregion

        #region Act

        try
        {
            Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3);
        }
        catch (ArgumentException ae)
        {
            exceptionMsg = ae.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Child code must be higher than parent code", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_ParentCodeHigherThanChildCode_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(0)
            .WithText("Pick a colour!");

        var selection2 = new AdventureSelectionBuilder()
            .WithCode(2)
            .WithParentCode(0)
            .WithAction("Blue")
            .WithText("Blue");

        var selection3 = new AdventureSelectionBuilder()
            .WithCode(3)
            .WithParentCode(2)
            .WithAction("Yellow")
            .WithText("Yellow");

        var selection4 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(2)
            .WithAction("Yellow")
            .WithText("Yellow");

        #endregion

        #region Act

        try
        {
            Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3)
                .WithAdventureSelection(selection4);
        }
        catch (ArgumentException ae)
        {
            exceptionMsg = ae.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Child code must be higher than parent code", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_DuplicateCode_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(0)
            .WithText("Pick a colour!");

        var selection2 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(0)
            .WithAction("Blue")
            .WithText("Blue");

        var selection3 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(0)
            .WithAction("Yellow")
            .WithText("Yellow");

        #endregion

        #region Act

        try
        {
            Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3);
        }
        catch (ArgumentException ae)
        {
            exceptionMsg = ae.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Duplicate code (1)", exceptionMsg);

        #endregion
    }

    [Fact]
    public void CreateAdventure_WrongCodeIndexSearch_Test_Unsuccessful()
    {
        #region Arrange

        var exceptionMsg = string.Empty;

        var selection = new AdventureSelectionBuilder()
            .WithCode(0)
            .WithText("Pick a colour!");

        var selection2 = new AdventureSelectionBuilder()
            .WithCode(1)
            .WithParentCode(0)
            .WithAction("Blue")
            .WithText("Blue");

        var selection3 = new AdventureSelectionBuilder()
            .WithCode(2)
            .WithParentCode(0)
            .WithAction("Yellow")
            .WithText("Yellow");

        Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure = new AdventureBuilder()
            .WithName("XYZ")
            .WithAdventureSelection(selection)
            .WithAdventureSelection(selection2)
            .WithAdventureSelection(selection3);

        #endregion

        #region Act

        try
        {
            _ = adventure[3];
        }
        catch (NotFoundException nfe)
        {
            exceptionMsg = nfe.Message;
        }

        #endregion

        #region Assert

        Assert.Equal("Requested code (3) is not found", exceptionMsg);

        #endregion
    }

    #endregion

    #region Instance

    [Theory]
    [ClassData(typeof(CreateAdventureTestData))]
    public void CreateAdventure_Test_Successful(Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure)
    {
        #region Arrange;

        var system = "System";
        var cnt = adventure.Choices.Count;
        var max = adventure.Choices.Max(x => x.Code);
        var nxtMax = max;
        nxtMax++;
        #endregion

        #region Assert

        Assert.True(adventure.IsSelectionAvailable(max));
        Assert.False(adventure.IsSelectionAvailable(nxtMax));
        Assert.Equal(nxtMax, adventure.NextSelectionCode);
        Assert.Equal(system, adventure.CreatedBy);
        Assert.Equal(system, adventure.UpdatedBy);

        #endregion
    }

    [Theory]
    [ClassData(typeof(CreateAdventureTreeTestData))]
    public void CreateAdventure_TestSelectionTree_Successful(Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure, Tuple<AdventureSelection, Array?> obj)
    {
        #region Assert

        Assert.Equal(adventure.SelectionTree.Code, obj.Item1.Code);
        Assert.Equal(adventure.SelectionTree.ParentCode, obj.Item1.ParentCode);
        Assert.Equal(adventure.SelectionTree.Action, obj.Item1.Action);
        Assert.Equal(adventure.SelectionTree.Text, obj.Item1.Text);

        if (adventure.SelectionTree.NextSelection.Any())
        {
            AssertSelectionTree(adventure.SelectionTree.NextSelection.ToList(), obj.Item2);
        }


        #endregion
    }

    #endregion

    #region Db

    [Theory]
    [ClassData(typeof(CreateAdventureTestData))]
    public async Task CreateAdventure_Db_Test_SuccessfulAsync(Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure)
    {
        #region Arrange

        var repo = RepoBuilder.AdventureRepository;

        #endregion

        #region Act

        repo.Add(adventure);
        await repo.SaveChangesAsync();

        #endregion

        #region Assert

        var getAdventure = await repo.GetAdventureById(adventure.Id);

        if (getAdventure is null)
        {
            Assert.True(false);
        }

        ValidateObjects(adventure, getAdventure);
        ValidateObjects(adventure.Choices, getAdventure!.Choices);

        foreach (var detail in adventure.Choices)
        {
            var getDetail = getAdventure!.Choices.FirstOrDefault(d => d.Id == detail.Id);
            ValidateObjects(detail, getDetail);
        }

        #endregion
    }

    [Fact]
    public async Task MarkAsDeletedAdventure_Db_Test_SuccessfulAsync()
    {
        #region Arrange

        var repo = RepoBuilder.AdventureRepository;

        #endregion

        #region Act

        var list = await repo.GetAllAsync();
        var adventure = await repo.GetAdventureById(list[0].Id);

        adventure!.MarkAsDeleted();

        repo.Update(adventure);
        await repo.SaveChangesAsync();

        #endregion

        #region Assert

        var getAdventure = await repo.GetAdventureById(adventure.Id);

        if (getAdventure is null)
        {
            Assert.True(false);
        }

        Assert.True(getAdventure!.IsDeleted);

        foreach (var detail in adventure.Choices)
        {
            Assert.True(detail.IsDeleted);
        }

        #endregion
    }

    [Fact]
    public async Task RestoreDeletedAdventure_Db_Test_SuccessfulAsync()
    {
        #region Arrange

        var repo = RepoBuilder.AdventureRepository;

        #endregion

        #region Act

        var list = await repo.GetAllAsync();
        var adventure = await repo.GetAdventureById(list[0].Id);

        adventure!.MarkAsDeleted();

        repo.Update(adventure);
        await repo.SaveChangesAsync();

        var deletedAdventure = await repo.GetAdventureById(list[0].Id);

        deletedAdventure!.Restore();

        repo.Update(deletedAdventure);
        await repo.SaveChangesAsync();

        #endregion

        #region Assert

        var getAdventure = await repo.GetAdventureById(adventure.Id);

        if (getAdventure is null)
        {
            Assert.True(false);
        }

        Assert.False(getAdventure!.IsDeleted);

        foreach (var detail in adventure.Choices)
        {
            Assert.False(detail.IsDeleted);
        }

        #endregion
    }

    #endregion

    #region Private

    private void AssertSelectionTree(List<AdventureSelection> selections, Array? array)
    {
        foreach (Tuple<AdventureSelection, Array?> tpl in array!)
        {
            var item = selections.FirstOrDefault(x => x.Code == tpl.Item1.Code &&
                                                                                    x.ParentCode == tpl.Item1.ParentCode &&
                                                                                    x.Action == tpl.Item1.Action &&
                                                                                    x.Text == tpl.Item1.Text);
            Assert.NotNull(item);

            if (tpl.Item2 != null)
            {
                AssertSelectionTree((List<AdventureSelection>)item!.NextSelection, tpl.Item2);
            }
        }

    }

    #endregion
}