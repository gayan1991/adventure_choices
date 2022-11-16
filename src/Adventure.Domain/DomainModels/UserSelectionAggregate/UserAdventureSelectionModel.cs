namespace Adventure.Domain.DomainModels.UserSelectionAggregate
{
    public class UserAdventureSelection : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid AdventureId { get; set; }
        public bool IsCompleted { get; set; }


        private readonly List<UserAdventureStepsSelection> _steps = new();
        public IReadOnlyList<UserAdventureStepsSelection> Steps => _steps;

        public UserAdventureSelection()
        {
        }

        public UserAdventureSelection(Guid userId, Guid adventureId, string createdBy = "System") : base(createdBy)
        {
            UserId = userId;
            AdventureId = adventureId;
        }

        public void Update(byte step, string updatedBy = "System")
        {
            if (_steps.Any(x => x.Step == step && !x.IsDeleted))
            {
                throw new ArgumentException("Update Failed, this step has already passed");
            }

            _steps.Add(new UserAdventureStepsSelection(this, step, updatedBy));
            Update(updatedBy);
        }

        public void Delete(string updatedBy = "system")
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("This user selected adventure is already removed from this user");
            }

            foreach (var step in _steps)
            {
                step.MarkAsDeleted(updatedBy);
            }
            UpdateDeletedValue(true, updatedBy);
        }

        public void MarkAsCompleted(string updatedBy = "System")
        {
            if (IsCompleted)
            {
                throw new InvalidOperationException("This user selected adventure is already completed");
            }

            IsCompleted = true;
            Update(updatedBy);
        }
    }
}
