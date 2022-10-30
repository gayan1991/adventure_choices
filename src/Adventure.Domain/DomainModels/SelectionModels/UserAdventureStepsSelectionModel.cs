using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DomainModels.SelectionModels
{
    public class UserAdventureStepsSelection : BaseModel
    {
        public byte Step { get; set; }
        public UserAdventureSelection AdventureSelection { get; set; }

        private UserAdventureStepsSelection()
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
