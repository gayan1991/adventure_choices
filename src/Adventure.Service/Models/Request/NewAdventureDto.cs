using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Models.Request
{
    public class NewAdventureDto
    {
        public string Name { get; set; } = null!;
        public SelectionDto Selection { get; set; }
    }
}
