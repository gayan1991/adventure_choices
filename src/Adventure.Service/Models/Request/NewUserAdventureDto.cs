using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Models.Request
{
    public class NewUserAdventureDto
    {
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public List<UserSelectionDto> UserSelections { get; set; }
    }

    public class UserSelectionDto
    {
        public byte Code { get; set; }
        public DateTimeOffset SelectedAt { get; set; }
    }
}
