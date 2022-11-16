namespace Adventure.Domain.DomainModels.UserSelectionAggregate
{
    public class UserAdventureStepsSelection : BaseModel
    {
        public byte Step { get; set; }
        public UserAdventureSelection AdventureSelection { get; set; }

        public UserAdventureStepsSelection()
        {
        }

        public UserAdventureStepsSelection(UserAdventureSelection doughnutSelection, byte step, string createdBy = "System") : base(createdBy)
        {
            AdventureSelection = doughnutSelection;
            Step = step;
        }

        internal void MarkAsDeleted(string updatedBy = "System")
        {
            UpdateDeletedValue(true, updatedBy);
        }
    }
}
