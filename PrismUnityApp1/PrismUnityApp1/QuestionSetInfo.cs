using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiwakeApp
{
    [JsonObject("QuestionSet")]
    public class QuestionSetInfo
    {
        [JsonProperty("SetName")]
        public string SetName { get; set; }
        [JsonProperty("Grade")]
        public string Grade { get; set; }
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Questions")]
        public List<QuestionInfo> Questions { get;set; }
    }
}
