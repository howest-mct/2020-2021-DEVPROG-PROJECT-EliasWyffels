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
                //indien de card lenght kleiner is dan 25 toon de foto van deze link
                //anders toon de foto die we meegaven
                //dit doen we omdat we met fotos van onze api werken en die van onze zelfgemaakte  api werken en die moeten appart worden gehouden
                if (CardId.Length < 25)
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
        public string ListviewColor
        {
            get
            {
                if(CardId.Length < 25)
                {
                    //dit werd uitsluiten aangemaakt voor de listview alle gewone kaarten hebben de base color want die behoren allemaal tot dezelfde klasse
                    //maar custom cards kunnen tot alle classes behoren dus om daar wat duidelijk in te brengen geven we ze het kleur van hun klasse
                    //we kunnen hiervoor niet de de propertie color gebruiken anders zou de navbar van de gewone kaarten niet meer veranderen in de playerclasskleur
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
