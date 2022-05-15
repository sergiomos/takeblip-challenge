using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Newtonsoft.Json;

namespace Take.Api.Challenge.Models
{
    [ExcludeFromCodeCoverage]
    public class Repository
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        
        [JsonProperty("description")]

        public string Description { get; set; }
    }
}
