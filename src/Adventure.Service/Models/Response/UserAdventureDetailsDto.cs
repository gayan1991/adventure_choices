using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Models.Response
{
    public class UserAdventureDetailsDto
    {
        public byte Code { get; set; }
        public string Text { get; set; }
        public string Selection { get; set; }
    }

    //public static class UserAdventureSelectionStepsExtension
    //{
    //    public static UserAdventureDetailsDto ToDetailsDto(this Domain.DomainModels.AdventureModels.Adventure adventure, string adventureName)
    //    {

    //    }
    //}
}
