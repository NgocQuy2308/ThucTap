using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace ThucTap.Enumerates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Evaluate
    {
        VeryBad = 0,
        Bad = 1,
        NotBad = 2,
        Good = 3,
        VeryGood = 4,
        TheBest = 5,
    }
}
