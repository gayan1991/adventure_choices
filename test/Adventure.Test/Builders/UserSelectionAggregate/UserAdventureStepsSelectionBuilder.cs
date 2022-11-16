using Adventure.Domain.DomainModels.AdventureAggregate;
using Adventure.Domain.DomainModels.UserSelectionAggregate;
using Adventure.Test.Builders.AdventureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Adventure.Test.Builders.UserSelectionAggregate
{
    public class UserAdventureStepsSelectionBuilder : BaseBuilder<UserAdventureStepsSelection, UserAdventureStepsSelectionBuilder>
    {
        #region Base

        private bool _isDeleted;
        private DateTimeOffset _createdAt;
        private DateTimeOffset _updatedAt;
        private string _createdBy;
        private string _updatedBy;

        #endregion

        private byte _step;
        private bool _isSystemUser;
        private UserAdventureSelection _adventure;

        public UserAdventureStepsSelectionBuilder WithStep(byte step) => CommonReturn(this, out _step, step);

        public override UserAdventureStepsSelectionBuilder WithCreatedAt(DateTimeOffset createdAt) => CommonReturn(this, out _createdAt, createdAt);

        public override UserAdventureStepsSelectionBuilder WithCreatedBy(string createdBy) => CommonReturn(this, out _createdBy, createdBy);

        public override UserAdventureStepsSelectionBuilder WithIsDeleted(bool isDeleted) => CommonReturn(this, out _isDeleted, isDeleted);

        public override UserAdventureStepsSelectionBuilder WithUpdatedAt(DateTimeOffset updatedAt) => CommonReturn(this, out _updatedAt, updatedAt);

        public override UserAdventureStepsSelectionBuilder WithUpdatedBy(string updatedBy) => CommonReturn(this, out _updatedBy, updatedBy);

        public override UserAdventureStepsSelectionBuilder WithSystemAsUser() => CommonReturn(this, out _isSystemUser, true);

        public UserAdventureStepsSelectionBuilder WithUserAdventure(UserAdventureSelection adventure) =>
            CommonReturn(this, out _adventure, adventure);

        protected override UserAdventureStepsSelection Build()
        {
            var adventureStep = _isSystemUser ? new UserAdventureStepsSelection(_adventure, _step) : 
                                                new UserAdventureStepsSelection(_adventure, _step, _createdBy);

            if (_createdAt != default)
            {
                adventureStep.CreatedAt = _createdAt;
            }

            if (!string.IsNullOrWhiteSpace(_updatedBy))
            {
                adventureStep.UpdatedBy = _updatedBy;
            }

            if (_updatedAt != default)
            {
                adventureStep.UpdatedAt = _updatedAt;
            }

            if (_isDeleted)
            {
                adventureStep.IsDeleted = true;
            }

            return adventureStep;
        }

    }
}
