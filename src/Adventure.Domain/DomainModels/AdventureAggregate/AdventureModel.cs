using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.Util.Exceptions;

namespace Adventure.Domain.DomainModels.AdventureAggregate
{
    public class Adventure : BaseModel
    {
        public string Name { get; set; }
        public byte NextSelectionCode => GetNextCode();

        public AdventureSelection this[byte code]
        {
            get
            {
                var obj = _choices.FirstOrDefault(x => x.Code == code);

                if (obj is null)
                {
                    throw new NotFoundException($"Requested code ({code}) is not found");
                }

                return obj;
            }
        }

        private readonly List<AdventureSelection> _choices = new();
        public IReadOnlyList<AdventureSelection> Choices => _choices;
        public AdventureSelection SelectionTree => GenerateTreeBasedOnSelectionCodeAsync();

        public Adventure() { }

        public Adventure(string adventureName, string createdBy = "System") : base(createdBy)
        {
            Name = adventureName;
        }

        public void AddChoice(byte code, string text, string? action = null, byte? parentCode = null, string updatedBy = "System")
        {
            if (!_choices.Any() && code != 0)
            {
                throw new ArgumentException($"Code ({code}) is invalid, make sure code 0 is registered");
            }

            if (parentCode != null && !_choices.Any(x => x.Code == parentCode))
            {
                throw new ArgumentException($"Invalid parent code ({code}) is invalid, make sure parent is registered before adding the child");
            }

            if (parentCode != null && code <= parentCode)
            {
                throw new ArgumentException("Child code must be higher than parent code");
            }

            if (_choices.Any(x => x.Code == code))
            {
                throw new ArgumentException($"Duplicate code ({code})");
            }

            _choices.Add(new AdventureSelection(this, code, parentCode, text, action));
            Update(updatedBy);
        }

        public void AddChoice(AdventureSelection selection, string updatedBy = "System")
        {
            _choices.Add(selection);
            Update(updatedBy);
        }

        public void MarkAsDeleted(string updatedBy = "System")
        {
            if (IsDeleted)
            {
                throw new InvalidOperationException("This adventure has already been deleted");
            }

            foreach (var choice in _choices)
            {
                choice.DeleteByParent(updatedBy);
            }
            UpdateDeletedValue(true, updatedBy);
        }

        public void Restore(string updatedBy = "System")
        {
            foreach (var choice in _choices)
            {
                choice.Restore(updatedBy);
            }
            UpdateDeletedValue(false, updatedBy);
        }

        public bool IsSelectionAvailable(byte code)
        {
            return _choices.Any(x => x.Code == code);
        }

        #region Private

        private byte GetNextCode()
        {
            if (!_choices.Any())
                return 0;

            return (byte)(_choices.Max(x => x.Code) + 1);
        }

        private AdventureSelection GenerateTreeBasedOnSelectionCodeAsync(int code = 0)
        {
            var selection = _choices.FirstOrDefault(x => x.Code == code);

            if (selection == null)
            {
                throw new NotFoundException($"Requested code ({code}) is not found");
            }

            PopulateChildSelections(selection);
            return selection;
        }

        private void PopulateChildSelections(AdventureSelection selection)
        {
            var selectionList = _choices.Where(x => x.ParentCode == selection.Code);

            foreach (var item in selectionList)
            {
                PopulateChildSelections(item);
                selection.AddNextSelection(item);
            }
        }

        #endregion
    }
}
