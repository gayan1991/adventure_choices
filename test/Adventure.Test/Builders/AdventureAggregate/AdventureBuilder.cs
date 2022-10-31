using Adventure.Domain.DomainModels.AdventureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Test.Builders.AdventureAggregate
{
    public class AdventureBuilder : BaseBuilder<Adventure.Domain.DomainModels.AdventureAggregate.Adventure, AdventureBuilder>
    {
        #region Base

        private bool _isDeleted;
        private DateTimeOffset _createdAt;
        private DateTimeOffset _updatedAt;
        private string _createdBy;
        private string _updatedBy;

        #endregion

        private string _name;
        private List<AdventureSelection> _adventureSelections = new List<AdventureSelection>();

        public AdventureBuilder WithName(string name) => CommonReturn(this, out _name, name);

        public override AdventureBuilder WithCreatedAt(DateTimeOffset createdAt) => CommonReturn(this, out _createdAt, createdAt);

        public override AdventureBuilder WithCreatedBy(string createdBy) => CommonReturn(this, out _createdBy, createdBy);

        public override AdventureBuilder WithIsDeleted(bool isDeleted) => CommonReturn(this, out _isDeleted, isDeleted);

        public override AdventureBuilder WithUpdatedAt(DateTimeOffset updatedAt) => CommonReturn(this, out _updatedAt, updatedAt);

        public override AdventureBuilder WithUpdatedBy(string updatedBy) => CommonReturn(this, out _updatedBy, updatedBy);

        public AdventureBuilder WithAdventureSelection(AdventureSelection adventureSelection) => CommonAdd(this, ref _adventureSelections, adventureSelection);

        protected override Adventure.Domain.DomainModels.AdventureAggregate.Adventure Build()
        {
            var adventure = new Adventure.Domain.DomainModels.AdventureAggregate.Adventure(_name, _createdBy);

            if (_createdAt != default)
            {
                adventure.CreatedAt = _createdAt;
            }

            if (!string.IsNullOrWhiteSpace(_updatedBy))
            {
                adventure.UpdatedBy = _updatedBy;
            }

            if (_updatedAt != default)
            {
                adventure.UpdatedAt = _updatedAt;
            }

            if (_isDeleted)
            {
                adventure.IsDeleted = true;
            }

            foreach (var detail in _adventureSelections)
            {
                adventure.AddChoice(detail.Code, detail.Text, detail.Action, detail.ParentCode, detail.UpdatedBy);
                
                if (detail.UpdatedAt != default)
                {
                    adventure[detail.Code].UpdatedAt = detail.UpdatedAt;
                }
            }

            return adventure;
        }
    }
}
