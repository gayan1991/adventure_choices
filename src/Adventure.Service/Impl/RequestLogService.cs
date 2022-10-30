using Adventure.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Impl
{
    public class RequestLogService : IRequestLogService
    {
        public Task SaveRequestLogAsync(string actionName, object parameters, IDictionary<string, string?> routing)
        {
            throw new NotImplementedException();
        }
    }
}
