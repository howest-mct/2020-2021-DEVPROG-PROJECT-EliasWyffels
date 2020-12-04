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
                if (CardId.Length < 15)
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
        public string Color 
        {
            get
            {
                switch (PlayerClass)
                {
                    case "Hunter":
                        return "#016E01";

                    case "Warrior":
                        return "#8E1002";

                    case "Priest":
                        return "#C7C19F";

                    case "Mage":
                        return "#0092AB";

                    case "Rogue":
                        return "#4C4D48";

                    case "Druid":
                        return "#703606";

                    case "Shaman":
                        return "#8E1002";

                    case "Warlock":
                        return "#7624AD";

                    case "Paladin":
                        return "#AA8F00";

                    case "Demon Hunter":
                        return "#A330C9";

                    case "Neutral":
                        return "#FFD3D3D3";

                    default:
                        return "#FFFFFF";
                }
            }
        }
        public string Test
        {
            get
            {
                if(CardId.Length < 15)
                {
                    return "#FCD237";
                }
               else
                {
                    switch (PlayerClass)
                    {
                        case "Hunter":
                            return "#016E01";

                        case "Warrior":
                            return "#8E1002";

                        case "Priest":
                            return "#C7C19F";

                        case "Mage":
                            return "#0092AB";

                        case "Rogue":
                            return "#4C4D48";

                        case "Druid":
                            return "#703606";

                        case "Shaman":
                            return "#8E1002";

                        case "Warlock":
                            return "#7624AD";

                        case "Paladin":
                            return "#AA8F00";

                        case "Demon Hunter":
                            return "#A330C9";

                        case "Neutral":
                            return "#FFD3D3D3";

                        default:
                            return "#FFFFFF";
                    }
                }
            }
        }
    }
}
