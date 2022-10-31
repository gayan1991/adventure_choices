using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Domain.DomainModels.UserSelectionAggregate;
using Adventure.Test.Builders.AdventureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adventure.Test.Builders.UserSelectionAggregate
{
    public class UserAdventureSelectionBuilder : BaseBuilder<UserAdventureSelection, UserAdventureSelectionBuilder>
    {
        #region Base

        private bool _isDeleted;
        private DateTimeOffset _createdAt;
        private DateTimeOffset _updatedAt;
        private string _createdBy;
        private string _updatedBy;

        #endregion

        private Guid _userId;
        private Guid _adventureId;
        private bool _isCompleted;
        private List<UserAdventureStepsSelection> _steps = new List<UserAdventureStepsSelection>();

        public UserAdventureSelectionBuilder WithUserId(Guid userId) => CommonReturn(this, out _userId, userId);

        public UserAdventureSelectionBuilder WithAdventureId(Guid adventureId) =>
            CommonReturn(this, out _adventureId, adventureId);

        public UserAdventureSelectionBuilder WithCompletion(bool isCompleted) =>
            CommonReturn(this, out _isCompleted, isCompleted);

        public override UserAdventureSelectionBuilder WithCreatedAt(DateTimeOffset createdAt) => CommonReturn(this, out _createdAt, createdAt);

        public override UserAdventureSelectionBuilder WithCreatedBy(string createdBy) => CommonReturn(this, out _createdBy, createdBy);

        public override UserAdventureSelectionBuilder WithIsDeleted(bool isDeleted) => CommonReturn(this, out _isDeleted, isDeleted);

        public override UserAdventureSelectionBuilder WithUpdatedAt(DateTimeOffset updatedAt) => CommonReturn(this, out _updatedAt, updatedAt);

        public override UserAdventureSelectionBuilder WithUpdatedBy(string updatedBy) => CommonReturn(this, out _updatedBy, updatedBy);

        public UserAdventureSelectionBuilder WithSelectedStep(UserAdventureStepsSelection step) =>
            CommonAdd(this, ref _steps, step);

        protected override UserAdventureSelection Build()
        {
            var adventurePlayedByUser = new UserAdventureSelection(_userId, _adventureId, _createdBy);

            if (_createdAt != default)
            {
                adventurePlayedByUser.CreatedAt = _createdAt;
            }

            if (!string.IsNullOrWhiteSpace(_updatedBy))
            {
                adventurePlayedByUser.UpdatedBy = _updatedBy;
            }

            if (_updatedAt != default)
            {
                adventurePlayedByUser.UpdatedAt = _updatedAt;
            }

            if (_isDeleted)
            {
                adventurePlayedByUser.IsDeleted = true;
            }

            if (_isCompleted)
            {
                adventurePlayedByUser.IsCompleted = true;
            }

            foreach (var step in _steps)
            {
                adventurePlayedByUser.Update(step.Step, step.UpdatedBy);

                if (step.UpdatedAt != default)
                {
                    adventurePlayedByUser.Steps[^1].UpdatedAt = step.UpdatedAt;
                }
            }

            return adventurePlayedByUser;
        }
    }
}
