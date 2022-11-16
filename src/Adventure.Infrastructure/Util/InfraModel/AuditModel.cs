 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Util.InfraModel
{
    public class Audit
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public string Record { get; set; }

        public Audit() { }

        public Audit(string tableName, string recordedObj)
        {
            Table = tableName;
            Record = recordedObj;
        }
    }
}
