using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BklyOnboardingAPI.Domain.Shared.Responses
{
    public class ResponseDto<T>
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("errors")]
        public List<string> Errors { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
