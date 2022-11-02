using BattleShipV3.Shared.Data;
using BattleShipV3.Data.Models;
using JsonSubTypes;
using NJsonSchema.Converters;
using Newtonsoft.Json;

namespace BattleShipV3.Data.Models
{
    [JsonConverter(typeof(JsonInheritanceConverter), "Identifier")]
    [JsonSubtypes.KnownSubType(typeof(Healer), "Healer")]
    [JsonSubtypes.KnownSubType(typeof(Submarine), "Submarine")]
    public class Ship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public Missile Missile { get; set; }

        //public virtual string Identifier { get; } = "Ship";

        public virtual string GetSpecialtyName()
        {
            return "None";
        }
        public virtual int GetSpecialtyBonus()
        {
            return 0;
        }

    }
}
