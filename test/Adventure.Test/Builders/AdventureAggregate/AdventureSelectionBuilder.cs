using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureAggregate;

namespace Adventure.Test.Builders.AdventureAggregate
{
    public class AdventureSelectionBuilder : BaseBuilder<AdventureSelection, AdventureSelectionBuilder>
    {
        #region Base

        private bool _isDeleted;
        private DateTimeOffset _createdAt;
        private DateTimeOffset _updatedAt;
        private string _createdBy;
        private string _updatedBy;

        #endregion

        private byte _code;
        private byte? _parentCode;
        private string _text;
        private string? _action;
        private bool _isSystemUser;
        private Adventure.Domain.DomainModels.AdventureAggregate.Adventure _adventure;

        public AdventureSelectionBuilder WithCode(byte code) => CommonReturn(this, out _code, code);

        public AdventureSelectionBuilder WithParentCode(byte parentCode) => CommonReturn(this, out _parentCode, parentCode);

        public AdventureSelectionBuilder WithText(string text) => CommonReturn(this, out _text, text);

        public AdventureSelectionBuilder WithAction(string action) => CommonReturn(this, out _action, action);

        public override AdventureSelectionBuilder WithCreatedAt(DateTimeOffset createdAt) => CommonReturn(this, out _createdAt, createdAt);

        public override AdventureSelectionBuilder WithCreatedBy(string createdBy) => CommonReturn(this, out _createdBy, createdBy);

        public override AdventureSelectionBuilder WithIsDeleted(bool isDeleted) => CommonReturn(this, out _isDeleted, isDeleted);

        public override AdventureSelectionBuilder WithUpdatedAt(DateTimeOffset updatedAt) => CommonReturn(this, out _updatedAt, updatedAt);

        public override AdventureSelectionBuilder WithUpdatedBy(string updatedBy) => CommonReturn(this, out _updatedBy, updatedBy);

        public override AdventureSelectionBuilder WithSystemAsUser() => CommonReturn(this, out _isSystemUser, true);

        public AdventureSelectionBuilder WithAdventure(Adventure.Domain.DomainModels.AdventureAggregate.Adventure adventure) => CommonReturn(this, out _adventure, adventure);

        protected override AdventureSelection Build()
        {
            var adventureSelection = _isSystemUser ? new AdventureSelection(_adventure, _code, _parentCode, _text, _action):
                                                     new AdventureSelection(_adventure, _code, _parentCode, _text, _action, _createdBy);

            if(_createdAt != default)
            {
                adventureSelection.CreatedAt = _createdAt;
            }

            if (!string.IsNullOrWhiteSpace(_updatedBy))
            {
                adventureSelection.UpdatedBy = _updatedBy;
            }

            if (_updatedAt != default)
            {
                adventureSelection.UpdatedAt = _updatedAt;
            }

            if (_isDeleted)
            {
                adventureSelection.IsDeleted = true;
            }

            return adventureSelection;
        }
    }
}
