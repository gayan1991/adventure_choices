using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.Domain.DomainModels.AdventureModels;

namespace Adventure.Service.Models.Response
{
    public class AdventureSelectionDto
    {
        public int Code { get; set; }
        public string Text { get; set; } = null!;
        public List<AdventureSelectionDto> Selection { get; set; } = null!;
    }

    public static class AdventureSelectionExtension
    {
        public static AdventureSelectionDto ToSelectionDto(this AdventureSelection obj)
        {
            var rtnObj = new AdventureSelectionDto()
            {
                Code = obj.Code,
                Text = obj.Text,
                Selection = obj.NextSelection.Select(x => x.ToSelectionDto()).ToList()
            };
            return rtnObj;
        }
    }
}
