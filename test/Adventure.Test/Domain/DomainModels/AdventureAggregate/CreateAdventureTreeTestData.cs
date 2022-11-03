using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Test.Builders.AdventureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Test.Domain.DomainModels.AdventureAggregate
{
    public class CreateAdventureTreeTestData : TheoryData<Adventure.Domain.DomainModels.AdventureAggregate.Adventure, Tuple<AdventureSelection, Array?>>
    {
        private static AdventureSelectionBuilder SystemSelection => new AdventureSelectionBuilder().WithSystemAsUser();

        public CreateAdventureTreeTestData()
        {
            AdventureRecordWithSingleSelectionRecord();
            AdventureRecordWithYesNoQuestions();
            AdventureRecordWithMultipleChoiceQuestions();
        }

        private void AdventureRecordWithSingleSelectionRecord()
        {
            var selection = SystemSelection
                .WithCode(0)
                .WithText("Hello World");

            var adventure = new AdventureBuilder()
                .WithName("XYZ")
                .WithSystemAsUser()
                .WithAdventureSelection(selection);
            
            Add(adventure, new Tuple<AdventureSelection, Array?>(selection, null));
        }

        private void AdventureRecordWithYesNoQuestions()
        {
            var selection = SystemSelection
                .WithCode(0)
                .WithText("Are you fine?");

            var selection2 = SystemSelection
                .WithCode(1)
                .WithParentCode(0)
                .WithAction("Yes")
                .WithText("Are you married?");

            var selection3 = SystemSelection
                .WithCode(2)
                .WithParentCode(0)
                .WithAction("No")
                .WithText("Are you crying?");

            var selection4 = SystemSelection
                .WithCode(3)
                .WithParentCode(1)
                .WithAction("Yes")
                .WithText("Do you have kids?");

            var selection5 = SystemSelection
                .WithCode(4)
                .WithParentCode(1)
                .WithAction("No")
                .WithText("Do you like kids?");

            var selection6 = SystemSelection
                .WithCode(5)
                .WithParentCode(2)
                .WithAction("Yes")
                .WithText("Hope Everything is good");

            var selection7 = SystemSelection
                .WithCode(6)
                .WithParentCode(2)
                .WithAction("No")
                .WithText("It is okay to cry");

            var selection8 = SystemSelection
                .WithCode(7)
                .WithParentCode(3)
                .WithAction("Yes")
                .WithText("Do you want more?");

            var selection9 = SystemSelection
                .WithCode(8)
                .WithParentCode(3)
                .WithAction("No")
                .WithText("Are you planning to have kids?");

            var adventure = new AdventureBuilder()
                .WithSystemAsUser()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3)
                .WithAdventureSelection(selection4)
                .WithAdventureSelection(selection5)
                .WithAdventureSelection(selection6)
                .WithAdventureSelection(selection7)
                .WithAdventureSelection(selection8)
                .WithAdventureSelection(selection9);

            var select9 = new Tuple<AdventureSelection, Array?>(selection9, null);
            var select8 = new Tuple<AdventureSelection, Array?>(selection8, null);
            var select7 = new Tuple<AdventureSelection, Array?> (selection7, null);
            var select6 = new Tuple<AdventureSelection, Array?>(selection6, null);
            var select5 = new Tuple<AdventureSelection, Array?>(selection5, null);
            var select4 = new Tuple<AdventureSelection, Array?>(selection4, new[] { select9, select8});
            var select3 = new Tuple<AdventureSelection, Array?>(selection3, new[] { select7, select6 });
            var select2 = new Tuple<AdventureSelection, Array?>(selection2, new[] { select5, select4 });
            var select = new Tuple<AdventureSelection, Array?>(selection, new[] { select3, select2 });

            Add(adventure, select);
        }

        private void AdventureRecordWithMultipleChoiceQuestions()
        {
            var selection = SystemSelection
                .WithCode(0)
                .WithText("Pick a colour!");

            var selection2 = SystemSelection
                .WithCode(1)
                .WithParentCode(0)
                .WithAction("Blue")
                .WithText("Blue");

            var selection3 = SystemSelection
                .WithCode(2)
                .WithParentCode(0)
                .WithAction("Yellow")
                .WithText("Yellow");

            var selection4 = SystemSelection
                .WithCode(3)
                .WithParentCode(0)
                .WithAction("Red")
                .WithText("Red");

            var selection5 = SystemSelection
                .WithCode(4)
                .WithParentCode(0)
                .WithAction("White")
                .WithText("White");

            var selection6 = SystemSelection
                .WithCode(5)
                .WithParentCode(0)
                .WithAction("Orange")
                .WithText("Orange");

            var adventure = new AdventureBuilder()
                .WithSystemAsUser()
                .WithName("XYZ")
                .WithAdventureSelection(selection)
                .WithAdventureSelection(selection2)
                .WithAdventureSelection(selection3)
                .WithAdventureSelection(selection4)
                .WithAdventureSelection(selection5)
                .WithAdventureSelection(selection6);
            
            var select6 = new Tuple<AdventureSelection, Array?>(selection6, null);
            var select5 = new Tuple<AdventureSelection, Array?>(selection5, null);
            var select4 = new Tuple<AdventureSelection, Array?>(selection4, null);
            var select3 = new Tuple<AdventureSelection, Array?>(selection3, null);
            var select2 = new Tuple<AdventureSelection, Array?>(selection2, null);
            var select = new Tuple<AdventureSelection, Array?>(selection, new[] { select6, select5, select4, select3, select2 });

            Add(adventure, select);
        }
    }
}
