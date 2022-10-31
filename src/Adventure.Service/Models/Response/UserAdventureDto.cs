using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.UserSelectionAggregate;

namespace Adventure.Service.Models.Response
{
    public class UserAdventureDto
    {
        public Guid UserId { get; set; }
        public Guid AdventureId { get; set; }
        public string AdventureName { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public int CurrentSelection { get; set; }
        public List<UserAdventureDetailsDto> Details { get; set; } = null!;
    }

    public static class UserAdventureSelectionExtension
    {
        public static UserAdventureDto ToDto(this UserAdventureSelection selection, string adventureName)
        {
            var currentSelectedStep = selection.Steps.MaxBy(x => x.Step);

            return new UserAdventureDto()
            {
                UserId = selection.UserId,
                AdventureId = selection.AdventureId,
                AdventureName = adventureName,
                IsCompleted = selection.IsCompleted,
                CurrentSelection = currentSelectedStep?.Step ?? 0
            };
        }

        public static UserAdventureDto ToDetailDto(this UserAdventureSelection selection, Domain.DomainModels.AdventureAggregate.Adventure adventure)
        {
            var currentSelectedStep = selection.Steps.MaxBy(x => x.Step);

            var rtnObj = new UserAdventureDto()
            {
                UserId = selection.UserId,
                AdventureId = selection.AdventureId,
                AdventureName = adventure.Name,
                IsCompleted = selection.IsCompleted,
                CurrentSelection = currentSelectedStep?.Step ?? 0
            };

            if (selection.Steps.Any())
            {
                rtnObj.Details = new List<UserAdventureDetailsDto>();
                foreach (var step in selection.Steps)
                {
                    var obj = adventure[step.Step];
                    rtnObj.Details.Add(new UserAdventureDetailsDto()
                    {
                        Code = step.Step,
                        Selection = obj.Action!,
                        Text = obj.Text
                    });
                }
            }

            return rtnObj;
        }
    }
}
