using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DomainModels
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public BaseModel() { }

        public BaseModel(string actionBy)
        {
            Id = Guid.NewGuid();
            Create(actionBy);
        }

        private protected void Create(string actionBy)
        {
            UpdatedBy = CreatedBy = actionBy;
            UpdatedAt = CreatedAt = DateTimeOffset.UtcNow;
        }

        private protected void Update(string actionBy)
        {
            UpdatedBy = actionBy;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        private protected void UpdateDeletedValue(bool value, string updatedBy)
        {
            IsDeleted = value;
            Update(updatedBy);
        }
    }
}
