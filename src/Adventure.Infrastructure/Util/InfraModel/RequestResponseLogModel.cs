using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Infrastructure.Util.InfraModel
{
    public class RequestResponseLog
    {
        public int Id { get; set; }
        public RequestResponseLogType LogType { get; set; }
        public string DisplayName { get; set; }
        public string Parameters { get; set; }
        public string RouteValues { get; set; }

        public RequestResponseLog() { }

        public RequestResponseLog(RequestResponseLogType logType, string displayName, string parameters, string routeVal)
        {
            LogType = logType;
            DisplayName = displayName;
            Parameters = parameters;
            RouteValues = routeVal;
        }
    }

    public enum RequestResponseLogType
    {
        Request,
        Response
    }
}
