using System.Diagnostics;
using System.Runtime.Serialization;

namespace Adventure.Service.Models.Response
{
    public class ErrorMessageDto
    {
        public string FunctionName { get; set; }
        public string Message { get; private set; }
        private readonly StackTrace _stackTrace = new StackTrace();

        public ErrorMessageDto(string message)
        {
            Message = message;
        }
    }

    [Serializable]
    public class ErrorDto : ISerializable
    {
        protected int Status { get; private set; }
        protected string Title { get; private set; }
        IEnumerable<ErrorMessageDto> ErrorMessages { get; set; }

        public ErrorDto(int status, string title)
        {
            Status = status;
            Title = title;
            ErrorMessages = Enumerable.Empty<ErrorMessageDto>();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("status", Status);
            info.AddValue("title", Title);
            info.AddValue("errors", ErrorModelHelper.Serialize(ErrorMessages));
        }
    }

    public static class ErrorModelHelper
    {
        public static Dictionary<string, List<string>> Serialize(IEnumerable<ErrorMessageDto> errors)
        {
            var errorDic = new Dictionary<string, List<string>>();

            foreach (var error in errors)
            {
                var key = error.FunctionName;

                if (errorDic.ContainsKey(key))
                {
                    errorDic[error.FunctionName].Add(error.Message);
                }
                else
                {
                    errorDic.Add(key, new List<string> { error.Message });
                }
            }

            return errorDic;
        }
    }
}
