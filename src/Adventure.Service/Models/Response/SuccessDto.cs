using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Models.Response
{
    public class SuccessDto
    {
        protected string Title { get; private set; }
        protected object Tag { get; private set; }

        public SuccessDto(string title) : this(title, null)
        { }

        public SuccessDto(string title, object tag)
        {
            Title = title;
            Tag = tag;
        }
    }
}
