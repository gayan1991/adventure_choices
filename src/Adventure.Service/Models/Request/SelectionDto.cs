using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Models.Request
{
    public class SelectionDto
    {
        public string Text { get; set; } = null!;
        public string Action { get; set; } = null!;
        public List<SelectionDto> NextSelections { get; set; } = null!;
    }
}
