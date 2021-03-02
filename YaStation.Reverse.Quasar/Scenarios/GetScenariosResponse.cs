using System.Text.Json.Serialization;
using YaStation.Reverse.Quasar.Common.Response;

namespace YaStation.Reverse.Quasar.Scenarios
{
    public class GetScenariosResponse : QuasarResponse
    {
        [JsonPropertyName("scenarios")]
        public ScenarioListItem[] Scenarios { get; set; }
    }
}