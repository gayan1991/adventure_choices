using Adventure.Domain.Interface.Repository;
using Adventure.Infrastructure.Util.InfraModel;
using Newtonsoft.Json;

namespace Adventure.Infrastructure.Util.InfraService
{
    public class RequestResponseLogService : IRequestResponseLogService
    {
        private readonly IRepository<RequestResponseLog> _repository;

        public RequestResponseLogService(IRepository<RequestResponseLog> repository)
        {
            _repository = repository;
        }

        public async Task SaveRequestLogAsync(string actionName, object parameters, IDictionary<string, string?> routing)
        {
            var routingValues = JsonConvert.SerializeObject(routing);
            var parameterValues = JsonConvert.SerializeObject(parameters);

            var requestLog = new RequestResponseLog(RequestResponseLogType.Request, actionName, parameterValues,
                routingValues);

            _repository.Add(requestLog);

            await _repository.SaveChangesAsync();
        }

        public Task SaveResponseLogAsync(string actionName, object parameters, IDictionary<string, string?> routing, object responseValue)
        {
            var routingValues = JsonConvert.SerializeObject(routing);
            var parameterValues = JsonConvert.SerializeObject(parameters);

            var responseLog = new RequestResponseLog(RequestResponseLogType.Response, actionName, parameterValues,
                routingValues);

            _repository.Add(responseLog);

            return _repository.SaveChangesAsync();
        }
    }
}
