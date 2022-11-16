using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Util.InfraService
{
    public interface IRequestResponseLogService
    {
        Task SaveRequestLogAsync(string actionName, object parameters, IDictionary<string, string?> routing);
        Task SaveResponseLogAsync(string actionName, object parameters, IDictionary<string, string?> routing, object responseValue);
    }
}
