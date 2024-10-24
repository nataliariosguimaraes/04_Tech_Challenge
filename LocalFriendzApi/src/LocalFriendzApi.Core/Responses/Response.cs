using LocalFriendzApi.Core.Configuration;
using System.Text.Json.Serialization;

namespace LocalFriendzApi.Core.Responses
{
    public class Response<TData>
    {
        public int Code = ConfigurationPage.DefaultStatusCode;

        [JsonConstructor]
        public Response() => Code = ConfigurationPage.DefaultStatusCode;

        public Response(TData? data, int code = ConfigurationPage.DefaultStatusCode, string? message = null)
        {
            Data = data;
            Code = code;
            Message = message;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => Code is >= 200 and <= 299;
    }
}
