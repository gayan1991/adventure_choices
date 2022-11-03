using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.DomainModels.AdventureAggregate
{
    public class AdventureSelection : BaseModel
    {
        public byte Code { get; set; }
        public byte? ParentCode { get; set; }
        public string Text { get; set; }
        public string? Action { get; set; }
        public Adventure Adventure { get; set; }


        private readonly List<AdventureSelection> _next = new();
        public IReadOnlyList<AdventureSelection> NextSelection => _next;

        public AdventureSelection()
        {
        }

        public AdventureSelection(Adventure adventure, byte code, string text, string? action = null, string createdBy = "System") : base(createdBy)
        {
            Adventure = adventure;
            Code = code;
            Text = text;
            Action = action;
        }

        public AdventureSelection(Adventure adventure, byte code, byte? parentCode, string text, string? action = null, string createdBy = "System") : base(createdBy)
        {
            Adventure = adventure;
            Code = code;
            ParentCode = parentCode;
            Text = text;
            Action = action;
        }

        public void MarkAsDeleted(string updatedBy = "System")
        {
            UpdateDeletedValue(true, updatedBy);
        }

        public void Restore(string updatedBy = "System")
        {
            UpdateDeletedValue(false, updatedBy);
        }

        #region Internal

        internal void AddNextSelection(AdventureSelection obj)
        {
            _next.Add(obj);
        }

        #endregion
    }
}
