using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace YaStation.Reverse.Quasar.Common
{
    //https://iot.quasar.yandex.ru/m/user/scenarios/icons
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Icon
    {
        [EnumMember(Value = "morning")] Morning,
        [EnumMember(Value = "day")] Day,
        [EnumMember(Value = "evening")] Evening,
        [EnumMember(Value = "night")] Night,
        [EnumMember(Value = "game")] Game,
        [EnumMember(Value = "sport")] Sport,
        [EnumMember(Value = "cleaning")] Cleaning,
        [EnumMember(Value = "home")] Home,
        [EnumMember(Value = "sofa")] Sofa,
        [EnumMember(Value = "work")] Work,
        [EnumMember(Value = "flowers")] Flowers,
        [EnumMember(Value = "drink")] Drink,
        [EnumMember(Value = "alarm")] Alarm,
        [EnumMember(Value = "party")] Party,
        [EnumMember(Value = "romantic")] Romantic,
        [EnumMember(Value = "cooking")] Cooking,
        [EnumMember(Value = "ball")] Ball,
        [EnumMember(Value = "tree")] Tree,
        [EnumMember(Value = "present")] Present,
        [EnumMember(Value = "toy")] Toy,
        [EnumMember(Value = "sock")] Sock,
        [EnumMember(Value = "star")] Star,
        [EnumMember(Value = "snowflake")] Snowflake,
        [EnumMember(Value = "lamp")] Lamp,
        [EnumMember(Value = "tv")] Tv,
        [EnumMember(Value = "station")] Station,
        [EnumMember(Value = "toggle")] Toggle,
        [EnumMember(Value = "socket")] Socket,
        [EnumMember(Value = "music")] Music,
        [EnumMember(Value = "lamps")] Lamps
    }
}