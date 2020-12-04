using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heartstone.Models
{
    public class Mechanic
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Card
    {
        private string _afbeelding;
        [JsonProperty(PropertyName = "cardId")]
        public string CardId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "rarity")]
        public string Rarity { get; set; }
        [JsonProperty(PropertyName = "cost")]
        public string Cost { get; set; }
        [JsonProperty(PropertyName = "artist")]
        public string Artist { get; set; }
        [JsonProperty(PropertyName = "playerClass")]
        public string PlayerClass { get; set; }
        [JsonProperty(PropertyName = "mechanics")]
        public List<Mechanic> Mechanics { get; set; }
        public string Afbeelding
        {
            get
            {
                if (CardId.Length < 10)
                {
                    return "https://art.hearthstonejson.com/v1/render/latest/enUS/512x/" + CardId + ".png";
                }
                else
                {
                    return _afbeelding;
                }

            }
            set
            {
                _afbeelding = value;
            }
        }
    }
}
