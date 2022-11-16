using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Test.Builders.AdventureAggregate;
using Xunit;

namespace Adventure.Test.Domain.DomainModels.AdventureAggregate
{
    public class CreateAdventureTestData : TheoryData<Adventure.Domain.DomainModels.AdventureAggregate.Adventure>
    {
        private static AdventureSelectionBuilder SystemSelection => new AdventureSelectionBuilder().WithSystemAsUser();

        public CreateAdventureTestData()
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

            Add(adventure);
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

            var selection10 = SystemSelection
                .WithCode(9)
                .WithParentCode(4)
                .WithAction("Yes")
                .WithText("Get Married Soon!");

            var selection11 = SystemSelection
                .WithCode(10)
                .WithParentCode(4)
                .WithAction("Yes")
                .WithText("Are you not planning to get married?");

            var selection12 = SystemSelection
                .WithCode(11)
                .WithParentCode(7)
                .WithAction("Yes")
                .WithText("Good luck");

            var selection13 = SystemSelection
                .WithCode(12)
                .WithParentCode(7)
                .WithAction("No")
                .WithText("Hope you are happy!");

            var selection14 = SystemSelection
                .WithCode(13)
                .WithParentCode(8)
                .WithAction("Yes")
                .WithText("Good luck!");

            var selection15 = SystemSelection
                .WithCode(14)
                .WithParentCode(8)
                .WithAction("No")
                .WithText("I appreciate your choice");

            var selection16 = SystemSelection
                .WithCode(15)
                .WithParentCode(10)
                .WithAction("Yes")
                .WithText("Good luck");

            var selection17 = SystemSelection
                .WithCode(16)
                .WithParentCode(10)
                .WithAction("No")
                .WithText("Single life rocks!");

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
                .WithAdventureSelection(selection9)
                .WithAdventureSelection(selection10)
                .WithAdventureSelection(selection11)
                .WithAdventureSelection(selection12)
                .WithAdventureSelection(selection13)
                .WithAdventureSelection(selection14)
                .WithAdventureSelection(selection15)
                .WithAdventureSelection(selection16)
                .WithAdventureSelection(selection17);

            Add(adventure);
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

            Add(adventure);
        }
    }
}
