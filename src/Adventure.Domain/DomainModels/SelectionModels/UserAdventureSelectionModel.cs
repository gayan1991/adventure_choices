using Adventure.Domain.DomainModels.AdventureModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DomainModels.SelectionModels
{
    public class UserAdventureSelection : BaseModel
    {
        public Guid UserId { get; set; }
        public Guid AdventureId { get; set; }
        public bool IsCompleted { get; set; }


        private readonly List<UserAdventureStepsSelection> _steps = new();
        public IReadOnlyList<UserAdventureStepsSelection> Steps => _steps;

        private UserAdventureSelection()
        {
        }

        public UserAdventureSelection(Guid userId, Guid adventureId, string createdBy = "System") : base(createdBy)
        {
            UserId = userId;
            AdventureId = adventureId;
        }

        public void Update(byte step, string updatedBy = "System")
        {
            _steps.Add(new UserAdventureStepsSelection(this, step, updatedBy));
            Update(updatedBy);
        }

        public void Delete(string updatedBy = "system")
        {
            foreach (var step in _steps)
            {
                step.MarkAsDeleted(updatedBy);
            }
            UpdateDeletedValue(true, updatedBy);
        }

        public void MarkAsCompleted(string updatedBy = "System")
        {
            IsCompleted = true;
            Update(updatedBy);
        }
    }
}
