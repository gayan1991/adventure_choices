using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Service.Interface
{
    public interface IRequestLogService
    {
        Task SaveRequestLogAsync(string actionName, object parameters, IDictionary<string, string?> routing);
    }
}
