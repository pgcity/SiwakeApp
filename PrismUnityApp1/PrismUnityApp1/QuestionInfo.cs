using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiwakeApp
{
    [JsonObject("Question")]
    public class QuestionInfo
    {
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Hint")]
        public string Hint { get; set; }
        [JsonProperty("UseOffsetAnswer")]
        public bool UseOffsetAnswer { get; set; }
        [JsonProperty("Commentary")]
        public string Commentary { get; set; }
        [JsonProperty("SiwakeList")]
        public List<Siwake> SiwakeList { get; set; }
    }
}
